using UnityEngine;

public class StatSheet: MonoBehaviour
{

    public int MHP;
    public int CHP;
    public int DEF;
    public int ATK;
    public int CRIT;
    public int SPD;
    public int ENR;
    public int SENR;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CHP = MHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}