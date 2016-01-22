using UnityEngine;
using System.Collections;

public class mouseFollowScript : UnitMovementScript {

    public ProjectileWeapon[] weapons;

    new void Start()
    {
        base.Start();
        weapons = GetComponentsInChildren<ProjectileWeapon>();
    }

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButton(1))
		{
			Vector3 pos = Input.mousePosition;
			pos = Camera.main.ScreenToWorldPoint(pos);
			pos.z = 0;
			base.waypoint.transform.position = pos;
		}
        if(Input.GetMouseButton(0))
        {
            foreach (ProjectileWeapon weapon in weapons)
            {
                weapon.Fire();
            }
        }
	}

}
