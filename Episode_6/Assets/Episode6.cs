//Michdeakl
using UnityEngine;
using System.Collections;

public class Episode6 : MonoBehaviour {

	float roundStartTime;
	int waitTime;

	// Use this for initialization
	void Start () {
		print ("Press Spacebar when Time is up");
		SetNewRandomTime ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			float playerWaitTime = Time.time - roundStartTime;
			float error = Mathf.Abs (waitTime - playerWaitTime);

			string message = "";
			if (error < .15f) {
				message = "Brilliant";
			} else if (error < .75f) {
				message = "Great";
			} else if (error < 1.25f) {
				message = "OK";
			} else if (error < 1.75f) {
				message = "Shite";
			} else {
				message = "Get out of here";
			}

			print ("You waited for " + playerWaitTime + " seconds. That's " + error + " seconds off. " + message);
			SetNewRandomTime ();
		}
	}

	void SetNewRandomTime(){
		waitTime = Random.Range(5,21);
		roundStartTime = Time.time;
		print(waitTime + " seconds");
	}
}
