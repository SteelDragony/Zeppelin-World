using UnityEngine;
using System.Collections;

public class ProjectileWeapon : MonoBehaviour {

    public float cooldown = .2f;

    float prevShotTime = 0f;

    public GameObject projectile;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("Fire1") && prevShotTime + cooldown < Time.time)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            prevShotTime = Time.time;
        }
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
        Debug.Log(cross);
	}
}
