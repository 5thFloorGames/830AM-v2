using UnityEngine;
using System.Collections;

public class WalkingSoundOnOff : MonoBehaviour {

	bool isWalking = false;
	bool hasBeenWalking = false;
	public float stopSpeed = 0.25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		Rigidbody body = GetComponent<Rigidbody> ();

		if (body.velocity.magnitude > stopSpeed) {
			isWalking = true;
		} else {

			isWalking = false;
			hasBeenWalking = false;

			GameObject footSteps = GameObject.Find("FootstepSounds");
			
			if (footSteps){
				AudioSource audio = footSteps.GetComponent<AudioSource>();
				audio.Stop();
			}
		}

		if (isWalking) {

			if (!hasBeenWalking) {

				GameObject footSteps = GameObject.Find("FootstepSounds");

				if (footSteps){
					AudioSource audio = footSteps.GetComponent<AudioSource>();
					audio.Play();
				}

				hasBeenWalking = true;
			}
		}

	}
}
