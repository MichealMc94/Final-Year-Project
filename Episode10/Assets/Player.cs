using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10;
	Vector3 velocity;
	Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 direction = input.normalized;
		velocity = direction * speed;
	}


	void FixedUpdate(){
		myRigidBody.position += velocity * Time.fixedDeltaTime;

	}	

	void OnTriggerEnter(Collider triggerCollider){
		print (triggerCollider.gameObject.name);
	}
}

