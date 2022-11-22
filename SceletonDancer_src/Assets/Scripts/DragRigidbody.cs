﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
public class DragRigidbody : MonoBehaviour
{
	public float maxDistance = 100.0f;

	public float spring = 50.0f;
	public float damper = 5.0f;
	public float drag = 10.0f;
	public float angularDrag = 5.0f;
	public float distance = 0.2f;
	public bool attachToCenterOfMass = false;

	private SpringJoint springJoint;

	private void Awake()
	{
		EnhancedTouchSupport.Enable();
	}

	
	private bool isPressed = false;
	
	void Update ()
	{
		if (Touch.activeFingers.Count == 1)
		{
			if(isPressed) return;
			Touch activeTouch = Touch.activeFingers[0].currentTouch;
			//Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");
			
			
			Camera mainCamera = FindCamera (); 


			//var pos2 = Mouse.current.position.ReadValue();
			var pos2 = Touch.activeFingers[0].screenPosition;
			RaycastHit hit;
		
			Ray ray = mainCamera.ScreenPointToRay(pos2);
			if (!Physics.Raycast(ray, out hit, maxDistance)) {
				//Transform objectHit = hit.transform;
				// Do something with the object that was hit by the raycast.
				return;
			
			}
		
			if (!hit.rigidbody || hit.rigidbody.isKinematic)
				return; 

			if (!springJoint) { 
				GameObject go = new GameObject ("Rigidbody dragger"); 
				Rigidbody body = go.AddComponent<Rigidbody> (); 
				body.isKinematic = true; 
				springJoint = go.AddComponent<SpringJoint> (); 
			} 

			springJoint.transform.position = hit.point; 
			if (attachToCenterOfMass) { 
				Vector3 anchor = transform.TransformDirection (hit.rigidbody.centerOfMass) + hit.rigidbody.transform.position; 
				anchor = springJoint.transform.InverseTransformPoint (anchor); 
				springJoint.anchor = anchor; 
			} else { 
				springJoint.anchor = Vector3.zero; 
			} 

			springJoint.spring = spring; 
			springJoint.damper = damper; 
			springJoint.maxDistance = distance; 
			springJoint.connectedBody = hit.rigidbody; 

			StartCoroutine (DragObject (hit.distance)); 
		}
		if (Touch.activeFingers.Count == 0)
		{
			isPressed = false;
		}
	}

	IEnumerator DragObject (float distance)
	{ 
		float oldDrag = springJoint.connectedBody.drag; 
		float oldAngularDrag = springJoint.connectedBody.angularDrag; 
		springJoint.connectedBody.drag = this.drag; 
		springJoint.connectedBody.angularDrag = this.angularDrag; 
		Camera cam = FindCamera (); 

		while (Input.GetMouseButton (0)) { 
			Ray ray = cam.ScreenPointToRay (Input.mousePosition); 
			springJoint.transform.position = ray.GetPoint (distance); 
			yield return null; 
		} 

		if (springJoint.connectedBody) { 
			springJoint.connectedBody.drag = oldDrag; 
			springJoint.connectedBody.angularDrag = oldAngularDrag; 
			springJoint.connectedBody = null; 
		} 
	}

	Camera FindCamera ()
	{ 
		if (GetComponent<Camera>())
			return GetComponent<Camera>();
		else
			return Camera.main; 
	}
}