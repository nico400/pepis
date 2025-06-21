using System.Collections.Generic;
using UnityEngine;

public class activeObj : MonoBehaviour
{
    [SerializeField] List<activedCristal> cristalActNecess = new List<activedCristal>();
    [SerializeField] GameObject actThisObj;

    [SerializeField] bool itsKeyAct;

    public delegate void OnKeyActiving();
    public static event OnKeyActiving _Onkey;

    public static bool stop = false;


    private void Awake()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool allAct = true;

        for (int i = 0; i < cristalActNecess.Count; i++)
        {
            if (!cristalActNecess[i].actived)
            {
                allAct = false;
                break; // já pode sair do loop, pois um já está falso
            }
        }

        actThisObj.SetActive(allAct);

        if (itsKeyAct && allAct && !stop)
        {
            _Onkey?.Invoke();
        }
            
    }
}
