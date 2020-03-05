using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class TriggerCheck : MInheretance {

    private Text terminalCodeText, zeCooldownHolder,  dText, timeBforFail;
    private GameObject currentItem, occupiedSlot, medicBayMenu, medicBayScanUi, medSequanceInstructions, sequancePage, cooldownPage;
    private Transform insertPosition;
    private Vector3 b4Teleport;
    public GameObject allLights;

    private string inName, terminalInput = "";
    private bool insertItem, pickUp, occupied, canInput, mixedText, typoo, neuralForTerminal, exitTerminal, inMedBay, medBayInCD, medBayInUse, inMedSequance, doneWTrip, backFTrip;
    private float tickTimer = -1;
    private int sPuzzleWinCon = 0, medicBayState, miniGameLetter, numberOfMistakes, correctInput, totalLetters;

    private GameObject[] powerCords;
    private GameObject[] lights;

    [SerializeField]
    private string[] otherTerminalText;
    private string[] originalOtherTerminalText;
    private string[] alphabetLow    = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    private string[] alphabetOnWeeD = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    public GameObject[] turnOnLights;
    public GameObject[] turnOfLights;
    public Canvas terminalDisplay, medicDisplay;
    public Camera cam1, cam2, cam3, cam4, mainCam; //cam1 & 2 are for terminal. cam3 & 4 are for medicBay
    

    private void Awake()
    {
        dText = GameObject.Find("Input:Letter").GetComponent<Text>();
        timeBforFail = GameObject.Find("Timeb4Fail").GetComponent<Text>();
        medicBayScanUi = GameObject.Find("ScanningMedPannel");
        medicBayMenu = GameObject.Find("FirstMedPannel");
        medSequanceInstructions = GameObject.Find("InstructionsForSequance");
        sequancePage = GameObject.Find("TheMiniGame");
        cooldownPage = GameObject.Find("MedCoolDown");
        zeCooldownHolder = GameObject.Find("zeCooldown").GetComponent<Text>();
        mainCam = gameObject.GetComponentInChildren<Camera>();
        medicBayScanUi.SetActive(false);
        medSequanceInstructions.SetActive(false);
        sequancePage.SetActive(false);
        cooldownPage.SetActive(false);
        b4Teleport = transform.position;
    }

    private void Start()
    {
        terminalCodeText = GameObject.Find("terminalCodeText").GetComponent<Text>();
        terminalCodeText.text = "";
        powerCords = GameObject.FindGameObjectsWithTag("PowerCord");
        lights = GameObject.FindGameObjectsWithTag("Lights").OrderBy(go => go.name).ToArray();
        
        GameObject[] OTTxt = GameObject.FindGameObjectsWithTag("otherTerminalText").OrderBy(go => go.name).ToArray();
        otherTerminalText = new string[OTTxt.Length];
        originalOtherTerminalText = new string[OTTxt.Length];
        int i = 0;
        foreach (GameObject txtObj in OTTxt)
        {
            otherTerminalText[i] = txtObj.GetComponent<Text>().text;
            originalOtherTerminalText[i] = txtObj.GetComponent<Text>().text;
            i++;
        }

        for (i = 0; i < otherTerminalText.Length; i++)
        {
            string sentance = "";
            foreach (char c in otherTerminalText[i])
            {
                string s = c.ToString();
                if (c.ToString() != " " && c != (char)9)
                {
                    if (char.IsLower(c))
                    {
                        int r = Random.Range(0, alphabetLow.Length);
                        s = alphabetLow[r];
                    }
                    if (char.IsUpper(c))
                    {
                        int r = Random.Range(0, alphabetOnWeeD.Length);
                        s = alphabetOnWeeD[r];
                    }
                }
                sentance += s;
            }
            otherTerminalText[i] = sentance;
        }
        mixedText = true;
        i = 0;
        foreach (GameObject txtObj in OTTxt)
        {
            txtObj.GetComponent<Text>().text = otherTerminalText[i];
            i++;
        }

        for (i = 0; i < powerCords.Length; i++)
        {
            int pos = Random.Range(0, 3);
            GameObject curObj = powerCords[i];
            GameObject swapObj = powerCords[pos];
            powerCords[pos] = curObj;
            powerCords[i] = swapObj;
        }
        i = 0;
        foreach (GameObject cord in powerCords)
        {
            cordArrangement[i] = cord.name;
            i++;
        }
        print(cordArrangement[0] + " " + cordArrangement[1] + " " + cordArrangement[2] + " " + cordArrangement[3]);
    }

    void Update()
    {
        PlugPowerCord();
        SecondPuzzleDoneCondition();
        TerminalInput();
        MedicSequance();
        MedicSequanceResult();
        MedicBayCooldown();
        TripTeleportation();
    }

    private void PlugPowerCord()
    {
        if (holdingItem && Input.GetKeyDown("e") && Time.time >= tickTimer)
        {
            if (!insertItem)
            {
                currentItem.transform.SetParent(null);
                currentItem.transform.position -= new Vector3(0, 0.6f, 0);
            }
            else
            {
                currentItem.transform.position = insertPosition.position;
                currentItem.transform.SetParent(insertPosition);
                currentItem.transform.eulerAngles = insertPosition.eulerAngles;
                currentItem.transform.localScale = new Vector3(1, 1, 1);

                int idx = int.Parse(currentItem.name.Substring(currentItem.name.Length - 2, 1));
                if (powerCords[idx - 1].name.Substring(powerCords[idx - 1].name.Length - 2, 1) == inName.Substring(inName.Length - 2, 1))
                {
                    currentItem.tag = "Untagged";
                    GameObject.Find(inName).tag = "Untagged";
                    int i = int.Parse(inName.Substring(inName.Length - 2, 1)); //regular expresion can be used to find what's in () if double/tripple digits
                    lights[i - 1].GetComponent<Renderer>().material.color = Color.green;
                    sPuzzleWinCon++;
                }
                else
                {
                    GameObject.Find(inName).tag = "Occupied";
                    int i = int.Parse(inName.Substring(inName.Length - 2, 1));
                    lights[i - 1].GetComponent<Renderer>().material.color = Color.red;
                }

            }
            insertItem = false;
            pickUp = false;
            currentItem = null;
            holdingItem = false;
            occupied = false;
        }
    }

    private void SecondPuzzleDoneCondition()
    {
        if (lights != null && sPuzzleWinCon == 4)
        {
            secondPuzzleDone = true;
            allLights.SetActive(true);

            currentItem = null;
            powerCords = null;
            lights = null;
            foreach (GameObject light in turnOnLights)
            {
                light.SetActive(true);
            }
            foreach (GameObject light in turnOfLights)
            {
                light.SetActive(false);
            }
            print("SECOND PUZZLE DONE!!");
       
        }
    }

    private void EnterExitTerminal(bool isEntering, Canvas targetDisplay, Camera C1, Camera C2)
    {
        gameObject.GetComponent<PlayerCharacterScript>().enabled = !isEntering;
        //gameObject.GetComponent<MouseLook>().enabled = !isEntering;
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().enabled = !isEntering;
        C1.enabled = isEntering;
        C2.enabled = !isEntering;
        canInput = isEntering;
        if (isEntering) { targetDisplay.worldCamera = C1; }
        else { targetDisplay.worldCamera = C2;
            if (thirdPuzzleDone && !Terminalexplosion)
            {
                Terminalexplosion = true;
                hardSetTimer = true;
                print("Terminal shake start");
                updateQuestLog = true;
                questLogState = 4;
            }

        }

    }

    private void TerminalInput()
    {
        if (canInput && !thirdPuzzleDone && !inMedBay && Input.anyKeyDown)
        {
            foreach (char c in Input.inputString)
            {
                string s = c.ToString();
                print(c);
                if (terminalInput.Length != 0 && c == '\b') // has backspace/delete been pressed?
                {
                    terminalInput = terminalInput.Substring(0, terminalInput.Length - 1);
                    s = "";
                }
                else if (mixedText)
                {
                    int r = Random.Range(0, alphabetLow.Length);
                    if (char.IsLower(c))
                    {
                        s = alphabetLow[r];
                    }
                    if (char.IsUpper(c))
                    {
                        s = alphabetOnWeeD[r];
                    }
                }
                terminalInput += s;
                if (typoo)
                {
                    terminalInput = terminalInput.Substring(0, terminalInput.Length - 1);
                    typoo = false;
                }
            }
            terminalCodeText.text = terminalInput;
            if (terminalInput.Length != 0)
            {
                if (terminalInput.Substring(0,1) == "L" && terminalInput.Contains("LifeSupportSystem(Run);"))
                {
                    TerminalConclusion();
                }
            }
        }
        if (terminalInput == "LifeSupportSystem(Run);" && !thirdPuzzleDone)
        {
            TerminalConclusion();
        }
        if (Time.time > tickTimer && exitTerminal)
        {
            EnterExitTerminal(false, terminalDisplay, cam1, cam2);
            exitTerminal = false;
        }

    }

    private void TerminalConclusion()
    {
        GameObject.Find("16| Offline").GetComponent<Text>().text = "| Running";
        print("3rdPuzzleDone");
        updateQuestLog = true;
        questLogState = 5;
        thirdPuzzleDone = true;
        tickTimer = Time.time + 1.5f;
        exitTerminal = true;
    }

    private void ScanResults()
    {
        medicBayMenu.SetActive(true);
        medicBayScanUi.SetActive(false);
        sequancePage.SetActive(false);
        float toxinPrecentage = neuralBoostersUsed * 5;
        GameObject.Find("ToxinInBlood").GetComponent<Text>().text = "Neural Toxin in Blood: " + toxinPrecentage + "%";
        if (neuralBoostersUsed < 4)
        {
            ScaleResults("", "Stable", Color.white, 10, 0);
        }
        if (neuralBoostersUsed >= 4 && neuralBoostersUsed < 8)
        {
            ScaleResults("Press E to reduce toxicity", "Unstable", new Vector4(1f, .65f, 0, 1), 2, 2); 
        }
        if (neuralBoostersUsed >= 8 && neuralBoostersUsed < 15)
        {
            ScaleResults("Press E to reduce toxicity", "Unstable", new Vector4(1, 0, 0.043f, 1), 2, 3);
        }

        medBayInUse = false;
    }

    private void ScaleResults(string option, string state, Vector4 mColor, int bayStatus, int canMistake)
    {
        GameObject.Find("Option:Scan").GetComponent<Text>().text = option;
        GameObject.Find("LastScan").GetComponent<Text>().text = "Last Scan Results: " + state;
        GameObject.Find("BrainPanel").GetComponent<Image>().color = mColor;
        GameObject.Find("NeuralUsed").GetComponent<Text>().text = "Neural Boosters Consumed: " + neuralBoostersUsed;
        medicBayState = bayStatus;
        numberOfMistakes = canMistake;
    }

    private void MedicSequance()
    {
        if (totalLetters != 0 && numberOfMistakes > 0 && inMedSequance)
        {
            if (medicBayState == 4) //start of Sequance Game
            {
                miniGameLetter = Random.Range(0, alphabetOnWeeD.Length);
                GameObject.Find("Input:Letter").GetComponent<Text>().text = alphabetOnWeeD[miniGameLetter];
                GameObject.Find("MistakesAllowed:").GetComponent<Text>().text = "Mistakes Allowed: " + numberOfMistakes;
                medicBayState++;
                print("NewLetter");
            }
            if (medicBayState == 5 && Input.anyKeyDown)
            {
                foreach (char c in Input.inputString)
                {
                    if (c.ToString().ToUpper() == alphabetOnWeeD[miniGameLetter])
                    {
                        correctInput++;
                        medicBayState = 4;
                    }
                    else
                    {
                        numberOfMistakes--;
                        GameObject.Find("MistakesAllowed:").GetComponent<Text>().text = "Mistakes Allowed: " + numberOfMistakes;
                    }
                    totalLetters--;
                }
            }
            if (Time.time > tickTimer)
            {
                timeBforFail.text = "Time left: 0";
                numberOfMistakes = 0;
                medicBayState = 5;
            }
            if (Time.time < tickTimer)
            {
                int mTimer = Mathf.CeilToInt(tickTimer - Time.time);
                timeBforFail.text = "Time left: " + mTimer;
            }
        }
        if (medicBayState == 4 && totalLetters == 0 || medicBayState == 5 && numberOfMistakes == 0)
        {
            inMedSequance = false;
            medicBayState = 6;
        }
    }

    private void MedicSequanceResult()
    {
        if(medicBayState == 6)
        {
            if (numberOfMistakes == 0)
            {
                MedicTextResultEdit(80, Color.red, "Stabilisation: Failed", 7, 0);
            }
            else
            {
                if (neuralBoostersUsed >= 4 && neuralBoostersUsed < 8)
                {
                    if (numberOfMistakes == 2)
                    {
                        MedicTextResultEdit(80, Color.green, "Stabilisation: Completed", 7, 2);
                    }
                    else
                    {
                        MedicTextResultEdit(80, Color.white, "Stabilisation: Concluded", 7, 1);
                    }
                }
                else
                {
                    if (numberOfMistakes == 3)
                    {
                        MedicTextResultEdit(80, Color.green, "Stabilisation: Completed", 7, 2);
                    }
                    else
                    {
                        MedicTextResultEdit(80, Color.white, "Stabilisation: Concluded", 7, 1);
                    }
                }
            }
            tickTimer = Time.time + 2;
        }
        if (medicBayState == 7 && Time.time > tickTimer)
        {
            ScanResults();
            GameObject.Find("Option:Scan").GetComponent<Text>().text = "";
            MedicTextResultEdit(150, Color.white, "X", 8, 0);
        }
    }

    private void MedicTextResultEdit(int fSize, Vector4 cColor, string mText, int iState, int minusBy)
    {
        dText.fontSize = fSize;
        dText.color = cColor;
        dText.text = mText;
        medicBayState = iState;
        neuralBoostersUsed -= minusBy;
    }

    private void MedicBayCooldown()
    {
        if (medicBayState == 9)
        {
            medicBayMenu.SetActive(false);
            cooldownPage.SetActive(true);
            int cdTime = Mathf.CeilToInt(tickTimer - Time.time);
            zeCooldownHolder.text = "Cooldown: " + cdTime;
            if (Time.time >= tickTimer)
            {
                medBayInCD = false;
                zeCooldownHolder.text = "Medic Bay Ready";
                medicBayState = 0;
            }
        }
    }

    private void TripTeleportation()
    {
        if (pickedGasMask && Time.time >= tickTimer)
        {
            tripeffect = true;
            b4Teleport = transform.position;
            gameObject.transform.position = new Vector3(53.6f, 303.783f, -20.74f);
            mainCam.fieldOfView = 110;
            pickedGasMask = false;
        }
        if (forthPuzzleDone && !doneWTrip && !backFTrip)
        {
            doneWTrip = true;
            tickTimer = Time.time + 3;
        }
        if (Time.time >= tickTimer && doneWTrip && !backFTrip)
        {
            updateQuestLog = true;
            questLogState = 6;
            backFTrip = true;
            gameObject.transform.position = b4Teleport;
            mainCam.fieldOfView = 60;
            inTrip = false;
            tripeffect = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanType"))
        {
            canType = true;
        }
        if (other.CompareTag("Terminal"))
        {
            neuralInTernimal = true;
        }
        if (other.CompareTag("MedicBay"))
        {
            inMedicBay = true;
            canUseNeural = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Occupied") && !occupied)
        {
            occupied = true;
            occupiedSlot = other.gameObject;
        }
        if (other.CompareTag("PowerCord") && Input.GetKeyDown("e") && !holdingItem)
        {
            tickTimer = Time.time + .2f;
            currentItem = other.gameObject;
            if (!pickUp && !occupied) { other.gameObject.transform.position += new Vector3(0, 0.6f, 0); }
            other.gameObject.transform.SetParent(gameObject.transform);
            holdingItem = true;
            if (occupied)
            {
                occupiedSlot.tag = "PowerPlug";
                int i = int.Parse(occupiedSlot.name.Substring(occupiedSlot.name.Length - 2, 1));
                lights[i - 1].GetComponent<Renderer>().material.color = Color.yellow;
                occupied = false;
            }

        }
        if (other.CompareTag("PowerPlug"))
        {
            if (holdingItem)
            {
                inName = other.gameObject.name;
                insertItem = true;
                insertPosition = other.gameObject.transform;
            }
            else
            {
                insertItem = false;
                pickUp = true;
            }
        }
        if (other.CompareTag("Terminal") && !thirdPuzzleDone && secondPuzzleDone)
        {
            if (Input.GetKeyDown("e") && !canInput)
            {
                EnterExitTerminal(true, terminalDisplay, cam1, cam2);
                typoo = true;
            }
           
            if (Input.GetKeyDown(KeyCode.Escape) && canInput)
            {
                EnterExitTerminal(false, terminalDisplay, cam1, cam2);
            }
            if (!canUseNeural && neuralInTernimal && !neuralForTerminal)
            {
                neuralForTerminal = true;
                mixedText = false;
                int i = 0;
                terminalInput = "";
                terminalCodeText.text = terminalInput;
                GameObject[] OTTxt = GameObject.FindGameObjectsWithTag("otherTerminalText").OrderBy(go => go.name).ToArray();
                foreach (GameObject txtObj in OTTxt)
                {
                    txtObj.GetComponent<Text>().text = originalOtherTerminalText[i];
                    i++;
                }
            }
        }
        if (other.CompareTag("MedicBay") && !pickedGasMask && !usingNeuralBooster)
        {
            if (Input.GetKeyDown("e") && medicBayState == 1) //StartScan second Interaction
            {
                medBayInUse = true;
                medicBayMenu.SetActive(false);
                medicBayScanUi.SetActive(true);
                medSequanceInstructions.SetActive(false);
                tickTimer = Time.time + 3;
            }
            if (Input.GetKeyUp("e") && medicBayState == 3) //started minigamed
            {
                medicBayState = 4;
                medSequanceInstructions.SetActive(false);
                sequancePage.SetActive(true);
                correctInput = 0;
                totalLetters = neuralBoostersUsed;
                inMedSequance = true;
                tickTimer = Time.time + 10;
                timeBforFail.text = "Time left: " + 10; 
            }
            if (Input.GetKeyUp("e") && inMedBay && !medBayInUse && medicBayState == 2) //Start recover Sequance
            {
                medBayInUse = true;
                medicBayState = 3;
                medicBayMenu.SetActive(false);
                medicBayScanUi.SetActive(false);
                medSequanceInstructions.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Escape))  //Exit possible when not scanning or in minigame
            {
                if (medicBayState == 8)
                {
                    medBayInUse = false;
                    print("Quitt");
                    medicBayMenu.SetActive(false);
                    medicBayScanUi.SetActive(false);
                    medSequanceInstructions.SetActive(false);
                    sequancePage.SetActive(false);
                    cooldownPage.SetActive(true);
                    zeCooldownHolder.text = "Cooldown: " + 10;
                    medBayInCD = true;
                    tickTimer = Time.time + 10;
                    medicBayState = 9;
                    inMedSequance = false;
                    EnterExitTerminal(false, medicDisplay, cam3, cam4);
                }
                else if (inMedBay && !medBayInUse || medicBayState == 3 ||medicBayState == 4)
                {
                    medBayInUse = false;
                    inMedSequance = false;
                    medicBayMenu.SetActive(true);
                    GameObject.Find("Option:Scan").GetComponent<Text>().text = "Press E to start scan";
                    medicBayScanUi.SetActive(false);
                    medSequanceInstructions.SetActive(false);
                    inMedBay = false;
                    EnterExitTerminal(false, medicDisplay, cam3, cam4);
                    medicBayState = 0;
                }
            
            }
            if (Input.GetKeyDown("e") && !medBayInCD && !inMedBay) //first medicBay interaction (inBay) ENTEEER
            {
                EnterExitTerminal(true, medicDisplay, cam3, cam4);
                inMedBay = true;
                medicBayState = 1;
                medicBayMenu.SetActive(true);
                cooldownPage.SetActive(false);
                GameObject.Find("Option:Scan").GetComponent<Text>().text = "Press E to start scan";
            }
            if (Time.time > tickTimer && medBayInUse && medicBayState == 1) //Scan Results
            {
                ScanResults();
            }
        }
        if (other.CompareTag("GasMask") && thirdPuzzleDone)
        {
            if (Input.GetKeyDown("e"))
            {
                tickTimer = Time.time + 6;
                Destroy(other.gameObject);
                pickedGasMask = true;
                inTrip = true;
            }
        }
        if (other.CompareTag("CrowBar") && forthPuzzleDone)
        {
            if (Input.GetKeyDown("e"))
            {
                Destroy(other.gameObject);
                hasCrowBar = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CanType"))
        {
            canType = false;
        }
        if (other.CompareTag("PowerPlug"))
        {
            insertItem = false;
            pickUp = false;
        }
        if (other.CompareTag("Occupied"))
        {
            occupied = false;
            occupiedSlot = null;
        }
        if (other.CompareTag("Terminal"))
        {
            neuralInTernimal = false;
        }
        if (other.CompareTag("MedicBay"))
        {
            if (!usingNeuralBooster) { canUseNeural = true; }
            inMedBay = false;
            inMedicBay = false;
        }
    }
}
