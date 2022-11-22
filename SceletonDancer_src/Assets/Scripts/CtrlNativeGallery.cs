using UnityEngine;
using System.IO;

public class CtrlNativeGallery : MonoBehaviour
{

	public static CtrlNativeGallery Instance;

	public static void Save (string gifPath)
	{
		byte[] fileBytes;
		if (gifPath.Contains ("://")) {
			WWW www = new WWW (gifPath);
			fileBytes = www.bytes;
		} else {
			fileBytes = File.ReadAllBytes (gifPath);
		}
		NativeGallery.SaveVideoToGallery (fileBytes, "DZBZ Skeleton Dancer", "AwesomeDance {0}.gif");
	}
	
	void Awake ()
	{
		Instance = this;
	}
}
