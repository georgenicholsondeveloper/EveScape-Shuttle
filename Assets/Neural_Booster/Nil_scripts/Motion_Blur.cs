using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;


public class Motion_Blur : MonoBehaviour {

    public static bool activeNB;
    public static bool activeG;
    public static bool activeBO;
    public static bool activeIB;
    public static bool activeFB;
    public PostProcessingProfile emptyprofile;
    public PostProcessingProfile motionblurprofile;
    public PostProcessingProfile grainsprofile;
    public PostProcessingProfile blackoutprofile;
    public PostProcessingProfile imageprofile;
    public PostProcessingProfile flashbangprofile;


    // Start is called before the first frame update
    void Start()
    {
        activeNB = false;
        activeG = false;
        activeBO = false;
        activeIB = false;
        activeFB = false;
    }

    // Update is called once per frame
    void Update()
    {
        Motionblur();
        Grains();
        Blacked();
        Blinking();
        Empty();
        Flashbanging();


    }

    private void Motionblur()
    {
        if (activeNB)
        {
            this.GetComponent<PostProcessingBehaviour>().profile = motionblurprofile;

        }

    }

    private void Grains()
    {
        if (activeG)
        {
            this.GetComponent<PostProcessingBehaviour>().profile = grainsprofile;


        }
    }

    private void Blacked()
    {
        if (activeBO)
        {
            this.GetComponent<PostProcessingBehaviour>().profile = blackoutprofile;


        }

    }

    private void Blinking()
    {
        if (activeIB)
        {
            this.GetComponent<PostProcessingBehaviour>().profile = imageprofile;
        }
    }

    private void Flashbanging()
    {
        if (activeFB)
        {
            this.GetComponent<PostProcessingBehaviour>().profile = flashbangprofile;
            
        }
    }


    private void Empty()
    {
        if (!activeNB && !activeG && !activeBO && !activeIB && !activeFB)
        {
            this.GetComponent<PostProcessingBehaviour>().profile = emptyprofile;
        }
    }

   

 


}

