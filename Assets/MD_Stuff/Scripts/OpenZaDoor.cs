using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenZaDoor : MInheretance
{

    public bool SpecialCondition = false;
    public AudioSource OpenDoor;
    public AudioSource CloseDoor;

    private Animator doorAnim;


    private void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (firstPuzzleDone && SpecialCondition) 
                doorAnim.SetBool("character_nearby", true);
                
            if (!SpecialCondition)
                doorAnim.SetBool("character_nearby", true);

            if (firstPuzzleDone)
                OpenDoor.Play();
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("character_nearby", false);
            {
                if (firstPuzzleDone)
                {
                    CloseDoor.Play();
                }
            }
        }            
    }
}
