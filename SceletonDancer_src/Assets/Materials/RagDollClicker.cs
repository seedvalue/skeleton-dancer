using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class RagDollClicker : MonoBehaviour
{
	[SerializeField] private GameObject currentPlayer;
	[SerializeField] private GameObject currentPlayer2;

	[SerializeField] private float mLrValue;
	[SerializeField] private float mLrSpeed = 5F;


	private void RefreshRigidbodyes()
	{
		if (currentPlayer) GetChildRecursive(currentPlayer, _mAllRigidBodyes);
		else Debug.LogError("RagDollClicker : RefreshRigidbodyes : CurrentPlayer is NULL");
		if (currentPlayer2) GetChildRecursive(currentPlayer2, _mAllRigidBodyes2);
		else Debug.LogError("RagDollClicker : RefreshRigidbodyes : CurrentPlayer_2 is NULL");
	}

	private readonly Dictionary<string, Rigidbody> _mAllRigidBodyes = new Dictionary<string, Rigidbody>();
	private readonly Dictionary<string, Rigidbody> _mAllRigidBodyes2 = new Dictionary<string, Rigidbody>();

	private void GetChildRecursive(GameObject obj, Dictionary<string, Rigidbody> filleddict)
	{
		if (null == obj)
			return;

		foreach (Transform child in obj.transform)
		{
			if (null == child)
				continue;
			//child.gameobject contains the current child you can do whatever you want like add it to an array
			var rig = child.GetComponent<Rigidbody>();
			if (rig)
			{

				filleddict.Add(child.transform.name, rig);
			}

			GetChildRecursive(child.gameObject, filleddict);
		}
	}


	private bool isPressed = false;
	
	private void UpdateClicks()
	{
		if (Touch.activeFingers.Count == 1)
		{
			if(isPressed) return;
			Touch activeTouch = Touch.activeFingers[0].currentTouch;
			
			//Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");

			if (Camera.main != null)
			{
				//var pos2 = Mouse.current.position.ReadValue();
				var pos2 = Touch.activeFingers[0].screenPosition;
				Ray ray = Camera.main.ScreenPointToRay(pos2);
				if (!Physics.Raycast(ray, out var hit, 100.0f)) return;
				//StartCoroutine (ScaleMe_1 (hit.transform));
				Debug.Log("Hited: " + hit.transform.name); // ensure you picked right object
				StartCoroutine(ScaleMe(hit.transform));
			}

			isPressed = true;
		}

		if (Touch.activeFingers.Count == 0)
		{
			isPressed = false;
		}
	}

	IEnumerator ScaleMe(Transform objTr)
		{
			Debug.Log(objTr.name);
			Debug.Log(objTr.root.name);


			var force = Vector3.up * 15F + Vector3.left * (mLrValue * 2F);

			const float delay = 0.2f;

			Dictionary<string, Rigidbody> tmp = new Dictionary<string, Rigidbody>();


			if (objTr.root.name == currentPlayer.name)
			{
				tmp = _mAllRigidBodyes;
				Debug.Log("!!!!!!");
			}

			if (objTr.root.name == currentPlayer2.name)
			{
				tmp = _mAllRigidBodyes2;
				Debug.Log("!!!!!!");

			}


			if (tmp.ContainsKey(objTr.name))
			{
				Debug.Log("good key " + objTr.name);

				for (int i = 0; i < 5; i++)
				{
					//float _mass = m_AllRigidBodyes [objTr.name].mass;

					tmp[objTr.name].AddForce(force, ForceMode.Impulse);
					yield return new WaitForSeconds(delay);

				}
			}
		}

		void Awake()
		{
			EnhancedTouchSupport.Enable();
		}

		void Start()
		{
			RefreshRigidbodyes();
		}


		void Update()
		{
			UpdateClicks();

			if (Application.platform == RuntimePlatform.WindowsEditor ||
			    Application.platform == RuntimePlatform.OSXEditor)
			{
				if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
					mLrValue = -1F;
				if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
					mLrValue = 1F;
			}
			else
			{
				mLrValue = Accelerometer.current.acceleration.ReadValue().x;
			}
		}
	}


