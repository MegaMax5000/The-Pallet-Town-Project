using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public static float slowMovementSpeed = 24;
	public static float fastMovementSpeed = slowMovementSpeed + (slowMovementSpeed / 2);
	public static float movementSpeed = slowMovementSpeed;
	public float turningSpeed = 60;
	public GameObject attackCapsule;
	public GameObject myself;
	public GameObject player;
	public int team = 2;
	public bool hit = false;
	float vertVelocity = 0;

	private static float duration = 0;
	private static float decision = -1;
	private static Vector3 waypoint;
	private static float determined = 0;
	private Animator anim;
	bool runAnim;
	public bool faint;
	public bool smallDam;

	void Start() {
		anim = GetComponent<Animator>();
		waypoint = player.transform.position;
		faint = false;
		smallDam = false;
	}

	void Update() {
		if (!faint) {
			if(!smallDam) {
				transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position)+1, transform.position.z);
				runAnim = false;

				if (duration <= 0) {
					if (determined <= 0) {
						decision = Mathf.Floor(Random.value * 5);
					}
					if (decision == 0) {
						if (determined <= 0) {
							determined = 100;
							waypoint.x = Random.insideUnitCircle.y * 20;
							waypoint.z = Random.insideUnitCircle.x * 20;
						}
						if(determined > 0) {
							transform.LookAt(waypoint);
							
							float forward = movementSpeed * Time.deltaTime;

							runAnim = true;

							transform.Translate(0, 0, forward);

							if (Vector3.Distance(waypoint, transform.position) < 4) {
								decision = 0;
							}
							determined = determined - 1;
						}
					} else if (decision == 1) {
						Battack1();
					} else if (decision == 2) {
						Battack2();
					} else if (decision == 3) {
						Battack3();
					} else if (decision == 4) {
						Battack4();
					} else {
						transform.LookAt(player.transform.position);

						float forward = movementSpeed * Time.deltaTime;
							runAnim = true;		

						transform.Translate(0, 0, forward);

						if (Vector3.Distance(player.transform.position, transform.position) < 20) {
							decision = 0;
						}
					}
				} else {
					duration = duration - 1;
				}
				 
				// Run Animation

				anim.SetBool ("RUN", runAnim);
			} else {
				StartCoroutine (smallDamage());
			}
		}

		// Health

		if (faint) {
			StartCoroutine(deadEnemy());
		}
	}

	void Battack1() {
		runAnim = false;
		if (determined <= 0) {
			determined = 500;
		}
		if (determined > 0) {
			determined = determined - 1;
			transform.LookAt(player.transform.position);
			
			float vertical = movementSpeed * Time.deltaTime;
			transform.Translate(0, 0, vertical);
			runAnim = true;
			if (Vector3.Distance(player.transform.position, transform.position) < 11) {
				if (Vector3.Distance(player.transform.position, transform.position) > 3) {
					StartCoroutine(attack1());
					determined = 0;
					decision = -1;
				} else {
					vertical = movementSpeed * Time.deltaTime;
					transform.LookAt(-player.transform.position);
					transform.Translate(0, 0, -vertical);
					runAnim = true;
				}
			} else {
				vertical = movementSpeed * Time.deltaTime;
				runAnim = true;
				transform.Translate(0, 0, vertical);
			}
		}
		anim.SetBool ("RUN", runAnim);

	}

	void Battack2() {
		runAnim = false;
		if (determined <= 0) {
			determined = 500;
		}
		if (determined > 0) {
			determined = determined - 1;
			transform.LookAt(player.transform.position);
			
			if (Vector3.Distance(player.transform.position, transform.position) < 25) {
				if (Vector3.Distance(player.transform.position, transform.position) > 16) {
					StartCoroutine(attack2());
					determined = 0;
					decision = -1;
				} else {
					float vertical = movementSpeed * Time.deltaTime;
					transform.LookAt(-player.transform.position);
					transform.Translate(0, 0, -vertical);
					runAnim = true;
				}
			} else {
				float vertical = movementSpeed * Time.deltaTime;
				runAnim = true;
				transform.Translate(0, 0, vertical);
			}
		}
		anim.SetBool ("RUN", runAnim);
	}

	void Battack3() {
		runAnim = false;
		if (determined <= 0) {
			determined = 500;
		}
		if (determined > 0) {
			determined = determined - 1;
			transform.LookAt(player.transform.position);
			
			if (Vector3.Distance(player.transform.position, transform.position) < 11) {
				if (Vector3.Distance(player.transform.position, transform.position) > 9) {
					StartCoroutine(attack3());
					determined = 0;
					decision = -1;
				} else {
					float vertical = movementSpeed * Time.deltaTime;
					runAnim = true;
					transform.LookAt(-player.transform.position);
					transform.Translate(0, 0, -vertical);
				}
			} else {
				float vertical = movementSpeed * Time.deltaTime;
				runAnim = true;
				transform.Translate(0, 0, vertical);
			}
		}
		anim.SetBool ("RUN", runAnim);

	}

	void Battack4() {
		runAnim = false;
		if (determined <= 0) {
			determined = 500;
		}
		if(determined > 0) {
			determined = determined - 1;
			transform.LookAt(player.transform.position);
			
			float vertical = movementSpeed * Time.deltaTime;
			runAnim = true;
			transform.Translate(0, 0, vertical);
			if (Vector3.Distance(player.transform.position, transform.position) < 2) {
				StartCoroutine(attack4());
				determined = 0;
				decision = -1;
			}
		}
		anim.SetBool ("RUN", runAnim);
	}

	IEnumerator deadEnemy() {
		anim.SetBool ("RUN", false);
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
		anim.SetBool ("SMALLDAMAGE", true);
		yield return new WaitForSeconds (0.25f);
		anim.SetBool ("SMALLDAMAGE", false);
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
}
