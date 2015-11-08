using UnityEngine;
using System.Collections;

public class flight_test : MonoBehaviour {
	public float upforce = 50;
	private bool movew = false;
	private bool moves = false;
	private bool rotatea = false;
	private bool rotated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)){
			movew = true;
		}
		else{
			movew = false;
		}
		if(Input.GetKey(KeyCode.S)){
			moves = true;
		}
		else{
			moves = false;
		}
		if(Input.GetKey(KeyCode.A)){
			rotatea = true;
		}
		else{
			rotatea = false;
		}
		if(Input.GetKey(KeyCode.D)){
			rotated = true;
		}
		else{
			rotated = false;
		}
	}
	void FixedUpdate () {
		if(movew == true){
			gameObject.GetComponent<Rigidbody>().AddRelativeForce(0f,(1f * upforce),0f);
		}
		if(moves == true){
			gameObject.GetComponent<Rigidbody>().AddRelativeForce(0f,(-1f * upforce), 0f);
		}
		if(rotatea == true){
			gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0f,0f,(0.8f * upforce));
		}
		if(rotated == true){
			gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0f,0f,(-0.8f * upforce));
		}

	}

}
