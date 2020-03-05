using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class Endgame : MInheretance {

    public PostProcessingProfile Blackoutz;

    public float _ShakeFaggot;

    public GameObject Player;

    private Vector3 bitchback;

    private float fuckoffalredy = 0;

    private bool Gayfucker;

    private float afterlbackfade = 0;

    private bool yeeehawwww; 
    // Use this for initialization
    void Start () {

        Gayfucker = false;
        yeeehawwww = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        bitchback = Player.transform.position + new Vector3(0, 0.688f, 0);
        LEAVEBITCHLEAVE();
        ShakethisbitchTwo();
        //GOAWAY();
        
        
    }

    public void LEAVEBITCHLEAVE ()
    {
        if(fiftPuzzleDone)
        {
            this.gameObject.GetComponent<Motion_Blur>().enabled = false;
            this.gameObject.GetComponent<Drug_Enabler>().enabled = false;
            
            fuckoffalredy = Time.time + 5;
            Gayfucker = true;
            
        }
    }


    private void ShakethisbitchTwo()
    {
        if (fiftPuzzleDone)
        {
            if (_ShakeFaggot > 0)
            {
                transform.position = bitchback;
                transform.position = new Vector3(transform.position.x + Random.Range(_ShakeFaggot * Time.deltaTime, _ShakeFaggot * -1 * Time.deltaTime), transform.position.y + Random.Range(_ShakeFaggot * Time.deltaTime, _ShakeFaggot * -1 * Time.deltaTime), transform.position.z + Random.Range(_ShakeFaggot * Time.deltaTime, _ShakeFaggot * -1 * Time.deltaTime));
                _ShakeFaggot -= 0.050f;
            }
            else
            {
                transform.position = bitchback;
                this.GetComponent<PostProcessingBehaviour>().profile = Blackoutz;
                StartCoroutine(GOBACKTOMAINMENU());
                
                
                



            }
        }
    }

    


    IEnumerator GOBACKTOMAINMENU()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Newmenu");
            
       
    }


}
