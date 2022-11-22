using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SloganTextRefresher : MonoBehaviour
{

	public Text m_DependedText;






	void OnEnable ()
	{
		if (CtrlSlogan.Instance == null) {
			return;
		}

		//get current text
		string _curWord = CtrlSlogan.Instance.GetWord ();
		m_DependedText.text = _curWord;
	}

}
