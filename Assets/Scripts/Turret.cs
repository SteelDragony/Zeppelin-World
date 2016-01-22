using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    public float leftAngleLimit = 10;
    public float rightAngleLimit = -10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;
        Vector3 turretPos = transform.up;
        turretPos.z = 0;
        Vector3 targetDelta = transform.position - pos;
        targetDelta.z = 0;
        Vector3 cross = Vector3.Cross(turretPos, targetDelta);
        cross.Normalize();
        //cross = cross * 10;
        transform.Rotate(-cross);
        //Debug.Log(cross);
    }
}
