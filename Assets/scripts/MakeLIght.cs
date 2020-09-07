using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLIght : MonoBehaviour
{
    public GameObject orb;
    Vector3 tempPos;
    public float MaxDistance=2f;
    public Transform MakeSpot;


    // Start is called before the first frame update
    void Start()
    {
        tempPos = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(tempPos, transform.position);
        if(dis>MaxDistance)
        {
            Instantiate(orb, MakeSpot.position, Quaternion.identity);
            tempPos = transform.position;
        }
    }
}
