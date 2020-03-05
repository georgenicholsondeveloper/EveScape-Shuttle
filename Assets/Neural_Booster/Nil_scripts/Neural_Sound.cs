using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(AudioSource))]
public class Neural_Sound : MonoBehaviour
{
    public static bool hbSFX;
    public AudioClip heartsound;
    //AudioSource audioData;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        hbSFX = false;
        // audioData = GetComponent<AudioSource>();
        // audioData.Play(0);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Heartbeat();
        Playheartbeat();
    }

    private void Heartbeat()
    {
        if(hbSFX)
        {
           // audioData.UnPause();
            audioSource.PlayOneShot(heartsound, 1F);
            hbSFX = false;
        }
        else
        {
            //audioData.Pause();
        }
    }

    private void Playheartbeat()
    {
        if(hbSFX)
        {
            Heartbeat();
        }
    }
}
