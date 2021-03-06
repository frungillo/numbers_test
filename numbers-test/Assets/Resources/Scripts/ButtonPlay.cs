﻿using System;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ButtonPlay : MonoBehaviour
{
    public Text txtToastLabel;
    public Text txtMonitor;

    public Button btnSolo;
    public Button btnMultiPlay;
    public Image imgProfilo;
    public Text txtCoins;
    public Text txtXp;


    private void Awake()
    {
        imgProfilo = DatiGioco.user.UserProfileImage;
        txtMonitor.text = DatiGioco.user.Nickname;
        txtCoins.text = DatiGioco.user.Money.ToString();
        txtXp.text = DatiGioco.user.Single_score.ToString();

        

    }

    

   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckInternetConnection((isConnected) => {
            if(!isConnected)
            {
                showToast("Connessione internet assente...", 2);
                btnSolo.enabled = false;
                btnMultiPlay.enabled = false;
            } else
            {
                //showToast("Connessione internet OK", 2);
            }
        }));
        if (!MusicTemeScript.Instance.gameObject.GetComponent<AudioSource>().isPlaying)
            MusicTemeScript.Instance.gameObject.GetComponent<AudioSource>().Play();


    }


   


#region Risultati

#if !PLATFORM_IOS
  

    public static void MostraRisultatiUI()
    {
        Social.ShowAchievementsUI();
        Debug.Log("UI ATTIVATA");
    }
#endif
#endregion /Risultati

    /*Pulsante Opzioni*/
    public void ClickOptions()
    {
        Debug.Log("Options Clicked!");
#if !PLATFORM_IOS
        MostraRisultatiUI();
#endif

    }

    /*Pulsante SOLO*/
   public  void TaskOnClickPlaySolo()
    {
        //MusicTemeScript.Instance.gameObject.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("ScenaDownload");
    }

    /*Pulsante SFIDA*/
    public void TaskOnClickMutiplayer()
    {
        SceneManager.LoadScene("ScenaMatchMaking");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public System.Collections.IEnumerator CheckInternetConnection(Action<bool> action)
    {

        UnityWebRequest www = UnityWebRequest.Get("http://numbers.jemaka.it");
        yield return www.SendWebRequest();

        if (www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }

    }

  




    void showToast(string text, int duration)
    {
        StartCoroutine(showToastCOR(text, duration));
    }

    private IEnumerator showToastCOR(string text,int duration)
    {
        Color orginalColor = txtToastLabel.color;

        txtToastLabel.text = text;
        txtToastLabel.enabled = true;

        //Fade in
        yield return fadeInAndOut(txtToastLabel, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(txtToastLabel, false, 0.5f);

        txtToastLabel.enabled = false;
        txtToastLabel.color = orginalColor;
    }

    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = Color.clear;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }



}
