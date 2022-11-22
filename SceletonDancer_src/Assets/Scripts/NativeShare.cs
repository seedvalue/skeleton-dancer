using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

using UnityEngine.UI;

public class NativeShare : MonoBehaviour
{

	public Text DebugText;

	
	private string ScreenshotName = "screenshot.png";
	//Screenshot Name if sharing screenshot

	private string messageTemplate = "Come join me! ";

	private string m_gameStoreLink = "https://play.google.com/store/apps/details?id=com.dzbz.dzbzskeletondancer";


	/// <summary>
	/// Shares the text.
	/// </summary>
	/// <param name="text">Text.</param>
	public void ShareText (string text = "Look how I can dance!")
	{
		string shareMessage = text + "\n\n" + messageTemplate + "\n" + m_gameStoreLink; //Create share message with template, store link addition

		Share (shareMessage, "", "");//SHARE
	}

	/// <summary>
	/// Shares the screenshot with text.
	/// </summary>
	/// <param name="text">Text.</param>
	public void ShareScreenshotWithText (string text = "Playing Game")
	{
		string screenShotPath = Application.persistentDataPath + "/" + ScreenshotName;
		if (File.Exists (screenShotPath))
			File.Delete (screenShotPath);

		ScreenCapture.CaptureScreenshot (ScreenshotName);

		string shareMessage = text + "\n\n" + messageTemplate + "\n" + m_gameStoreLink;

		StartCoroutine (delayedShare (screenShotPath, shareMessage));
	}

	/// <summary>
	/// Delayeds the share.
	/// 
	/// CaptureScreenshot runs asynchronously, so you'll need to either capture the screenshot early and wait a fixed time
	/// for it to save, or set a unique image name and check if the file has been created yet before sharing.
	/// 
	/// </summary>
	/// <returns>The share.</returns>
	/// <param name="screenShotPath">Screen shot path.</param>
	/// <param name="text">Text.</param>
	IEnumerator delayedShare (string screenShotPath, string text)
	{
		while (!File.Exists (screenShotPath)) {
			yield return new WaitForSeconds (.05f);
		}
        
		Share (text, screenShotPath, "");
	}

	/// <summary>
	/// Share the specified shareText, imagePath, url and subject.
	/// </summary>
	/// <param name="shareText">Share text.</param>
	/// <param name="imagePath">Image path.</param>
	/// <param name="url">URL.</param>
	/// <param name="subject">Subject.</param>
	public void Share (string shareText, string imagePath, string url, string subject = "skeleton dancer")
	{
		if (File.Exists (imagePath) == false) {
			if (DebugText) {
				DebugText.text = "not exist in path =" + imagePath;
				return;
			}

		} else {
			if (DebugText) {
				DebugText.text = "file OK =" + imagePath;
			}
		}

		if (DebugText) {
		
		}


		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");

		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));
		AndroidJavaClass uriClass = new AndroidJavaClass ("android.net.Uri");
		AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject> ("parse", "file://" + imagePath);

		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_STREAM"), uriObject);
		//intentObject.Call<AndroidJavaObject> ("setType", "image/png");
		intentObject.Call<AndroidJavaObject> ("setType", "image/gif");

		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), shareText);

		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");

		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject> ("createChooser", intentObject, subject);
		currentActivity.Call ("startActivity", jChooser);

	}





	public  void Share2 (string body, string filePath = null, string url = null, string subject = "", string mimeType = "text/html", bool chooser = false, string chooserText = "Select sharing app")
	{
		ShareMultiple (body, new string[] { filePath }, url, subject, mimeType, chooser);
	}



	public  void ShareMultiple (string body, string[] filePaths = null, string url = null, string subject = "", string mimeType = "text/html", bool chooser = false, string chooserText = "Select sharing app")
	{
		ShareAndroid (body, subject, url, filePaths, mimeType, chooser, chooserText);

	}

	public  void ShareAndroid (string body, string subject, string url, string[] filePaths, string mimeType, bool chooser, string chooserText)
	{
		using (AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent"))
		using (AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent")) {
			using (intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_SEND"))) {
			}
			using (intentObject.Call<AndroidJavaObject> ("setType", mimeType)) {
			}
			using (intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_SUBJECT"), subject)) {
			}
			using (intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), body)) {
			}

			if (!string.IsNullOrEmpty (url)) {
				// attach url
				using (AndroidJavaClass uriClass = new AndroidJavaClass ("android.net.Uri"))
				using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject> ("parse", url))
				using (intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_STREAM"), uriObject)) {
				}
			} else if (filePaths != null) {
				// attach extra files (pictures, pdf, etc.)
				using (AndroidJavaClass uriClass = new AndroidJavaClass ("android.net.Uri"))
				using (AndroidJavaObject uris = new AndroidJavaObject ("java.util.ArrayList")) {
					for (int i = 0; i < filePaths.Length; i++) {
						//instantiate the object Uri with the parse of the url's file
						using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject> ("parse", "file://" + filePaths [i])) {
							uris.Call<bool> ("add", uriObject);
						}
					}

					using (intentObject.Call<AndroidJavaObject> ("putParcelableArrayListExtra", intentClass.GetStatic<string> ("EXTRA_STREAM"), uris)) {
					}
				}
			}

			// finally start application
			using (AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"))
			using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity")) {
				if (chooser) {
					AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject> ("createChooser", intentObject, chooserText);
					currentActivity.Call ("startActivity", jChooser);
				} else {
					currentActivity.Call ("startActivity", intentObject);
				}
			}
		}
	}
}