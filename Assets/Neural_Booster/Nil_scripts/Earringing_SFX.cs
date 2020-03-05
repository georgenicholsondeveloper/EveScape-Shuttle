using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earringing_SFX : MonoBehaviour
{
    public static bool erSFX;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        erSFX= false;
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        Earring();
    }

    private void Earring()
    {
        if (erSFX)
        {
            audioData.UnPause();
        }
        else
        {
            audioData.Pause();
        }
    }
}