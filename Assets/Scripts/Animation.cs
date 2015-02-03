// This REALLY needs a coding makeover (john) but should make it easy to figure out
// what is going on with animations and such. Right now the animation only plays as 
// long as you hold down the button. This is fine for running but for attacks we want
// to play the one loop of the entire animation regardless of how long the button is held. 
// I am going to the gym so I cannot do that right now.....john....

//*******************IRRELEPHANT************************//



using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {
	Animator anim;
	bool run;
	bool attack1;
	bool attack2;
	bool attack3;
	bool attack4;
	bool smallDam;
	bool bigDam;
	bool faint;
	
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Vertical") > 0) {
			run = true;
		} else {
			run = false;
		}
		anim.SetBool ("RUN", run);


		if (Input.GetKey(KeyCode.Alpha1)) {
			attack1 = true;
		} else {
			attack1 = false;
		}
		anim.SetBool ("ATTACK1", attack1);


		if (Input.GetKey(KeyCode.Alpha2)) {
			attack2 = true;
		} else {
			attack2 = false;
		}
		anim.SetBool ("ATTACK2", attack2);


		if (Input.GetKey(KeyCode.Alpha3)) {
			attack3 = true;
		} else {
			attack3 = false;
		}
		anim.SetBool ("ATTACK3", attack3);


		if (Input.GetKey(KeyCode.Alpha4)) {
			attack4 = true;
		} else {
			attack4 = false;
		}
		anim.SetBool ("ATTACK4", attack4);
	}
}
