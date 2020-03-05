using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4 : MInheretance {

    public bool isLit = false;
    public GameObject[] adjPanels;
	
	void Start () {
        isLit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && litPanels < 24)
        {
            isLit = !isLit;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            foreach (GameObject panel in adjPanels)
            {
                if (panel.GetComponent<Renderer>().material.color == Color.green)
                {
                    panel.GetComponent<Renderer>().material.color = Color.white;
                    panel.GetComponent<Puzzle4>().isLit = false;
                    litPanels--;
                }
                else
                {
                    panel.GetComponent<Renderer>().material.color = Color.green;
                    panel.GetComponent<Puzzle4>().isLit = true;
                    litPanels++;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLit) { gameObject.GetComponent<Renderer>().material.color = Color.green; litPanels++; }
            else { gameObject.GetComponent<Renderer>().material.color = Color.white; litPanels--; }
            if (litPanels >= 24 && !forthPuzzleDone)
            {
                forthPuzzleDone = true;
                print("4TH PUZZLE DONE");
            }
        }

    }

}
