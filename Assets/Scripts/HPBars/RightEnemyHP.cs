using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightEnemyHP : MonoBehaviour
{

    [SerializeField] private StatVariables StatVariables;
    [SerializeField] private Slider Bar;
    public float sliderdecimal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        sliderdecimal = (float)(StatVariables.HitPoints) / (float)(StatVariables.Vitality.Value);
        Bar.value = sliderdecimal;


    }
}