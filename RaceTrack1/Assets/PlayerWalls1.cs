using UnityEngine;
using System.Collections;

public class PlayerWalls1 : MonoBehaviour {
	public float speed = 10;
	Vector3 velocity;
	Rigidbody myRigidBody;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();	
		//transform.position = new Vector3 (10,3,60);
	}
	
	// Update is called once per frame
	void Update () {
		//Pass in axis as a string
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		//Normalize direction which object will move
		Vector3 direction = input.normalized;
		Vector3 velocity = direction * speed;
		Vector3 moveObject = velocity * Time.deltaTime;

		transform.position += moveObject;
	}

	void Update2(){
		myRigidBody.position += velocity * Time.fixedDeltaTime;
	}
}