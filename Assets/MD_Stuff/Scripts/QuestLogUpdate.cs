using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogUpdate : MInheretance {

    public Image questPanel; //a 0.7
    public Text[] questText; //a 1
    private Text currentText;

    private bool inLogUpdate, startFadeOut, startFadeOutText, startFadeIn, yoollooo, yolo;
    private float stayTimer; //6 

	void Awake () {
        questPanel.color = new Vector4(questPanel.color.r, questPanel.color.b, questPanel.color.g, 0);
        foreach(Text qText in questText)
        {
            qText.color = new Vector4(1, 1, 1, 0);
        }
        yolo = true;
        yoollooo = true;
	}
	
	void Update () {
        if (updateQuestLog && inLogUpdate)
        {
            updateQuestLog = false;
            startFadeOutText = true;
            stayTimer = Time.time + 6;
        }
		if (updateQuestLog && !inLogUpdate)
        {
            currentText = questText[questLogState];
            updateQuestLog = false;
            startFadeOut = false;
            inLogUpdate = true;
            startFadeIn = true;
            stayTimer = Time.time + 6;
        }

        if (startFadeOutText)
        {
            if(currentText.color.a > 0)
            {
                var tempColor = currentText.color;
                tempColor.a -= 0.02f;
                currentText.color = tempColor;
            }
            else
            {
                if (Time.time > stayTimer) { inLogUpdate = false; }
                startFadeOutText = false;
                currentText = questText[questLogState];
                startFadeIn = true;
            }
        }

        if (startFadeOut)
        {
            if (questPanel.color.a > 0)
            {
                var tempColor = currentText.color;
                tempColor.a -= 0.01f;
                questPanel.color = tempColor;
            }
            else
            {
                startFadeOut = false;
            }
        }

        if (startFadeIn && !startFadeOut && inLogUpdate)
        {
            if(questPanel.color.a < 0.7f)
            {
                var tempColor = currentText.color;
                tempColor.a += 0.01f;
                questPanel.color = tempColor;
            }
            if (currentText.color.a < 1)
            {
                var tempColor = currentText.color;
                tempColor.a += 0.01f;
                currentText.color = tempColor;
            }
            if (currentText.color.a >=1 && questPanel.color.a >= 0.7f)
            {
                startFadeIn = false;
            }
        }

        if (inLogUpdate && Time.time > stayTimer)
        {
            startFadeIn = false;
            startFadeOut = true;
            startFadeOutText = true;
        }


        if (yolo && neuralBoostersUsed == 1)
        {
            yolo = false;
            updateQuestLog = true;
            questLogState = 1;
        }
        if (yoollooo && neuralBoostersUsed == 3) 
        {
            yoollooo = false;
            updateQuestLog = true;
            questLogState = 2;
        }

    }
}
