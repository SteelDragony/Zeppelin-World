using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSight : MonoBehaviour {

    public List<GameObject> objectsInRange = new List<GameObject>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject && other.gameObject.GetComponent<Unit>())
        {
            objectsInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            objectsInRange.Remove(other.gameObject);
        }
    }
}
