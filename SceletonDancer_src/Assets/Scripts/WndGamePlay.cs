using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WndGamePlay : MonoBehaviour
{
	[SerializeField] private Slider sliderTilt;
	[Header("Buttons:")]
	[SerializeField] private Button buttonExit;
	[SerializeField] private Button buttonShare;
	[SerializeField] private Button buttonSettings;
	
	private void AddListeners()
	{
		if (buttonExit != null) buttonExit.onClick.AddListener(OnClickedExit);
		if (buttonShare != null) buttonShare.onClick.AddListener(OnClickedShare);
		if (buttonSettings != null) buttonSettings.onClick.AddListener(OnClickedSettings);

		
	}
	
	
	private void SetSliderValue(float val)
	{
		if (sliderTilt)
		{
			if (Math.Abs(sliderTilt.value - val) < 0.01F) return;
			sliderTilt.value = val;
		}
		else
		{
			Debug.LogError("WndGamePlay : SetSliderValue : Slider is NULL");
		}
	}

	private void UpdateSlider()
	{
		var val = 0F;
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
				val = -1F;
			if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
				val = 1F;
		}
		else
		{
			val = Accelerometer.current.acceleration.ReadValue().x;
		}
		SetSliderValue(val);
	}


	public void OnClickedShare()
	{
		Debug.Log("WndGamePlay : OnClickedShare");
		if (CtrlWnd.Instance)
		{
			CtrlWnd.Instance.StopRecord();
		}
	}

	public void OnClickedShareTest()
	{
		Debug.Log("WndGamePlay : OnClickedShareTest");
		if (CtrlWnd.Instance)
		{
			CtrlWnd.Instance.ShareTest();
		}
	}

	public void OnClickedExit()
	{
		Debug.Log("WndGamePlay : OnClickedExit");
		SceneManager.LoadScene(0);
	}
	
	public void OnClickedSettings()
	{
		Debug.Log("WndGamePlay : OnClickedSettings");
	}


	private void Awake()
	{
		AddListeners();
	}

	private void Update()
	{
		UpdateSlider();
	}
}

