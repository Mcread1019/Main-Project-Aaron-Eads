using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCon : MonoBehaviour
{
    public static int Energy = 0;
    public static int iron_ore = 0;
    public static int iron = 0;


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Energy: "+Energy + "  " +"IronOre"+ iron_ore+"iron"+iron);
    }
}
