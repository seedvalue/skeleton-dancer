using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SloganRandomReposer : MonoBehaviour
{


	public Text m_DependedText;





	// generates a random vector based on a single amplitude for x y and z
	Vector3 generateRandomVector (float amp)
	{
		Vector3 result = new Vector3 ();
		for (int i = 0; i < 3; i++) {
			float x = Random.Range (-amp, amp);
			result [i] = x;
		}
		return result;
	}



	private void RandomTextPos ()
	{
		Vector3 _pos = generateRandomVector (50F);
		//_pos.x =	Perlin.Noise (100F);

		m_DependedText.transform.localPosition = _pos;

	}



	void OnEnable ()
	{
		RandomTextPos ();

	}




	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
