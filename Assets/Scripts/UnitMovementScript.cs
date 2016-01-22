using UnityEngine;
using System.Collections;

public class UnitMovementScript : MonoBehaviour {

    public GameObject waypoint;

    public float force = 1000f;
    public float minTurnForce = 10f;
    public float turnforce = 200f;
    public float maxTurnForce = 200f;
    // rotate to face waypoint direction
    //int rotatedir = 0;


    // Use this for initialization
    public void Start()
    {
        waypoint = new GameObject("waypoint");
        waypoint.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.z = 0;
            waypoint.transform.position = pos;
        }
        */
    }

    void FixedUpdate()
    {
        Vector3 targetDelta = waypoint.transform.position - gameObject.transform.position;

        //get the angle between transform.forward and target delta
        float angleDiff = Vector3.Angle(gameObject.transform.up, targetDelta);


        // get its cross product, which is the axis of rotation to
        // get from one vector to the other
        Vector3 cross = Vector3.Cross(gameObject.transform.up, targetDelta);
        if (cross.z > 1) cross.z = 1;
        else if (cross.z < -1) cross.z = -1;
        Vector3 torque = cross - (gameObject.GetComponent<Rigidbody>().angularVelocity / 2) * angleDiff * turnforce;
        // apply torque along that axis according to the magnitude of the angle.
        float finalForce = angleDiff * turnforce;
        if(finalForce > maxTurnForce)
        {
            finalForce = maxTurnForce;
        }
        else if(finalForce < minTurnForce)
        {
            finalForce = minTurnForce;
        }
        gameObject.GetComponent<Rigidbody>().AddTorque(cross * finalForce);
        if (Mathf.Abs(targetDelta.x) > 1 || Mathf.Abs(targetDelta.y) > 1) gameObject.GetComponent<Rigidbody>().AddRelativeForce(0f, (1f * force), 0f);
    }
}
