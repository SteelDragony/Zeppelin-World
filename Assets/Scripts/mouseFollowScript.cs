using UnityEngine;
using System.Collections;

public class mouseFollowScript : MonoBehaviour {

	GameObject playerWp;
	GameObject Zeppelin;
	public Transform target;
	public float force = 1000f;
	public float turnforce = 200f;
	// rotate to face waypoint direction
	//int rotatedir = 0;


	// Use this for initialization
	void Start () 
	{
		playerWp = new GameObject("playerWp");
		//Zeppelin = GameObject.Find("Zeppelin");
		Zeppelin = gameObject;
		Instantiate( Resources.Load("Fighter"), this.transform.position, this.transform.rotation); //works
	}
	
	// Update is called once per frame
	void Update () 
	{
		//this.gameObject.transform

		/*if(this.transform.position.y <= playerWp.transform.position.y){
			if(this.transform.position.x <= playerWp.transform.position.x){
				deltaX = (Mathf.Abs(this.transform.position.x - playerWp.transform.position.x));
				deltaY = (Mathf.Abs(this.transform.position.y - playerWp.transform.position.y));
				
				targetHeading = Mathf.Atan((deltaY/deltaX)) + Mathf.PI*1.5f;
			}
			else{
				deltaX = (Mathf.Abs(this.transform.position.x - playerWp.transform.position.x));
				deltaY = (Mathf.Abs(this.transform.position.y - playerWp.transform.position.y));
				
				targetHeading = Mathf.Atan((deltaX/deltaY));
			}

		}
		else{
			if(this.transform.position.x <= playerWp.transform.position.x){
				deltaX = (Mathf.Abs(this.transform.position.x - playerWp.transform.position.x));
				deltaY = (Mathf.Abs(this.transform.position.y - playerWp.transform.position.y));
				
				targetHeading = Mathf.Atan((deltaX/deltaY)) + Mathf.PI;
			}
			else{
				deltaX = (Mathf.Abs(this.transform.position.x - playerWp.transform.position.x));
				deltaY = (Mathf.Abs(this.transform.position.y - playerWp.transform.position.y));
				
				targetHeading = Mathf.Atan((deltaY/deltaX)) + Mathf.PI* 0.5f;
			}

		}

		if(this.transform.rotation.z >= Mathf.Rad2Deg * targetHeading){
			Zeppelin.rigidbody.AddRelativeTorque(0f,0f,(5000f));
			print("+");
			print(("Heading = " + Mathf.Rad2Deg*targetHeading));
			print(("Zep = " + this.transform.rotation.a);
		}
		if(this.transform.rotation.z < Mathf.Rad2Deg * targetHeading){
			Zeppelin.rigidbody.AddRelativeTorque(0f,0f,(-5000f));
			print("-");
			print(("Heading = " + Mathf.Rad2Deg*targetHeading));
			print(("Zep = " + this.transform.rotation.z));
		}
		*/
		if(Input.GetMouseButton(0))
		{
			Vector3 pos = Input.mousePosition;
			pos = Camera.main.ScreenToWorldPoint(pos);
			pos.z = 0;
			playerWp.transform.position = pos;
		}
	}

	void FixedUpdate()
	{
		Vector3 targetDelta = playerWp.transform.position - Zeppelin.transform.position;

		//get the angle between transform.forward and target delta
		float angleDiff = Vector3.Angle(Zeppelin.transform.up, targetDelta); 


		// get its cross product, which is the axis of rotation to
			// get from one vector to the other
		Vector3 cross = Vector3.Cross(Zeppelin.transform.up, targetDelta);
		if ( cross.z > 1) cross.z = 1;
		else if (cross.z < -1) cross.z = -1;
		Vector3 torque = cross - (Zeppelin.GetComponent<Rigidbody>().angularVelocity/2) * angleDiff * turnforce;
			// apply torque along that axis according to the magnitude of the angle.
		Zeppelin.GetComponent<Rigidbody>().AddTorque(cross * angleDiff * turnforce);
		if(Mathf.Abs (targetDelta.x) > 1 || Mathf.Abs (targetDelta.y) > 1) gameObject.GetComponent<Rigidbody>().AddRelativeForce(0f,(1f * 3000),0f);
		// wip rotate to face waypoint with physics
		//transform.parent.gameObject.rigidbody.AddTorque(0f,(1f * rotatedir,0f)
	}
}
