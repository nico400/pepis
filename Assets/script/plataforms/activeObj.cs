using System.Collections.Generic;
using UnityEngine;

public class activeObj : MonoBehaviour
{
    [SerializeField] List<activedCristal> cristalActNecess = new List<activedCristal>();
    [SerializeField] GameObject actThisObj;

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
    }
}
