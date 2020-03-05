using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowOpen : MInheretance
{
    public GameObject part1, part2, part3;

    private int state = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !findCrowbar && forthPuzzleDone)
        {
            findCrowbar = true;
            updateQuestLog = true;
            questLogState = 7;
            print("hihi");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Input.GetKeyDown("e") && hasCrowBar)
            {
                state++;
                if (state == 1)
                    part1.SetActive(false);
                if (state == 2)
                    part2.SetActive(false);
                if (state == 3)
                    part3.SetActive(false);
                
            }
        }
    }
}

