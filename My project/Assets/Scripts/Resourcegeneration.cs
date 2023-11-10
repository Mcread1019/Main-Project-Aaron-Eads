using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resourcegeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("Power"))
        {
            StartCoroutine(energyGen());
        }

        if (gameObject.name.Contains("IronMiner"))
        {
            StartCoroutine(ironGen() );
        }
        if (gameObject.name.Contains("IronMiner"))
        {
            StartCoroutine(REironGen() );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(5);
        StatCon.Energy += 10;
        StartCoroutine(energyGen());
        
    }

    IEnumerator ironGen()
    {
        yield return new WaitForSeconds(5);
        StatCon.iron_ore += 10;
        StatCon.Energy -= 10;
        StartCoroutine(ironGen());

    }
    IEnumerator REironGen()
    {
        yield return new WaitForSeconds(10);
        StatCon.iron += 10;
        StatCon.Energy -= 10;
        StartCoroutine(REironGen());

    }
}
