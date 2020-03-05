using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Drugtrippyness : MInheretance {


    public PostProcessingProfile druggypussy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        FuckMeUp();
	}


    private void FuckMeUp()
    {
        if(tripeffect)
        {
            this.GetComponent<Motion_Blur>().enabled = false;
            this.GetComponent<PostProcessingBehaviour>().profile = druggypussy;
        }
        else
        {
            this.GetComponent<Motion_Blur>().enabled = true;
        }
    }
}
