using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Neural_Booster : MInheretance
{

    float timerMB = 0;
    float timerG = 0;
    float timerER = 0;
    float timerHB = 0;
    float timerBO = 0;
    float timerIB = 0;
    float timerFB = 0;
    float TimerDEATH = 0;
    float TimeRS = 0;
    float TimerVFX = 0;
    float timervfxsfx = 0;

    private bool looop;
    private bool vfxoff;

    public int NBintake;
    private GameObject fpsplayer;

    private Animation anim;

    private bool deathyes;
    private bool restartgame;

    public GameObject VFX;

    // Start is called before the first frame update
    void Start()
    {
        vfxoff = false;
        looop = false;
        deathyes = false;
        restartgame = false;
        NBintake = neuralBoostersUsed;
        fpsplayer = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(usenb(3));
        loop();
        KillPlayer();
        Gamerestarter();
        Vfxswtich();
        NBcounter();

    }



    IEnumerator usenb(float time)
    {
        if (Input.GetKey("q") && Input.GetKeyDown("e") && canUseNeural && !inMedicBay && !inTrip)
        {
            VFX.SetActive(true);
            NBintake++;

            if(NBintake <= 2)
            {
                TimerVFX = Time.time + 6;
                vfxoff = true;
                Visualfx_Sound.vfxsounds = true;
                timervfxsfx = Time.time + 8;
                
            }

            if (NBintake >= 3 && NBintake <= 4)
            {
                Visualfx_Sound.vfxsounds = true;
                timervfxsfx = Time.time + 8;
                TimerVFX = Time.time + 6;
                vfxoff = true;
                yield return new WaitForSeconds(time);
                Motion_Blur.activeNB = true;
                timerMB = Time.time + 7;
                timerG = Time.time + 10;
                looop = true;
               
            }

            if (NBintake >= 5 && NBintake <= 7)
            {
                Visualfx_Sound.vfxsounds = true;
                timervfxsfx = Time.time + 8;
                TimerVFX = Time.time + 6;
                vfxoff = true;
                yield return new WaitForSeconds(time);
                Motion_Blur.activeNB = true;
                Earringing_SFX.erSFX = true;
                timerMB = Time.time + 10;
                timerG = Time.time + 13;
                timerER = Time.time + 14;
                timerIB = Time.time + 16;
                looop = true;
                
                yield return new WaitForSeconds(4);
                Motion_Blur.activeIB = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = false;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = false;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = false;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = false;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeIB = false;
          


            }

            if (NBintake >= 8 && NBintake <= 14)
            {
                Visualfx_Sound.vfxsounds = true;
                timervfxsfx = Time.time + 8;
                TimerVFX = Time.time + 6;
                vfxoff = true;
                yield return new WaitForSeconds(time);
                Motion_Blur.activeNB = true;
                Earringing_SFX.erSFX = true;
                Neural_Sound.hbSFX = true;
                timerMB = Time.time + 10;
                timerG = Time.time + 13;
                timerHB = Time.time + 14;
                timerER = Time.time + 14;
               // timerIB = Time.time + 16;
                timerBO = Time.time + 16;
                looop = true;

                yield return new WaitForSeconds(4);
                Motion_Blur.activeBO = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = false;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = false;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = false;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = false;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = true;
                yield return new WaitForSeconds(1);
                Motion_Blur.activeBO = false;
            }

            if (NBintake >= 15)
            {
                Visualfx_Sound.vfxsounds = true;
                timervfxsfx = Time.time + 8;
                TimerVFX = Time.time + 6;
                vfxoff = true;
                yield return new WaitForSeconds(time);
                Motion_Blur.activeFB = true;
                Earringing_SFX.erSFX = true;
                

                fpsplayer.GetComponent<CharacterController>().enabled = false;
                 timerFB = Time.time + 3;
                timerER = Time.time + 10;
                TimerDEATH = Time.time + 4;
                //looop = true;
                deathyes = true;


            }   
        }

    }

    void loop()
    {
        if (looop && Time.time >= timerMB)
        {
            Motion_Blur.activeNB = false;
            Motion_Blur.activeG = true;
            

        }

        if (looop && Time.time >= timerG)
        {
            Motion_Blur.activeG = false;
            
        }

        if (looop && Time.time >= timerHB)
        {
            Neural_Sound.hbSFX = false;
            //print("hboff");
        }

        if (looop && Time.time >= timerER)
        {
            Earringing_SFX.erSFX = false;
            
        }
        if (looop && Time.time >= timerBO)
        {
            Motion_Blur.activeBO = false;
            
        }
        if (looop && Time.time >= timerFB)
        {
            //Motion_Blur.activeFB = false;
            
        }
        if (looop && Time.time >=  timervfxsfx)
        {
            Visualfx_Sound.vfxsounds = false;
        }

       
    }

   private void KillPlayer()
    {
        if (deathyes && Time.time >= TimerDEATH)
        {
            Motion_Blur.activeNB = true;
            anim.Play("Deathanim");
            deathyes = false;
            TimeRS = Time.time + 6;
            restartgame = true;
        }

        
    }

    private void Gamerestarter ()
    {
        if (restartgame && Time.time >= TimeRS)
        {
            print("RELOAD");
            SceneManager.LoadScene("Newmenu");
        }
    }

    private void Vfxswtich()
    {
        if(vfxoff && Time.time >= TimerVFX)
        {
            VFX.SetActive(false);
        }
    }

    private void NBcounter()
    {
        NBintake = neuralBoostersUsed;
    }

    

}

