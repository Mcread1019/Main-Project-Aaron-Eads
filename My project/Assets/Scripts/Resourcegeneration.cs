using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resourcegeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("CoalMiner"))
        {
            StartCoroutine(coalGen());
        }
        if (gameObject.name.Contains("Power"))
        {
            StartCoroutine(energyGen());
        }

        if (gameObject.name.Contains("IronMiner"))
        {
            StartCoroutine(ironGen() );
        }
        if (gameObject.name.Contains("IronRefiner"))
        {
            StartCoroutine(REironGen() );
        }
        if (gameObject.name.Contains("Base"))
        {
            StartCoroutine(BaseGen());
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
            StatCon.coal -= 10;
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
        yield return new WaitForSeconds(7);
        StatCon.iron += 10;
        StatCon.Energy -= 10;
        StatCon.iron_ore -= 10;
        StartCoroutine(REironGen());

    }
    IEnumerator BaseGen()
    {
        yield return new WaitForSeconds(1);
        StatCon.Energy += 20;
        StartCoroutine(energyGen());

    }
    IEnumerator coalGen()
    {
        yield return new WaitForSeconds(5);
        StatCon.coal+= 10;
        StatCon.Energy -= 10;
        StartCoroutine(coalGen());

    }
}
