using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualfx_Sound : MonoBehaviour {

    public static bool vfxsounds;
   

    //AudioSource audioData;

    public AudioClip thisound;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        vfxsounds = false;

        //audioData = GetComponent<AudioSource>();
        // audioData.Play(0);

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        Soundtrigger();
    }


    private void Playthissound()
    {
        {
            // audioData.UnPause();
            audioSource.PlayOneShot(thisound, 0.7F);
            vfxsounds = false;

        }
    }

    private void Soundtrigger ()
    {
        if(vfxsounds)
        {
            Playthissound();
        }
    }
}
