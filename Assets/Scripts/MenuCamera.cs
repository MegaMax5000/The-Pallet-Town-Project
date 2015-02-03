using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour {
	float time;
	float rotUD;
	float rotLR;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float rotLRSpeed = 10.0f;
		float rotUDSpeed = 20.0f;
		time += Time.deltaTime;
		rotLR = rotLRSpeed * time;
		rotUD = rotUDSpeed * Mathf.Sin (time);
		Camera.main.transform.localRotation = Quaternion.Euler (rotUD, rotLR, 0);;
	}
}
