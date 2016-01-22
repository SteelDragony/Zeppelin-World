using UnityEngine;
using System.Collections;

public class ProjectileWeapon : MonoBehaviour {

    public float cooldown = .2f;
    public float inaccuracy = 10f;

    float prevShotTime = 0f;

    public Unit unit;

    public GameObject projectile;
	// Use this for initialization
	void Start () {
        unit = GetComponentInParent<Unit>();
	}
	
    public void Fire()
    {
        if (prevShotTime + cooldown < Time.time)
        {
            GameObject shot = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            shot.GetComponent<Projectile>().side = unit.side;
            shot.transform.Rotate(new Vector3(0f, 0f, Random.Range(-inaccuracy, inaccuracy)));
            prevShotTime = Time.time;
        }
    }

	// Update is called once per frame
	void Update () {


	}
}
