using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_thingy : MInheretance {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Explosionbegin();
	}

    public void Explosionbegin()
    {
        if (Terminalexplosion)
        {
            this.GetComponent<Terminal_shake>().enabled = true;
        }
        else
        {
            this.GetComponent<Terminal_shake>().enabled = false;
        }
    }
}
