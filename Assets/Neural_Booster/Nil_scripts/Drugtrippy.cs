using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Drugtrippy : MonoBehaviour {


    public GameObject fpscamera;
    public PostProcessingProfile drugtripvfx;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Druggy")
        {
            fpscamera.GetComponent<Motion_Blur>().enabled = false;
            fpscamera.GetComponent<PostProcessingBehaviour>().profile = drugtripvfx;
            print("yeet");

        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Druggy")
        {
            fpscamera.GetComponent<Motion_Blur>().enabled = true;

        }
    }

}
