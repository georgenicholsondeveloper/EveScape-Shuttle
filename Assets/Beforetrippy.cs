using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Beforetrippy : MInheretance {

    public PostProcessingProfile Blackoutzeee;

    private float timzeerfyawfwsej = 0;

    private bool wtfman;
    
    // Use this for initialization
    void Start () {
        wtfman = false;
   
    }
	
	// Update is called once per frame
	void Update () {

       
	}

    public void Testicle ()
    {
        if(pickedGasMask)
        {
            timzeerfyawfwsej = Time.time + 2;
            wtfman = true;
        }
    }


    public void Ballsacks ()
    {
        if(wtfman && Time.time >= timzeerfyawfwsej)
        {
            this.GetComponent<Motion_Blur>().enabled = false;
            this.GetComponent<PostProcessingBehaviour>().profile = Blackoutzeee;

        }
    }



  



}
