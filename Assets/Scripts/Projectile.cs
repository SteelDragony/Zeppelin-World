using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 10f;
    public float lifetime = 10f;
    float timeSpawned;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        timeSpawned = Time.time;
        transform.Rotate(new Vector3(0f, 0f, Random.Range(-10f, 10f)));
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
}
