using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MInheretance {

    public void StartGame()
    {
        canType = false;
        canUseNeural = true;
        firstPuzzleDone = false;
        secondPuzzleDone = false;
        thirdPuzzleDone = false;
        forthPuzzleDone = false;
        fiftPuzzleDone = false;
        holdingItem = false;
        neuralInTernimal = false;
        inMedicBay = false;
        pickedGasMask = false;
        keyPadCode = "";
        neuralBoostersUsed = 0;
        litPanels = 0;
        questLogState = 0;
        neuralCoolDown = -1;
        gameTimer = 900;
        timeKeeper = 20;
        usingNeuralBooster = false;
        inTrip = false;
        updateQuestLog = false;
        hasCrowBar = false;
        tripeffect = false;
        Terminalexplosion = false;
        hardSetTimer = false;
        findCrowbar = false;

        SceneManager.LoadScene("Topship Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
