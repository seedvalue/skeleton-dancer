using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

	[SerializeField]
	private InputField sloganInputText;
	[SerializeField]
	private GameObject loadingObj;
	[SerializeField]
	private List<AudioSource> musicList;
	[Header("Buttons:")]
	[SerializeField] private Button buttonMusic0;
	[SerializeField] private Button buttonMusic1;
	[SerializeField] private Button buttonMusic2;
	[SerializeField] private Button buttonMusic3;
	[SerializeField] private Button buttonPlay;
	private void AddButtonListeners()
	{
		if(buttonMusic0)buttonMusic0.onClick.AddListener(OnClickMusic0);
		if(buttonMusic1)buttonMusic1.onClick.AddListener(OnClickMusic1);
		if(buttonMusic2)buttonMusic2.onClick.AddListener(OnClickMusic2);
		if(buttonMusic3)buttonMusic3.onClick.AddListener(OnClickMusic3);
		if(buttonPlay)buttonPlay.onClick.AddListener(OnClickedPlay);
	}
	
	
	public void OnClickMusic0 ()
	{
		PlayMusicAndSavePrefs(0);
	}
	
	public void OnClickMusic1 ()
	{
		PlayMusicAndSavePrefs(1);
	}
	
	public void OnClickMusic2 ()
	{
		PlayMusicAndSavePrefs(2);
	}
	
	public void OnClickMusic3()
	{
		PlayMusicAndSavePrefs(3);
	}
	
	private void PlayMusicAndSavePrefs(int num)
	{
		Debug.Log("StartScreen : SaveMusicPrefs");
		PlayerPrefs.SetInt ("MusicNum", num);
		PlaySelected (num);
	}
	
	private void PlaySelected (int num)
	{
		foreach (AudioSource one in musicList) {
			one.Stop ();
		}
		musicList [num].Play ();
	}

	public void OnChangedInput_Slogan (InputField input)
	{
		SaveSlogan (input.text);
	}
	
	public void OnClickedPlay ()
	{
		Debug.Log ("StartScreen :  OnClickedPlay");
		if(CtrlAds.Instance != null)CtrlAds.Instance.ShowInterstitial();
		StartCoroutine(LoadSceneDelayed(2F));
		loadingObj.SetActive (true);
		
		
	}


	private IEnumerator LoadSceneDelayed(float time)
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("Scene_1_Game_New");
	}
	
	private void SaveSlogan (string str)
	{
		Debug.Log ("SaveSlogan : " + str);
		PlayerPrefs.SetString ("Slogan", str);
	}
	
	private string ReadSlogan ()
	{
		Debug.Log ("ReadSlogan : ");

		if (PlayerPrefs.HasKey ("Slogan")) {
			string sl = PlayerPrefs.GetString ("Slogan");
			Debug.Log ("slogan = " + sl);

			return sl;
		} else {
			string slogan = "Look \n in advance \n how i can \n a dance";
			this.SaveSlogan (slogan);
			return slogan;
		}
	}

	private void Start ()
	{
		var slogan = ReadSlogan ();
		if (sloganInputText) {
			sloganInputText.text = slogan;
		}
		int num = 0;

		if (PlayerPrefs.HasKey ("MusicNum")) {
			num = PlayerPrefs.GetInt ("MusicNum");

		}
		AddButtonListeners();
		this.PlaySelected (num);
	}
}
