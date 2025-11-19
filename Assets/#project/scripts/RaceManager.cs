using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class RaceManager : MonoBehaviour
{
    #region commentaires
    /*
   
    2. nombre de ia et player
    3. enregistre quand le nbr de joueur a été dans la box finish pour terminer course
    4. envoyer le signal de depart 
    5.

     
     */
    #endregion

    public RaceState state;
   
    public GameObject textMeshPro;
    KardController kc;
    IAController ic;



    void Start()
    {
        textMeshPro.SetActive(false);
        kc = FindAnyObjectByType<KardController>();
        state = RaceState.waiting;
        kc.controlOff();
        StartRace();
    }

    

    void Update()
    {
        
    }

    public void StartRace()
    {
        state = RaceState.racing;  
        kc.controlOn();
        ic.controlOn();
        textMeshPro.SetActive(false);
        Debug.Log("StartRace (RaceManager)");
    }

    public void FinishRace()
    {
        state = RaceState.finish;
        kc.controlOff();
        ic.controlOff();
        textMeshPro.SetActive(true);
        Debug.Log("FinishRace (RaceManager)");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FinishRace();

        }
    }


}
