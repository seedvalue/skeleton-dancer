using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WndLoading : MonoBehaviour
{

	public static WndLoading Instance;

	[SerializeField] private Text loadingValue;

	[SerializeField] private GameObject pivotShowHide;


	private float curLoading = -1F;

	public void SetLoading (float val)
	{
		if(Math.Abs(curLoading - val) < 0.01F) return;
		curLoading = val;
		if (val < 0.01F || val > 0.99F)
		{
			pivotShowHide.SetActive(false);
		}
		else
		{
			pivotShowHide.SetActive(true);
		}
		
		
		string str = val.ToString ("F2");
		str += " %";


		if (loadingValue) {
			loadingValue.text = str;
		} else {
			Debug.LogError ("WndLoading : SetLoading : m_LoadingValue == null");
		}
	}




	void OnEnable ()
	{
		SetLoading (1F);
	}



	void Awake ()
	{
		Instance = this;
	}


}
