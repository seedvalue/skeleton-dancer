using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlWnd : MonoBehaviour
{
	public NativeShare m_Share;
	public Record m_RecordComponent;

	public static CtrlWnd Instance;

	public GameObject m_WndLoading;
	public GameObject m_WndGamePlay;
	public GameObject m_WndPause;
	
	
	
	
	public void ShareTest ()
	{
		//m_Share.ShareText ("test share text");
		m_Share.ShareScreenshotWithText ("TEST");

	}
	
	public void StopRecord ()
	{
		m_RecordComponent.Save ();
		//this.ShowLoading (true);
	}
	
	
	
	
	public void OnSavedRecording (string fPath)
	{
		//this.ShowLoading (false);
	//	this.Share (fPath);
	}
	
	public void ShowLoading (bool _isshow)
	{
		if (m_WndLoading) {
			m_WndLoading.SetActive (_isshow);
		} else {
			Debug.LogError ("!!!");
		}
	}
	
	public void Share (string filePath)
	{
		//m_Share.Share ("Look how I can dance! ;) ", _filePath, "https://play.google.com/store/apps/details?id=com.dzbz.dzbzskulldancer", "DZBZ Skull Dancer");
		//	m_Share.Share2 ("Look how I can dance! ", _filePath, "https://play.google.com/store/apps/details?id=com.dzbz.dzbzskulldancer", "DZBZ Skull Dancer", "image/*", true, "select app");
		//CtrlNativeGallery.Instance.Save (_filePath);
		//	this.ShowLoading (false);
		if(CtrlAds.Instance) CtrlAds.Instance.ShowInterstitial ();
		else Debug.LogError("Share : CtrlAds.Instance is NULL");
//		StartCoroutine (Sharedelay (filePath));
	}
	
	private IEnumerator Sharedelay (string filePath)
	{
		yield return new WaitForSeconds (3F);
		this.ShowLoading (false);
		//m_Share.Share2 ("Look how I can dance! ", _filePath, "https://play.google.com/store/apps/details?id=com.dzbz.dzbzskulldancer", "DZBZ Skull Dancer", "image/gif", true, "select app");
		//THIS WORK
		CtrlNativeGallery.Save (filePath);
		m_Share.Share ("Look how I can dance! \n download this game ;)  \n  https://play.google.com/store/apps/details?id=com.dzbz.dzbzskeletondancer", filePath, "https://play.google.com/store/apps/details?id=com.dzbz.dzbzskeletondancer", "DZBZ Skull Dancer");

	}
	
	public void ShowGamePlay ()
	{
		this.HideAll ();
		if (m_WndGamePlay) {
			m_WndGamePlay.SetActive (true);
		} else {
			Debug.LogError ("!!!");
		}
	}
	
	public void ShowPause ()
	{
		this.HideAll ();
		if (m_WndPause) {
			m_WndPause.SetActive (true);
		} else {
			Debug.LogError ("!!!");
		}
	}
	
	private void HideAll ()
	{
		if (m_WndGamePlay) {
			m_WndGamePlay.SetActive (false);
		} else {
			Debug.LogError ("!!!");
		}
	}
	
	void Awake ()
	{
		Instance = this;
	}
}
