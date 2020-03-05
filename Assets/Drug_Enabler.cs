using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug_Enabler : MInheretance {


	void Update () {

        SwitchthisBitch();
	}

    public void SwitchthisBitch ()
    {
        
            if (tripeffect)
            {
                this.GetComponent<Motion_Blur>().enabled = false;
                this.GetComponent<Drugtrippyness>().enabled = true;
            }
            else
            {
                this.GetComponent<Motion_Blur>().enabled = true;
                this.GetComponent<Drugtrippyness>().enabled = false;
            }
        
    }
}
