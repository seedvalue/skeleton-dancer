using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShoter : MonoBehaviour
{

	int _counter = 0;

	// Use this for initialization
	void Start ()
	{
		print (Application.persistentDataPath);
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Debug.LogError ("!!!");
			ScreenCapture.CaptureScreenshot (Application.persistentDataPath + _counter.ToString () + "_Screenshot.png");
			_counter++;
		}

	}
}
