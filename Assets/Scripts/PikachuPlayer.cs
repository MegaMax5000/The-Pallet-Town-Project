using UnityEngine;
using System.Collections;

public class PikachuPlayer : MonoBehaviour {

	public static float slowMovementSpeed = 24;
	public static float fastMovementSpeed = slowMovementSpeed + (slowMovementSpeed / 2);
	public static float movementSpeed = slowMovementSpeed;
	public float upDownRange = 40.0f;
	public float mouseSpeed = 2.5f;
	float currForward = 0.0f; 
	float currSide = 0.0f;
	float forwardSpeed = 0.0f;
	float sideSpeed = 0.0f;
	float vertRot = 0;
	float vertVelocity = 0;
	public static float duration = 0;

	Animator anim;
	public Transform armature;
	bool runAnim;
	bool runBackAnim;
	bool runLeftAnim;
	bool runRightAnim;
	public bool faint;
	public bool smallDam;

	// Use this for initialization
	void Start () {

		Screen.lockCursor = true; 
		anim = GetComponent<Animator> ();

		faint = false;
		smallDam = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (!faint) {
			if(!smallDam) {
				// Rotation
				
				float rotLR = Input.GetAxis ("Mouse X") * mouseSpeed;
				transform.Rotate (0, rotLR, 0);
				
				vertRot -= Input.GetAxis ("Mouse Y") * mouseSpeed * 0.7f;
				vertRot = Mathf.Clamp (vertRot, -upDownRange, upDownRange);
				Camera.main.transform.localRotation = Quaternion.Euler (vertRot, 0, 0);
				
				// Movement
				
				CharacterController cc = new CharacterController (); 
				cc = GetComponent <CharacterController>();
				
				currForward = Input.GetAxis ("Vertical");
				currSide = Input.GetAxis ("Horizontal");
				
				if (Input.GetKey("left shift")) {
					movementSpeed = fastMovementSpeed;
				} else {
					movementSpeed = slowMovementSpeed;
				}
				
				forwardSpeed = currForward * movementSpeed * Time.deltaTime; 
				sideSpeed = currSide * movementSpeed * Time.deltaTime;
				
				vertVelocity += Physics.gravity.y * Time.deltaTime;
				
				Vector3 speed = new Vector3 (sideSpeed, vertVelocity, forwardSpeed);
				speed = transform.rotation * speed;
				if (!anim.GetBool("IDLE") && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")) {
					cc.Move(speed);
				} 
				
				// Attacks
				if (duration <= 0) {
					if (Input.GetKey("1")) {
						armature.localEulerAngles = new Vector3(-90, 0, -90);
						//StartCoroutine(gameObject.GetComponent<AttackPikachu>(duration).attack1());
					} else if (Input.GetKey("2")) {
						armature.localEulerAngles = new Vector3(-90, 0, -90);
						//gameObject.GetComponent<AttackPikachu>(duration).StartCoroutine(attack2());
					} else if (Input.GetKey("3")) {
						armature.localEulerAngles = new Vector3(-90, 0, -90);
						//gameObject.GetComponent<AttackPikachu>(duration).StartCoroutine(attack3());
					} else if (Input.GetKey("4")) {
						armature.localEulerAngles = new Vector3(-90, 0, -90);
						//gameObject.GetComponent<AttackPikachu>(duration).StartCoroutine(attack4());
					}
				} else {
					duration = duration - Time.deltaTime;
				}
				
				// Run Anim
				if (forwardSpeed != 0 || sideSpeed != 0) {
					anim.SetBool ("RUN", true);
					//forward
					if ((forwardSpeed > 0) && (sideSpeed == 0) && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") 
					    && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")) {
						armature.localEulerAngles = new Vector3(-90, 0, -90);
						
						//forward/right
					} else if ((forwardSpeed > 0)  && (sideSpeed > 0) && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") 
					           && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")) {
						armature.localEulerAngles = new Vector3(-90, 45, -90);
						
						//forward/left
					} else if ((forwardSpeed > 0)  && (sideSpeed < 0) && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") 
					           && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")) {
						armature.localEulerAngles = new Vector3(-90, -45, -90);
						
						//backward
					} else if ((forwardSpeed < 0)  && (sideSpeed == 0) && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") 
					           && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")) {
						armature.localEulerAngles = new Vector3(-90, 180, -90);
						
						//backward/right
					} else if ((forwardSpeed < 0)  && (sideSpeed > 0) && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") 
					           && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")) {
						armature.localEulerAngles = new Vector3(-90, 135, -90);
						
						//backward/left
					} else if ((forwardSpeed < 0)  && (sideSpeed < 0) && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") 
					           && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")) {
						armature.localEulerAngles = new Vector3(-90, 225, -90);
						
						//right
					} else if((forwardSpeed == 0)  && (sideSpeed > 0) && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") 
					          && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")){
						armature.localEulerAngles = new Vector3(-90, 90, -90);
						
						//left
					} else if((forwardSpeed == 0)  && (sideSpeed < 0) && !anim.GetBool ("ATTACK1") && !anim.GetBool ("ATTACK2") 
					          && !anim.GetBool ("ATTACK3") && !anim.GetBool ("ATTACK4")){
						armature.localEulerAngles = new Vector3(-90, -90, -90);
					}
				} else {
					anim.SetBool ("RUN", false);
				}
				
			} else {
				if(smallDam) {
					StartCoroutine (smallDamage());
				}
			}
		}
		// Health
		
		if (faint) {
			StartCoroutine(deadPlayer());
		}
		
	}

	IEnumerator deadPlayer() {
		anim.SetBool ("FAINT", true);
		yield return new WaitForSeconds (2.5f);
		Application.LoadLevel ("Menu");
	}
	
	IEnumerator smallDamage() {
		anim.SetBool ("RUN", false);
		anim.SetBool ("ATTACK1", false);
		anim.SetBool ("ATTACK2", false);
		anim.SetBool ("ATTACK3", false);
		anim.SetBool ("ATTACK4", false);
		//anim.SetBool ("SMALLDAMAGE", true);
		yield return new WaitForSeconds (0.25f);
		//anim.SetBool ("SMALLDAMAGE", false);
		smallDam = false;
	}
}
