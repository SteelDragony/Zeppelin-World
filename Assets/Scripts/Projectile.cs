using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 10f;
    public float lifetime = 10f;
    public float damage = 5f;
    public float armourPiercing = 0f;

    float timeSpawned;
    public int side = 0;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        timeSpawned = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(timeSpawned + lifetime < Time.time  )
        {
            Destroy(gameObject);
        }
	}

    void FixedUpdate()
    {
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
