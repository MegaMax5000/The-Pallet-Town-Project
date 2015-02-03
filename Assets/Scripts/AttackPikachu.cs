using UnityEngine;
using System.Collections;

public class AttackPikachu : MonoBehaviour {

	Animator anim;
	public GameObject attackCapsule;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	IEnumerator attack1() {
		//player.GetComponent<PikachuPlayer>().duration = 20;
		
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
		//player.GetComponent<duration>() = 30;
		
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
		//player.GetComponent<duration>() = 60;
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
		//player.GetComponent<duration>() = 100;
		
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
