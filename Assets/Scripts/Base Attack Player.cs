using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Base_Attack_Player : MonoBehaviour
{
    private GameObject player;
    private GameObject target;
    private StatSheet targetstats;
    private StatSheet playerstats;
    private int playeratk;
    private int targetdef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("EnemyA");
        player = GameObject.Find("PlayerA");
        targetstats = target.GetComponent<StatSheet>();
        playerstats = player.GetComponent<StatSheet>();
        playeratk = playerstats.ATK;
        targetdef = targetstats.DEF;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

   public void baseattack()
    {
        Debug.Log("Attacked");
        int DMG = playeratk - targetdef;
        targetstats.CHP = targetstats.CHP - DMG;
        
    }


}
