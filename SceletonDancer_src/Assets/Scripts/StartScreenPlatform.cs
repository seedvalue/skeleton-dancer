using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenPlatform : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float _mLRValue = -Input.acceleration.x * 5F; // 
		float _mFwdValue = -Input.acceleration.y * 5F; // 



		Vector3 _euler = transform.eulerAngles;
		_euler.x = _mLRValue;
		_euler.y = _mFwdValue;

		transform.eulerAngles = _euler;
	}
}
