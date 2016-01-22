using UnityEngine;
using System.Collections;

public class FighterAI : MonoBehaviour {

    public enum behaviourState
    {
        attackRun,
        getDistance,
        flee,
        searchTarget
    }

    public behaviourState currentBehaviour = behaviourState.searchTarget;

    Unit unit;
    UnitMovementScript movementScript;

    public ProjectileWeapon[] weapons;

    public Transform currentTarget = null;


	// Use this for initialization
	void Start () {
        unit = GetComponent<Unit>();
        movementScript = GetComponent<UnitMovementScript>();
        weapons = GetComponentsInChildren<ProjectileWeapon>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!currentTarget)
        {
            currentBehaviour = behaviourState.searchTarget;
        }
        switch (currentBehaviour)
        {
            case behaviourState.attackRun:
                if(Vector3.Distance(transform.position, currentTarget.position) < 10)
                {
                    currentBehaviour = behaviourState.getDistance;
                }
                else
                {
                    movementScript.waypoint.transform.position = currentTarget.position;
                    foreach (ProjectileWeapon weapon in weapons)
                    {
                        weapon.Fire();
                    }
                }
                break;
            case behaviourState.getDistance:
                movementScript.waypoint.transform.position = transform.position + (transform.position - currentTarget.position).normalized * 50;
                if(Vector3.Distance(transform.position, currentTarget.position) > 20)
                {
                    currentBehaviour = behaviourState.attackRun;
                }
                break;
            case behaviourState.flee:
                break;
            case behaviourState.searchTarget:
                if(currentTarget)
                {
                    currentBehaviour = behaviourState.attackRun;
                }
                break;
            default:
                break;
        }

    }
}
