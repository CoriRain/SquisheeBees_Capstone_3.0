using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableScript : MonoBehaviour {

	//Calls its own rigidbody
	Rigidbody ownRB;

	//Sets up a Original Position and an original rotation
	Vector3 oriPos;
	Quaternion oriRot;


	// Use this for initialization
	void Start () {

		oriPos = transform.position;
		oriRot = transform.rotation;
		ownRB = this.gameObject.GetComponent<Rigidbody> ();
		ownRB.isKinematic = true;
		
	}
	
	// FixedUpdate
	void FixedUpdate () {


		
	}

	public void SetVelocity_PutDown (Vector3 newVelocity)
	{
		transform.position = oriPos;
		transform.rotation = oriRot;
		ownRB.velocity = newVelocity;

	}
		
}
