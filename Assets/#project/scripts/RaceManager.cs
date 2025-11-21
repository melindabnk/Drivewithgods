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
    
     */
    #endregion

    public RaceState state;
    public GameObject textMeshPro;
    public GameObject startText;
    KardController kc;
    IAController ic;




    void Start()
    {
        textMeshPro.SetActive(false);
        kc = FindAnyObjectByType<KardController>();
        ic = FindAnyObjectByType<IAController>();   
       
        state = RaceState.waiting;
        kc.controlOff();
        ic.controlOff();
        StartCoroutine(startTextCoroutine());
      


    }

    

    void Update()
    {

    }
    IEnumerator startTextCoroutine()
    {
        
        startText.SetActive(true);
        yield return new WaitForSeconds(3f);
        startText.SetActive(false);
       
        StartRace();

    }

    public void StartRace()
    {
        state = RaceState.racing;  
        kc.controlOn();
        ic.controlOn();
        textMeshPro.SetActive(false);
    }

    public void FinishRace()
    {
        state = RaceState.finish;
        kc.controlOff();
        //ic.controlOff();
        textMeshPro.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FinishRace();

        }
    }


}
