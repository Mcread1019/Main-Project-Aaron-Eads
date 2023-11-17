using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Economy : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI MoneyText;
   
    private int Money = 5000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Money" + Money);
        if (Input.GetKeyDown(KeyCode.Q))
            {

                Money = Money - 500;
            MoneyText.text = "Money: " + Money;

            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Money = Money - 500;
            MoneyText.text = "Money: " + Money;

        }
            if (Input.GetKeyDown(KeyCode.E))
            {
            Money = Money - 1000;
            MoneyText.text = "Money: " + Money;
        }
            if (Input.GetKeyDown(KeyCode.R))
            {
            Money = Money - 1000;
            MoneyText.text = "Money: " + Money;
        }
        }

        
   
}
