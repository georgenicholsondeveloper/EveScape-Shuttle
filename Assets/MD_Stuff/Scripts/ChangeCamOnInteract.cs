using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamOnInteract : MonoBehaviour {

    public Canvas terminalDisplay;
    public Camera cam1, cam2;

	void Start () {
        terminalDisplay = gameObject.GetComponent<Canvas>();
	}
	
	void Update () {
		if (Input.GetKeyUp("x"))
        {
            cam1.enabled = true;
            cam2.enabled = false;
            terminalDisplay.worldCamera = cam1;
        }
        if (Input.GetKeyUp("z"))
        {
            cam1.enabled = false;
            cam2.enabled = true;
            terminalDisplay.worldCamera = cam2;
        }
    }
}
