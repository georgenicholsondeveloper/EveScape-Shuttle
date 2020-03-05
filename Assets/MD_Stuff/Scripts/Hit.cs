using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hit : MInheretance {

    public Material[] padKeysMat;
    public GameObject[] displayKey;
    public Color mPurple;

    private Animator doorOpen;
    private Camera fpsCam;
    private Vector3 castFrom = new Vector3(0.5f, 0.5f, 0);
    private Material keyNormal, keyOutlined;
    private Color outlineColor;
    private Renderer rend = null;
    private Collider hitKey = null;
    private GameObject keyPadDisplay;
    private string enteredCode = "";
    private int keysInputted = 0;
    private float kDisplayToNormal;
    private bool fixBlue;
    public AudioSource DoorSound;
    

    private void Awake()
    {
        fpsCam = gameObject.GetComponent<Camera>();
        outlineColor = Color.black;
        doorOpen = GameObject.Find("FAnimDoor").GetComponent<Animator>();
        keyPadDisplay = GameObject.Find("KeyPadDisplay");

        int perfectNumber = 0;
        int code = 0;
        int[] dig = new int[] {0,0,0,0};
        while (perfectNumber != 2) //getting a random keypad 4 digit code, each digit being unique
        {
            if (perfectNumber == 0)
            {
                code = Random.Range(0, 9);
                keyPadCode = code.ToString();
                Renderer fRend = GameObject.Find("FirstKeyInLvl").GetComponent<Renderer>();
                fRend.material = padKeysMat[code];
                dig[0] = code;
                perfectNumber++;
            }
            else
            {
                for (int i = 1; i < dig.Length; i++)
                {
                    code = Random.Range(0, 9);
                    dig[i] = code;
                }
                if (dig[0] != dig[1] && dig[0] != dig[2] && dig[0] != dig[3] && dig[1] != dig[2] && dig[1] != dig[3] && dig[2] != dig[3])
                {
                    for(int i = 1; i < dig.Length; i++)
                    {
                        keyPadCode += dig[i];
                    }
                    perfectNumber++;
                }
            }
        }
        print(keyPadCode);
    }

    void Update () {
        MaMain();
	}

    void MaMain()
    {
        if (canType && !firstPuzzleDone) //first puzzle
        {
            KeyPadRayCheck();
            InputKeyCode();
        }
        NeuralBoosterTaken();
    }

    private void KeyPadRayCheck() //casting a ray from fpscam 
    {
        RaycastHit hit;
        Renderer hRend;
        Ray ray = fpsCam.ViewportPointToRay(castFrom);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider);
            if (hit.collider.tag.Contains("Key") && Input.GetMouseButton(0) && keysInputted < 4 || hit.collider.tag.Contains("Button") && Input.GetMouseButton(0))
            {
                hRend = hit.collider.gameObject.GetComponent<Renderer>();
                if (hRend == rend) { return; }
                if (hRend && hRend != rend)
                {
                    if (rend)
                    {
                        rend.sharedMaterial = keyNormal;
                    }
                }
                if (hRend) { rend = hRend; }
                else { return; }

                keyNormal = rend.sharedMaterial;
                keyOutlined = new Material(keyNormal);
                rend.material = keyOutlined;
                rend.material.color = outlineColor;
            }

            else
            {
                if (rend)
                {
                    rend.sharedMaterial = keyNormal;
                    rend = null;
                }
            }

            if (Input.GetMouseButtonUp(0) && hit.collider.tag.Contains("Key") && keysInputted < 4 || Input.GetMouseButtonUp(0) && hit.collider.tag.Contains("Button"))
            {
                hitKey = hit.collider;
                keysInputted++;
            }
        }
    }

    private void InputKeyCode() //if ray hits keys get the inputted key
    {
        if (canUseNeural && fixBlue && Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < 9; i++)
            {
                string kstr = "Key" + i;
                GameObject.FindGameObjectWithTag(kstr).GetComponent<Renderer>().material.color = Color.white;
            }
            fixBlue = false;
        }
        int index = -1;
        if (hitKey)
        {
            if (hitKey.CompareTag("Key0")) { enteredCode += "0"; index = 0; }
            if (hitKey.CompareTag("Key1")) { enteredCode += "1"; index = 1; }
            if (hitKey.CompareTag("Key2")) { enteredCode += "2"; index = 2; }
            if (hitKey.CompareTag("Key3")) { enteredCode += "3"; index = 3; }
            if (hitKey.CompareTag("Key4")) { enteredCode += "4"; index = 4; }
            if (hitKey.CompareTag("Key5")) { enteredCode += "5"; index = 5; }
            if (hitKey.CompareTag("Key6")) { enteredCode += "6"; index = 6; }
            if (hitKey.CompareTag("Key7")) { enteredCode += "7"; index = 7; }
            if (hitKey.CompareTag("Key8")) { enteredCode += "8"; index = 8; }
            if (hitKey.CompareTag("Key9")) { enteredCode += "9"; index = 9; }
            print(enteredCode);
            if (hitKey.CompareTag("CancelButton"))
            {
                ResetKeyPadInput(0);
                //reset sound
            }
            
            if (hitKey.CompareTag("EnterButton"))
            {
                if (enteredCode == keyPadCode)
                {
                    doorOpen.SetBool("character_nearby", true);
                    DoorSound.Play();
                    Renderer kRend = keyPadDisplay.GetComponent<Renderer>();
                    kRend.material.color = Color.green;
                    //corect sound
                    firstPuzzleDone = true;
                    updateQuestLog = true;
                    questLogState = 3;
                }
                else
                {
                    ResetKeyPadInput(1);
                    //incorect sound
                }
            }
            hitKey = null;
        }
        
        if (Time.time > kDisplayToNormal && keyPadDisplay.GetComponent<Renderer>().material.color != Color.white )
        {
            if (keyPadDisplay.GetComponent<Renderer>().material.color != Color.green)
            {
                Renderer kRend = keyPadDisplay.GetComponent<Renderer>();
                kRend.material.color = Color.white;
            }
        }
        if (index != -1)
        {
            Renderer kRend = displayKey[keysInputted-1].GetComponent<Renderer>();
            kRend.material = padKeysMat[index];
        }
    }

    private void ResetKeyPadInput(int CS) // reset the numbers inputed 
    {
        enteredCode = "";
        keysInputted = 0;
        Renderer kRend = keyPadDisplay.GetComponent<Renderer>();
        if (CS == 0)  { kRend.material.color = Color.grey; }
        else { kRend.material.color = Color.red; }

        foreach (GameObject key in displayKey)
        {
            Renderer rend = key.GetComponent<Renderer>();
            rend.material = padKeysMat[10];
        }
        kDisplayToNormal = Time.time + .7f;
    }

    private void NeuralBoosterTaken() // use neural boosters
    {
        if (Input.GetKey("q") && Input.GetKeyDown("e") && canUseNeural && !inMedicBay && !inTrip)
        {
            usingNeuralBooster = true;
            neuralBoostersUsed++;
            print("woooow Boosted = " + neuralBoostersUsed);
            HideOrDisplayHints(true);
            neuralCoolDown = Time.time + 10.0f;
            canUseNeural = false;
        }
        if (Time.time >= neuralCoolDown && !canUseNeural)
        {
            usingNeuralBooster = false;
            canUseNeural = true;
            HideOrDisplayHints(false);
            print("oh it's gone");
            fixBlue = true;
        }
    }

    private void HideOrDisplayHints(bool show) //reveal hints, after timer expires hide them
    {
        if (!firstPuzzleDone)
        {
            string code = keyPadCode.Substring(keyPadCode.Length - 3);
            string s1 = "Key" + code.Substring(0, 1);
            string s2 = "Key" + code.Substring(1, 1);
            string s3 = "Key" + code.Substring(2, 1);
            string[] ss = new string[] { s1, s2, s3 };
            for (int i = 0; i < 3; i++)
            {

                Renderer keyRend = GameObject.FindGameObjectWithTag(ss[i]).GetComponent<Renderer>();
                if (show) { keyRend.material.color = Color.blue; }
                else { keyRend.material.color = Color.white; }
            }
            //Renderer fRend = GameObject.Find("FirstKeyInLvl").GetComponent<Renderer>(); // first key
            //if (show) { fRend.material.color = Color.blue; }
            //else { fRend.material.color = Color.white; }
        }
        if (!secondPuzzleDone)
        {
            GameObject[] mLights = GameObject.FindGameObjectsWithTag("mLights").OrderBy(go => go.name).ToArray();
            Color[] cColor = {Color.blue, Color.magenta, Color.yellow, Color.black };
            for (int i = 0; i < cordArrangement.Length; i++)
            {
                if (show)
                {
                    int indx = int.Parse(cordArrangement[i].Substring(cordArrangement[i].Length - 2, 1));
                    GameObject.Find(cordArrangement[i]).GetComponent<Renderer>().material.color = cColor[indx - 1];
                    print(indx + "  = " +mLights[indx-1 ]);
                    mLights[indx-1].GetComponent<Renderer>().material.color = cColor[i];
                    print(mLights[indx - 1]);
                }
                else
                {
                    GameObject.Find(cordArrangement[i]).GetComponent<Renderer>().material.color = mPurple;
                    mLights[i].GetComponent<Renderer>().material.color = Color.grey;
                }
            }
        }
    }
}
