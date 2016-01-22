using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public float health = 10f;
    public float armour = 2f;
    public int side = 0;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
    
    void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.gameObject.GetComponent<Projectile>();
        if(projectile && projectile.side != side)
        {
            if (projectile.damage + projectile.armourPiercing > armour)
            {
                health -= projectile.damage - (armour - projectile.armourPiercing);
            }
            projectile.Hit();
        }
    }
}
