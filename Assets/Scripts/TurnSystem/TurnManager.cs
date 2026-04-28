using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TurnManager : MonoBehaviour
{
    private GameObject[] PartyMembers;
    private GameObject[] Enemies;
    public GameObject CharToGoNext;
    public GameObject CharToMoveLast;
    public List<GameObject> AllActive = new List<GameObject>();
    public List<GameObject> ActiveInTurnOrder = new List<GameObject>();
    private StatVariables StatVariables;
    public int HighestAgility;
    public int LowestAgility;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PartyMembers = GameObject.FindGameObjectsWithTag("PartyMember");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        HighestAgility = int.MinValue;
        LowestAgility = int.MaxValue;
        BeginRound();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void BeginRound()
    {
        AllActive.Clear();
        ActiveInTurnOrder.Clear();
        //Finds Both Party Members on the battle field, so long as they arent dead and adds them to the list of characters activly taking turns
        for (int i = 0; i < PartyMembers.Length; i++)
        {
            
            StatVariables = PartyMembers[i].GetComponent<StatVariables>();
            if (StatVariables.IsActive && !StatVariables.IsDead)
            {
                AllActive.Add(PartyMembers[i]);
            }
        }


        //Adds All living enemies to the list of characters active in the game
        for (int i = 0;i < Enemies.Length; i++) 
        {
            StatVariables = Enemies[i].GetComponent<StatVariables>();
            if (!StatVariables.IsDead) 
            {
                AllActive.Add(Enemies[i]);
            }
        }

        //Adds List of activce characters to List of characters that still need to take turns
        for (int i = 0; i < AllActive.Count; i++)
        {
            ActiveInTurnOrder.Add(AllActive[i]);
        }
        
        WhoNext();

    }

    public void WhoNext() 
    {
        HighestAgility = int.MinValue;
        //Gets the next character in the turn order and finds the last character to move
        for (int i = 0; i < ActiveInTurnOrder.Count; i++)
        {
            StatVariables = ActiveInTurnOrder[i].GetComponent<StatVariables>();
            if (StatVariables.Agility.Value > HighestAgility)
            {
                HighestAgility = StatVariables.Agility.Value;
                CharToGoNext = ActiveInTurnOrder[i];
            }
            if (StatVariables.Agility.Value < LowestAgility)
            {
                LowestAgility = StatVariables.Agility.Value;
                CharToMoveLast = AllActive[i];

            }

        }

        //Double Check to make sure the character is not dead and  is still in play
        if (CharToGoNext.GetComponent<StatVariables>().IsDead && !CharToGoNext.GetComponent<StatVariables>().IsActive)
        {
            Debug.Log("Caught Dead/Inactive Character in turn order");
            ActiveInTurnOrder.Remove(CharToGoNext);
            WhoNext();
        }
        else
        {
            CharToGoNext.GetComponent<StatVariables>().IsTurn = true;
            TakeTurn();
        }

    }

    public void TakeTurn()
    {


        //Make Script Wait until IsTurn = False
        StartCoroutine(WaitForTurn());
        
    }

    IEnumerator WaitForTurn()
    {
        Debug.Log("Waiting For Turn");
        while (CharToGoNext.GetComponent<StatVariables>().IsTurn == true) 
        {
            yield return null;
        }
        Debug.Log("Done waiting!");
        TurnCleanUp();
        StopCoroutine(WaitForTurn());
    }



    public void TurnCleanUp() 
    {
        Debug.Log("Cleaning up turn");
        if ((CharToGoNext.GetComponent<StatVariables>().Agility.Value / 2) > CharToMoveLast.GetComponent<StatVariables>().Agility.Value)
        {
            Debug.Log("Checking if speed 2x");
            CharToGoNext.GetComponent<StatVariables>().Agility.AddModifier(new StatModifier(0.5f, StatModType.PercentAddDecrease, gameObject, -1));
        }
        else
        {
            Debug.Log("Removing Active Character from turn order");
            ActiveInTurnOrder.Remove(CharToGoNext);
        }

        if (CharToGoNext == CharToMoveLast)
        {
            Debug.Log("Cleaning up round");

            RoundCleanUp();
        }
        else 
        {
            Debug.Log("Checking Whoes Next");
            WhoNext();
        }
    }

    public void RoundCleanUp() 
    {
        for (int i = 0; i < AllActive.Count; i++)
        {
            AllActive[i].GetComponent<StatVariables>().Agility.RemoveAllModifiersFromSource(gameObject);
        }
        BeginRound();
    }

 }
