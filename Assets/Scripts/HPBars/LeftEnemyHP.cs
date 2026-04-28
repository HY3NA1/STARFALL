using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LefteNEMYHP : MonoBehaviour
{
    private GameObject[] Enemies;
    private List<GameObject> CurrentlyActive = new List<GameObject>();
    private GameObject CurrentlyTracking;
    private StatVariables StatVariables;
    public float sliderdecimal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        UpdateActive();
    }

    // Update is called once per frame
    void Update()
    {
 
        
        sliderdecimal = (float)(StatVariables.HitPoints) / (float)(StatVariables.Vitality.Value);
        gameObject.GetComponent<Slider>().value = sliderdecimal;
        
        
    }

    private void UpdateActive()
    {
        CurrentlyActive.Clear();
        for (int i = 0; i < Enemies.Length; i++)
        {

            StatVariables = Enemies[i].GetComponent<StatVariables>();
            if (StatVariables.IsActive && !StatVariables.IsDead)
            {
                CurrentlyActive.Add(Enemies[i]);
            }
        }
        for (int i = 0; i < CurrentlyActive.Count; i++)
        {
            if (CurrentlyActive[i].GetComponent<StatVariables>().IsTargetLeft)
            {
                CurrentlyTracking = CurrentlyActive[i];
                StatVariables = CurrentlyTracking.GetComponent<StatVariables>();
            }
        }
    }
}