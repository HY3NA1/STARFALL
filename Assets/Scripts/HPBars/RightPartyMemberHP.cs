using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightPartyMemberHP : MonoBehaviour
{
    private GameObject[] PartyMembers;
    private List<GameObject> CurrentlyActive = new List<GameObject>();
    private GameObject CurrentlyTracking;
    private StatVariables StatVariables;
    public float sliderdecimal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PartyMembers = GameObject.FindGameObjectsWithTag("PartyMember");
        UpdateActive();
    }

    // Update is called once per frame
    void Update()
    {
        sliderdecimal = (float)(CurrentlyTracking.GetComponent<StatVariables>().HitPoints)/(float)(CurrentlyTracking.GetComponent<StatVariables>().Vitality.Value);
        gameObject.GetComponent<Slider>().value = sliderdecimal;
    }

    private void UpdateActive() 
    {
        CurrentlyActive.Clear();
        for (int i = 0; i < PartyMembers.Length; i++)
        {

            StatVariables = PartyMembers[i].GetComponent<StatVariables>();
            if (StatVariables.IsActive && !StatVariables.IsDead)
            {
                CurrentlyActive.Add(PartyMembers[i]);
            }
        }
        for (int i = 0; i < CurrentlyActive.Count; i++) 
        { 
            if (CurrentlyActive[i].GetComponent<StatVariables>().IsOnRight) 
            { 
                CurrentlyTracking = CurrentlyActive[i];
            }
        }
    }
}
