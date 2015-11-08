using UnityEngine;
using System.Collections;

public class City_Script : MonoBehaviour {

	private int traderesource = 10;
	private int money = 200;
	private bool docked = false;

	public flight_test test;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per fSrame
	void Update () {
        if(Input.GetButtonDown("Cancel"))
        {
            docked = false;
            Time.timeScale = 1f;
        }
	}

	void OnTriggerEnter(Collider other) {
		docked = true;
        Time.timeScale = 0f;
	}

    /*
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "Loader Menu");

		if(docked == true){
			if(GUI.RepeatButton(new Rect(20,40,80,20), "buy stuf $10")) {
				traderesource ++;
				money -= 10;
			}
			
			// Make the second button.
			if(GUI.RepeatButton(new Rect(20,70,80,20), "sell stuf $8")) {
				traderesource --;
				money += 8;
			}
		}

		GUI.Box(new Rect(10, 110, 100, 40), traderesource.ToString());
		GUI.TextArea(new Rect(10, 150, 100, 40), money.ToString());
	}
    */
}
