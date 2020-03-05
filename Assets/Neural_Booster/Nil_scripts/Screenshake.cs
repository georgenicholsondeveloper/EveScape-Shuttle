using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Screenshake :MInheretance {

    public GameObject Player;
    public float _shakeby;
    private Vector3 orgpos;
    private bool canishake;
    private bool endCutscene = false;

    public PostProcessingProfile Blackyprofile;
    public PostProcessingProfile Defaultprofile;
    private bool blackyintro;
    private float timerblack= 0;
    public float starttime = 1f;


    private bool changestates;
    private bool proisready;


    public GameObject redlightone;
    public GameObject redlighttwo;
    public GameObject redlightthree;

    public GameObject warningsounds;
    // Use this for initialization
    void Start () {
       // _shakeby = 11f;
        canishake = true;
        blackyintro = true;
        changestates = false;
        proisready = false;


        
         
    }
	
	// Update is called once per frame
	void Update () {
        orgpos = Player.transform.position + new Vector3 (0,0.688f,0);
        Shakethisbitch();
        Blackoutstart();
        Blackoutend();
        PostProf();
       

        StartCoroutine(Redlights());

    }

    private void Shakethisbitch ()
    {
        if (_shakeby > 0)
        {
            transform.position = orgpos;
            transform.position = new Vector3(transform.position.x + Random.Range(_shakeby * Time.deltaTime, _shakeby * -1 * Time.deltaTime), transform.position.y + Random.Range(_shakeby * Time.deltaTime, _shakeby * -1 * Time.deltaTime), transform.position.z + Random.Range(_shakeby * Time.deltaTime, _shakeby * -1 * Time.deltaTime));
            _shakeby -= 0.050f;
        }
        else
        {
            transform.position = orgpos;
        }
    }

    private void Blackoutstart ()
    {
        if (Time.time >= starttime && blackyintro) 
        {
            this.GetComponent<PostProcessingBehaviour>().profile = Blackyprofile;
            timerblack = Time.time + 4;
            changestates = true;
            blackyintro = false;

        }
    }

    private void Blackoutend()
    {
        if(Time.time >= timerblack && changestates)
        {
           this.GetComponent<PostProcessingBehaviour>().profile = Defaultprofile;
           changestates = false;
            proisready = true;
        }
    }

    private void PostProf()
    {
        if (blackyintro)
        {
            //this.gameObject.GetComponent<Motion_Blur>().enabled = false;
            //this.gameObject.GetComponent<Neural_Booster>().enabled = false;
        }
        if (proisready) 

        {
            this.gameObject.GetComponent<Motion_Blur>().enabled = true;
            //this.gameObject.GetComponent<Neural_Booster>().enabled = true;
            this.gameObject.GetComponent<Screenshake>().enabled = false;

        }
    }

     IEnumerator Redlights()
    {
        if (proisready)
        {

            warningsounds.SetActive(true);

            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(true);
            redlighttwo.SetActive(true);
            redlightthree.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            redlightone.SetActive(false);
            redlighttwo.SetActive(false);
            redlightthree.SetActive(false);
            warningsounds.SetActive(false);


            QuestlogActivate();
        }

    }

    public void QuestlogActivate()
    {
            updateQuestLog = true;

    }

}
