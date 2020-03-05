using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Terminal_shake : MInheretance
{

    public float _Shakebitch;
    private Vector3 originalpos;
    public GameObject Player;
    public GameObject explosion;

    public GameObject redlightone;
    public GameObject redlighttwo;
    public GameObject redlightthree;

    private bool ForDaLights;

    public GameObject warningsfx;

    // Use this for initialization
    void Start()
    {
        ForDaLights = true;
    }

    // Update is called once per frame
    void Update()
    {

        Beginshake();
        originalpos = Player.transform.position + new Vector3(0, 0.688f, 0);
        
    }

    public void Beginshake()
    {
        if (thirdPuzzleDone)
        {
            if (_Shakebitch > 0)
            {
                transform.position = originalpos;
                transform.position = new Vector3(transform.position.x + Random.Range(_Shakebitch * Time.deltaTime, _Shakebitch * -1 * Time.deltaTime), transform.position.y + Random.Range(_Shakebitch * Time.deltaTime, _Shakebitch * -1 * Time.deltaTime), transform.position.z + Random.Range(_Shakebitch * Time.deltaTime, _Shakebitch * -1 * Time.deltaTime));
                _Shakebitch -= 0.050f;
                explosion.SetActive(true);

            }
            else
            {
                StartCoroutine(Redlightson());
                transform.position = originalpos;
                
                
            }
        }
    }

    IEnumerator Redlightson()
    {

        if (ForDaLights)
        {
            ForDaLights = false;
            warningsfx.SetActive(true);
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


            ForDaLights = false;
            warningsfx.SetActive(false);
        }
}


    
}
      