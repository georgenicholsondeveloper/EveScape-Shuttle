using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToInduceState : MInheretance {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && thirdPuzzleDone)
        {
            print("stunZaBiss");
        }
    }
}
