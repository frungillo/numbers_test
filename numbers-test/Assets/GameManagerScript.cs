﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class GameManagerScript : MonoBehaviour
{
    /// <summary>
    /// Testo punteggio parziale
    /// </summary>
    //[Header("Provamia")]
    [Tooltip("Testo punteggio parziale")]
    public Text txtParziale;

    [Tooltip("Punteggio totale")]
    public Text txtPunteggio;

    [Tooltip("Timer")]
    public Text txtTimer;

    [Tooltip("Livello")]
    public Text txtLevel;



    [Header("Campi Soluzioni")]
    public List<Text> GoalsTexts;

    [Header("Lista Effetti Sonori")]
    public List<AudioClip> EffettiSonori;


    /// <summary>
    /// Griglia di gioco
    /// </summary>
    public Grids griglia;

    private static int BASE_POINTS = 2;

    private int BONUS_X=1;

    
   
    float timeleft = 120;
    private string numeroTrovatoDalGiocatore;

    /*Componenti Fumetto*/
    public GameObject Comic;
    private Animator ComicAnimator;
    private SpriteRenderer ComicSprite;

    public bool inError;
    UnityWebRequest srv;
    public List<GameObject> esagoniSelezionati;
    //private Time t;
    List<GameObject> esagoniInGriglia;
    Solutions[] soluzioniGriglia;
    List<Solutions> soluzioniTrovate;

    private bool pointAdded = false; //flag aggiunta punti
    private bool levelWin = false; //flag  di controllo vincita livello
    AudioSource audio_s;

    private GameObject bonusSpc;
    

    private static GameManagerScript _instance;
    
    public static GameManagerScript Instance { get { return _instance; } }

    private void Awake()
    {
        
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
        PlayerPrefs.DeleteAll();
        esagoniInGriglia = new List<GameObject>();
        esagoniSelezionati = new List<GameObject>();
        inError = false;
        griglia = DatiGioco.GrigliaDiGioco;

    



    }
    

    // Start is called before the first frame update
    void Start()
    {
        /*Elemento Bonus_spc*/
        bonusSpc = GameObject.Find("bonus_spc");
        SpriteRenderer spr_bonus = bonusSpc.GetComponent<SpriteRenderer>();
        spr_bonus.sprite = null; //azzero lo sprite
        /* ********************* */

        /*inizializzazione fumetto*/
        ComicAnimator = Comic.GetComponent<Animator>();
        ComicSprite = Comic.GetComponent<SpriteRenderer>();
        ComicSprite.sprite = null;
        /***/

        soluzioniTrovate = new List<Solutions>();

        audio_s = GetComponent<AudioSource>();

        

        txtPunteggio.text = "0";
        if (DatiGioco.PuntiGiocatore > 0) txtPunteggio.text = DatiGioco.PuntiGiocatore.ToString();
        ScriviParziale("", false); // txtParziale.text = "";
        Grids g = griglia;

        ScriviParziale("Griglia #" + g.Id_grid.ToString()); //  txtParziale.text = "Griglia #" + g.Id_grid.ToString();

        string[] arrGridTmp = g.Item.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

        Solutions[] sol = DatiGioco.soluzioni; // g.Soluzioni.ToArray();
        soluzioniGriglia = sol;
        txtLevel.text = DatiGioco.LivelloCorrente.ToString();
        /*
        for (int l = 1; l < griglia.Difficulty + 1; l++)
        {
            GameObject levels = GameObject.Find("lvl_" + l);
            SpriteRenderer lvlspr = levels.GetComponent<SpriteRenderer>();
            if (DatiGioco.LivelloCorrente == l)
            {
                lvlspr.sprite = Resources.Load<Sprite>("Sprites/liv_selector/SVG/Verde/Verde " + l);
            }
            else
            {
                lvlspr.sprite = Resources.Load<Sprite>("Sprites/liv_selector/SVG/Giallo/Giallo " + l);
            }
        }
        */

        int idxTxts = 0;
        foreach (Solutions item in sol)
        {
            GoalsTexts[idxTxts].text = item.Number.ToString();
            GameObject boxSolution = GameObject.Find("Goal_" + idxTxts.ToString());
            GoalsTexts[idxTxts].name = "txtGoal_"+item.Id_solution.ToString();
            boxSolution.name = "Goal_" + item.Id_solution.ToString();
            idxTxts++;
        }

       

        int idxArrayGrid = 0;
        for (int r = 0; r < 7; r++)
        {
            for (int c = 0; c < 5; c++)
            {
                GameObject octagono = GameObject.Find($"t{r}_{c}");
                SpriteRenderer spr = octagono.GetComponent<SpriteRenderer>();
                Comp_Esagono script_exs = octagono.GetComponent<Comp_Esagono>();
                if (octagono.tag != "op")
                {
                    spr.sprite = Resources.Load<Sprite>("Sprites/Exs_Numbers/" + arrGridTmp[idxArrayGrid] + "_g");//GOAL!
                    script_exs.Number = int.Parse(arrGridTmp[idxArrayGrid]);

                } else
                {
                    spr.sprite = Resources.Load<Sprite>("Sprites/operand/" + DecodeOperands(arrGridTmp[idxArrayGrid]));//GOAL!
                    script_exs.Number = int.Parse(DecodeOperands(arrGridTmp[idxArrayGrid]));
                }
                idxArrayGrid++;
                esagoniInGriglia.Add(octagono);
            }
            
        }
        


        /**/


    }
    
    
    private void Valuta(bool endSequence=false)
    {
        try
        {
            double ev = Eval(txtParziale.text);
            if (!endSequence)
            {
                txtPunteggio.text = ev.ToString("#.##");
                PlayerPrefs.SetString("tots", ev.ToString("#.##"));
            }
           // ComicAnimator.SetTrigger("fire");
            /*Cambio Esagoni*/
        }
        catch (System.Exception ex)
        {
            
            txtPunteggio.text = ex.Message;
            //ComicAnimator.SetTrigger("fire");
        }
        
    }

    private string DecodeOperands(string simbol)
    {
        string toAdd="";
        switch (simbol)
        {
            case "*":
                toAdd = "1";
                break;
            case "/":
                toAdd = "2";
                break;
            case "-":
                toAdd = "3";
                break;
            case "+":
                toAdd = "4";
                break;
        }
        return toAdd;
    }

    private bool FumettoVisibile = false;
    private void ScriviParziale(string msg, bool add = true)
    {
        if (msg != "")
        {
            if (!FumettoVisibile)
            {
                ComicSprite.sprite = Resources.Load<Sprite>("Sprites/albert/Fumetto-vuoto");
                ComicAnimator.SetTrigger("fire");
                FumettoVisibile = true;
            }
            

        } else
        {
            //
            
        }
        if (!add) txtParziale.text = msg; else txtParziale.text += msg;
    }

    private string Calcolo()
    {
        double tot=0;
        int cnt = 1;
        string operazione="";
        ScriviParziale("", false);
        foreach (GameObject itm in esagoniSelezionati)
        {
            
            string toAdd = "";
            Comp_Esagono src = itm.GetComponent<Comp_Esagono>();
            if (itm.tag == "op") //è un box operando
            {
                switch (src.Number)
                {
                    case 1:
                        toAdd = "*";
                        break;
                    case 2:
                        toAdd = "/";
                        break;
                    case 3:
                        toAdd = "-";
                        break;
                    case 4:
                        toAdd = "+";
                        break;
                    default:
                        break;

                }
                 ScriviParziale(toAdd); //txtParziale.text += toAdd;
            } else { //è un box numerico
                toAdd = src.Number.ToString();
                itm.transform.position = new Vector3(itm.transform.position.x, itm.transform.position.y, -1);
                ScriviParziale(toAdd); // txtParziale.text += toAdd;
            }
            
            if (cnt < 3) { operazione += toAdd; goto exit; }

            if (cnt==3) {
                operazione += toAdd;
                tot = Eval(operazione);
                operazione = tot.ToString();
                ScriviParziale("=" + operazione); // txtParziale.text += "="+operazione;
            }

            if (cnt > 3)
            {
               
                if (itm.tag == "op")
                {
                    operazione +=  toAdd;
                    ScriviParziale(operazione, false); // txtParziale.text = operazione;
                   
                    goto exit;
                }
                operazione +=  toAdd;
                tot = Eval(operazione);
                operazione = tot.ToString("#.##");
                ScriviParziale("=" + operazione); // txtParziale.text +="="+operazione;
            }
            
        exit:
            
            //txtParziale.text = tot.ToString("#.##");
            cnt++;
        }
        // txtPunteggio.text = tot.ToString("#.##");
        return operazione;
    }
    
    
    // Update is called once per frame
    void Update()
    {

        GameObject timerGraph = GameObject.Find("timer");
        SpriteRenderer timerSpr = timerGraph.GetComponent<SpriteRenderer>();
        
        Animator timerAnim = txtTimer.GetComponent<Animator>();
        timeleft -= Time.deltaTime;
        txtTimer.text = Math.Truncate((timeleft)).ToString();
        
        if(soluzioniTrovate.Count == 5 && !levelWin)
        {

            audio_s.PlayOneShot(EffettiSonori[3], 1F);
            levelWin = true;
            StartCoroutine(GameWin_async());

            if (!pointAdded)
                DatiGioco.PuntiGiocatore += Convert.ToInt32(timeleft);
            pointAdded = true;
            //SceneManager.LoadScene("EndGame");
        }
        if(Mathf.FloorToInt(timeleft) % 12 == 0 )
        {
            timerSpr.sprite = Resources.Load<Sprite>("Sprites/TimerAnim/t_" + (Mathf.FloorToInt(timeleft)/12).ToString());
            if (Mathf.FloorToInt(timeleft) / 12 == 0)
                txtTimer.text = "";
        }

        if (timeleft>20 )
        {
            timerAnim.SetTrigger("tick");
            

        }
        if (timeleft<10)
        {

            timerAnim.SetBool("warn", true);
            if (!audio_s.isPlaying)
                audio_s.PlayOneShot(EffettiSonori[0], 1F);
        }
        if(timeleft <= 0 && !levelWin)
        {
            SceneManager.LoadScene("EndGame");
        }
        
        /*****************Valutazione in caso di stato SCHIACCIATO del dito giocatore*****************/
        if (PlayerPrefs.GetString("Stato") == "G") /*dito sullo schermo*/
        {
           numeroTrovatoDalGiocatore= Calcolo();
        }
        /*********************************************************************************************/

        /***************Valutazione in caso di stato ALTAZO del dito del giocatore********************/
        if (PlayerPrefs.GetString("Stato") == "S") //Dito alzato
        {

            ComicSprite.sprite = null;
            FumettoVisibile = false;

            try
            {
                DatiGioco.PuntiGiocatore += (int)double.Parse(CalcolaPunteggio(numeroTrovatoDalGiocatore, soluzioniGriglia));
                txtPunteggio.text = DatiGioco.PuntiGiocatore.ToString();
                
            }
            catch { }
            
            inError = false;
            PlayerPrefs.DeleteAll();
            ScriviParziale("", false); //txtParziale.text = "";

            foreach (GameObject itm in esagoniInGriglia)
            {
               /*Tutti gli esagoni*/
               
            }
            

            /*
            foreach (GameObject itm in esagoniSelezionati)
            {
                Comp_Esagono scr_e = itm.GetComponent<Comp_Esagono>();
                SpriteRenderer spr = itm.GetComponent<SpriteRenderer>();
                
                //Disattivato il cambio di esagoni al rilascio del mouse
                // if (scr_e.Selected)
                

                scr_e.Selected = false;

                //box_anim.Play("exs_idle");
                if (itm.tag != "op")
                {
                    spr.sprite = Resources.Load<Sprite>("Sprites/Exs_Numbers/" + scr_e.Number.ToString() + "_g");
                } else
                {
                    spr.sprite = Resources.Load<Sprite>("Sprites/operand/" + scr_e.Number.ToString());
                }

            }
            */
            //esagoniSelezionati.Clear();
        }


        

        //txtParziale.text = PlayerPrefs.GetString("tots");
    }


   
    private double Eval(string expression)  
    {
        expression = expression.Replace(",", ".");
        System.Data.DataTable table = new System.Data.DataTable();
        try
        {
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
        catch (System.Exception ex)
        {

            throw new System.Exception(ex.Message + "-->" + expression); //("????");
        }
        
    }


    private string CalcolaPunteggio(string risultatoOperazione, Solutions[] soluzioni)
    {
        risultatoOperazione = risultatoOperazione.Replace(",", ".");
        int punteggioAssegnatoAlGiocatore = 0;
        if (!double.TryParse(risultatoOperazione, out double numeroTrovatoDalGiocatore)) { return "Hey!"; }
        Solutions SoluzioneTrovata = null;
        foreach (Solutions item in soluzioni)
        {
            
            if(item.Number == numeroTrovatoDalGiocatore && !soluzioniTrovate.Contains(item))
            {
                 
                SoluzioneTrovata = item;
                break;
            }
        }
        if (SoluzioneTrovata!=null)
        {
            
            soluzioniTrovate.Add(SoluzioneTrovata);
            punteggioAssegnatoAlGiocatore += BASE_POINTS*BONUS_X;
            GameObject box = GameObject.Find("Goal_"+SoluzioneTrovata.Id_solution.ToString());
            SpriteRenderer spr = box.GetComponent<SpriteRenderer>();
            spr.sprite = Resources.Load<Sprite>("Sprites/boxes/box_v");
            BONUS_X *= 2;
            audio_s.PlayOneShot(EffettiSonori[1], 1F);

            colora("v");
            StartCoroutine(ColoraSelezionati(.5F, "g"));
            if (BONUS_X > 1)
            {
                string spr_bonus_name = "x" + BONUS_X;
                SpriteRenderer spr_bonus = bonusSpc.GetComponent<SpriteRenderer>();
               
                Animator bonus_anim = bonusSpc.GetComponent<Animator>();
                bonus_anim.SetTrigger("test");
                spr_bonus.sprite = Resources.Load<Sprite>("Sprites/bonus/" + spr_bonus_name);
            }

        } else
        {
            BONUS_X = 1;
            audio_s.PlayOneShot(EffettiSonori[2], 1F);
            string spr_bonus_name = "x" + BONUS_X;
            SpriteRenderer spr_bonus = bonusSpc.GetComponent<SpriteRenderer>();
            spr_bonus.sprite = null;

            colora("r");
            StartCoroutine(ColoraSelezionati(.5F, "g"));
            
        }
        return punteggioAssegnatoAlGiocatore.ToString();
    }

    private void colora(string col)
    {
        foreach (GameObject itm in esagoniSelezionati)
        {
            Comp_Esagono scr_e = itm.GetComponent<Comp_Esagono>();
            SpriteRenderer spr = itm.GetComponent<SpriteRenderer>();

            /*Disattivato il cambio di esagoni al rilascio del mouse*/
            /* if (scr_e.Selected)
            /*******************************************************/

            scr_e.Selected = false;

            //box_anim.Play("exs_idle");
            if (itm.tag != "op")
            {
                spr.sprite = Resources.Load<Sprite>("Sprites/Exs_Numbers/" + scr_e.Number.ToString() + "_"+col);
            }
            else
            {
                if (col=="g")
                    spr.sprite = Resources.Load<Sprite>("Sprites/operand/" + scr_e.Number.ToString());
                else
                    spr.sprite = Resources.Load<Sprite>("Sprites/operand/" + scr_e.Number.ToString() + "_" + col);
            }

        }
    }

    IEnumerator GameWin_async()
    {

        yield return new WaitForSeconds(4);


        if (DatiGioco.GrigliaDiGioco.Difficulty == DatiGioco.LivelloCorrente)
            DatiGioco.LivelloCorrente = 0;
        else
            DatiGioco.LivelloCorrente++;
        // Debug.Log("Livello_fine:" + DatiGioco.LivelloCorrente);
        SceneManager.LoadScene("ScenaDownload");
    }

    IEnumerator ColoraSelezionati(float seconds, string col)
    {
        
        yield return new WaitForSeconds(seconds);
        colora(col);
        esagoniSelezionati.Clear();
    }


}
