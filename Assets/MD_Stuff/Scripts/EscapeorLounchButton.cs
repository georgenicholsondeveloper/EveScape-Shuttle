using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeorLounchButton : MInheretance {

    public GameObject myCapsule;

    private GameObject mPart1, mPart2, mPart3;   
        
	void Start () {
        mPart1 = myCapsule.GetComponent<CrowOpen>().part1;
        mPart2 = myCapsule.GetComponent<CrowOpen>().part2;
        mPart3 = myCapsule.GetComponent<CrowOpen>().part3;

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasCrowBar && forthPuzzleDone && Input.GetKeyDown("e"))
            {
                mPart1.SetActive(true);
                mPart2.SetActive(true);
                mPart3.SetActive(true);
                fiftPuzzleDone = true;
                print("Fift Puzzle dooone");
            }
        }
    }

}
