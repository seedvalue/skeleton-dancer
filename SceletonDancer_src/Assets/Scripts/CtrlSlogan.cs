using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CtrlSlogan : MonoBehaviour
{

	public static CtrlSlogan Instance;

	public List<string> m_AllLines;

	public int m_CurrentIndexWord = 0;



	public int m_RefreshCounter = 0;
	public int m_RefreshEvery = 3;



	public string GetWord ()
	{
		if (m_AllLines.Count < 1) {
			return "";
		}


		m_RefreshCounter++;
		if (m_RefreshCounter >= m_RefreshEvery) {
			m_RefreshCounter = 0;
			m_CurrentIndexWord++;
		}



		if (m_CurrentIndexWord >= m_AllLines.Count) {
			m_CurrentIndexWord = 0;
		}

		string _curWord = m_AllLines [m_CurrentIndexWord];

		return _curWord;

	}



	//start()
	private void FillWords ()
	{
		string _all = this.ReadSlogan ();

		string[] result;
		string[] stringSeparators = new string[] { "\n" };
		result = _all.Split (stringSeparators, StringSplitOptions.None);

		m_AllLines = new List<string> ();
		m_AllLines.Add ("");
		m_AllLines.AddRange (result);
		m_AllLines.Add ("");

	}




	private string ReadSlogan ()
	{
		Debug.Log ("ReadSlogan : ");

		if (PlayerPrefs.HasKey ("Slogan") == true) {
			string _sl = PlayerPrefs.GetString ("Slogan");
			Debug.Log ("slogan = " + _sl);

			return _sl;
		} else {
			string _default = "Look \n in advance \n how i can \n a dance";
			return _default;
		}
	}





	void Awake ()
	{
		Instance = this;
	}



	// Use this for initialization
	void Start ()
	{
		FillWords ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
