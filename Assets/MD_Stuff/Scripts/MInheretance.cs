using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MInheretance : MonoBehaviour {

    protected static bool canType = false, canUseNeural = true, firstPuzzleDone = false, secondPuzzleDone = false, thirdPuzzleDone = false, forthPuzzleDone = false, fiftPuzzleDone = false, holdingItem = false, neuralInTernimal = false, inMedicBay = false, pickedGasMask = false;
    protected static string keyPadCode = "";
    protected static int neuralBoostersUsed = 0, litPanels = 0, questLogState = 0;
    protected static float neuralCoolDown = -1, gameTimer = 900, timeKeeper = 100;
    protected static bool usingNeuralBooster = false, inTrip = false, updateQuestLog = false, hasCrowBar = false, tripeffect = false, Terminalexplosion = false, hardSetTimer = false;
    protected static bool findCrowbar = false; 

    protected static string[] cordArrangement = {"","","",""};

        //if (gameTimer - Time.time <= 0)
        //{
        //    //ran out of time
        //} 
}
