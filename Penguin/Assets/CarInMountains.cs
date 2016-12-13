using UnityEngine;
using System.Collections;

public class CarInMountains : MonoBehaviour {


	public float speed = 10;
	Vector3 velocity;
	Rigidbody myRigidBody;
	Vector3 rotation;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();	//Gets a reference to the gameobjects rigidbody
	}

	// Update is called once per frame
	void Update () {
		Vector3 input = new Vector3 (0, 0, Input.GetAxisRaw ("Vertical"));	//Gets the vertical axis
		Vector3 direction = input.normalized;								//Normalizes the dorection
		float carRotation = Input.GetAxisRaw ("Horizontal");				//Gets the horizontal axis for rotation
		rotation = new Vector3(0, carRotation, 0);							//Makes a Vector3 out of the rotation

		velocity = direction * speed;
	}

	void FixedUpdate(){
		if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))				//Determines when to apply forward force in direction car is facing
			myRigidBody.position += transform.forward + velocity * Time.fixedDeltaTime;		//Increases the rigidBodies position in the direction the car is facing
		if(Input.GetKey("s")  || Input.GetKey(KeyCode.DownArrow))			//Determines when to apply backwards force
			myRigidBody.position += (transform.forward*-1) + velocity * Time.fixedDeltaTime;	//Decreases the rigidBodies position in the direction the car is facing
		Rotate ();

	}	

	void OnTriggerEnter(Collider triggerCollider){
		print (triggerCollider.gameObject.name);
	}


	//Rotates the car by making the rotation into a Euler angle, Unity takes care of the complex maths here
	void Rotate()
	{
		myRigidBody.MoveRotation (myRigidBody.rotation * Quaternion.Euler (rotation));

	}
		
}
