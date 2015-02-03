using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	public GameObject attackCapsule;
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
	float xStart;
	float yStart;
	float zStart;
	private float duration = 0;

	Animator anim;
	public Transform armature;
	bool runAnim;
	bool runBackAnim;
	bool runLeftAnim;
	bool runRightAnim;
	public bool faint;
	public bool smallDam;
	public static bool pause = false;

	// Use this for initialization
	void Start () {
		
		Screen.lockCursor = true; 
		anim = GetComponent<Animator> ();

		xStart = transform.position.x;
		yStart = transform.position.y;
		zStart = transform.position.z;

		faint = false;
		smallDam = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (!faint) {
			if(!smallDam) {
				// Rotation

				if (Input.GetKey("escape") || Input.GetKey("p")) {
					pause = true;
				}
				if (pause) {
					Time.timeScale = 0;
				} else {
					Time.timeScale = 1;
				}
				if (!pause) {
					float rotLR = Input.GetAxis ("Mouse X") * mouseSpeed;
					transform.Rotate (0, rotLR, 0);

					vertRot -= Input.GetAxis ("Mouse Y") * mouseSpeed * 0.7f;
					vertRot = Mathf.Clamp (vertRot, -upDownRange, upDownRange);
					Camera.main.transform.localRotation = Quaternion.Euler (vertRot, 0, 0);
				}
				// Movement

				CharacterController cc = new CharacterController (); 
				cc = GetComponent <CharacterController>();

				currForward = Input.GetAxis ("Vertical");
				currSide = Input.GetAxis ("Horizontal");

				if (Input.GetKey("left shift")) {
					movementSpeed = fastMovementSpeed;
					anim.SetBool ("RUNFAST", true);
				} else {
					movementSpeed = slowMovementSpeed;
					anim.SetBool ("RUN", true);
					anim.SetBool ("RUNFAST", false);
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
						StartCoroutine(attack1());
					} else if (Input.GetKey("2")) {
						armature.localEulerAngles = new Vector3(-90, 0, -90);
						StartCoroutine(attack2());
					} else if (Input.GetKey("3")) {
						armature.localEulerAngles = new Vector3(-90, 0, -90);
						StartCoroutine(attack3());
					} else if (Input.GetKey("4")) {
						armature.localEulerAngles = new Vector3(-90, 0, -90);
						StartCoroutine(attack4());
					}
				} else {
					duration = duration - 1;
				}

				// Run Anim
				if (forwardSpeed != 0 || sideSpeed != 0) {

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
					anim.SetBool ("RUNFAST", false);
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

	IEnumerator attack1() {
		duration = 20;

		anim.SetBool ("ATTACK1", true);
	
		yield return new WaitForSeconds(0.5f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 3, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 5, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 7, Quaternion.identity);

		anim.SetBool ("ATTACK1", false);

		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 9, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 11, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 13, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 15, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 17, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 19, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 21, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 23, Quaternion.identity);
	}
	IEnumerator attack2() {
		duration = 30;

		anim.SetBool ("ATTACK2", true);

		yield return new WaitForSeconds (0.4f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 16, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 17, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 18, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 18 - transform.right * 2, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 22 - transform.right * 2, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 19 + transform.right * 1, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 19 - transform.right * 1, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 20, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 21 + transform.right * 1, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 21 - transform.right * 1, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 18 + transform.right * 2, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 22 + transform.right * 2, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 22, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 23, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 24, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 20 - transform.right * 2, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 20 - transform.right * 3, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 20 - transform.right * 4, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 20 + transform.right * 2, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 20 + transform.right * 3, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 20 + transform.right * 4, Quaternion.identity);
		yield return new WaitForSeconds (0.5f);

		anim.SetBool ("ATTACK2", false);
	}
	IEnumerator attack3() {
		duration = 60;
		anim.SetBool ("ATTACK3", true);

		CharacterController cc = new CharacterController (); 
		cc = GetComponent <CharacterController>();
		Vector3 speed = new Vector3 (0, 0, 10.0f);

		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 1, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 2, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 3, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 4, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 5, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 6, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 7, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 8, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 9, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 10, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 11, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 12, Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		cc.Move(transform.rotation * speed);

		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("ATTACK3", false);
	}
	IEnumerator attack4() {
		duration = 100;
		
		anim.SetBool ("ATTACK4", true);
		
		yield return new WaitForSeconds (0.4f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 6, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 3, Quaternion.identity);
		yield return new WaitForSeconds (0.025f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 4 + transform.right * 4, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 2 + transform.right * 2, Quaternion.identity);
		yield return new WaitForSeconds (0.025f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 0 + transform.right * 6, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 0 + transform.right * 3, Quaternion.identity);
		yield return new WaitForSeconds (0.025f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * -4 + transform.right * 4, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * -2 + transform.right * 2, Quaternion.identity);
		yield return new WaitForSeconds (0.025f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * -6 + transform.right * 0, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * -3 + transform.right * 0, Quaternion.identity);
		yield return new WaitForSeconds (0.025f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * -4 + transform.right * -4, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * -2 + transform.right * 2, Quaternion.identity);
		yield return new WaitForSeconds (0.025f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 0 + transform.right * -6, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 0 + transform.right * -6, Quaternion.identity);
		yield return new WaitForSeconds (0.025f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 4 + transform.right * -4, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 2 + transform.right * -2, Quaternion.identity);
		yield return new WaitForSeconds (0.025f);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 6 + transform.right * 0, Quaternion.identity);
		Instantiate(attackCapsule, transform.position + transform.up * 2 + transform.forward * 3 + transform.right * 0, Quaternion.identity);
		
		yield return new WaitForSeconds (0.05f);
		anim.SetBool ("ATTACK4", false);

	}

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "KillZone") {

			transform.position = new Vector3 (xStart, yStart, zStart);

		} else if (other.gameObject.tag == "Finish1") {

			xStart = 128.0f;
			yStart = 126.0f;
			zStart = 403.0f;

			transform.position = new Vector3 (xStart, yStart, zStart);
		
		} else if (other.gameObject.tag == "Enemy") {

			transform.position = new Vector3 (xStart, yStart, zStart);

		}
	}
}
