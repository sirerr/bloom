using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeController : MonoBehaviour
{

    public int counter = 0;
    public int StarCount = 0;
    public SpriteRenderer Poke;
  
    public void StarWatcher()
    {
        counter++;
        if(counter ==StarCount)
        {
            StartCoroutine(MakeThemAppear());
        }

    }

    public void Awake()
    {
       // StarWatcher();
    }

    IEnumerator MakeThemAppear()
    {
        Color col = Poke.color;
        float Avalue = 0;
        
        while(Avalue<=1f)
        {
            Avalue += .025f;
            col.a = Avalue;
            Poke.color = col;
            yield return new WaitForSeconds(.1f);
        }
        
    }
}
