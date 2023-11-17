using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatCon : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ore;
    [SerializeField] TextMeshProUGUI Coal;
    [SerializeField] TextMeshProUGUI power;
    [SerializeField] TextMeshProUGUI Iron;
    public static int Energy = 100;
    public static int iron_ore = 0;
    public static int iron = 0;
   
    public static int coal = 100;


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Energy: " + Energy + "  " + "IronOre" + iron_ore + "iron" + iron + "Coal" + coal);
        ore.text = "Iron ore: " + iron_ore;
        Iron.text = "Iron " + iron;
        power.text = "Power: " + Energy;
        Coal.text = "Coal: " + coal;
    }
}
