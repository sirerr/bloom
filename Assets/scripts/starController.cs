using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starController : MonoBehaviour
{
    public int chosenSpot = 0;
    public Transform starCenter;
    public bool chosen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chosen)
        {
            float endSpot = Vector3.Distance(transform.position, starCenter.GetChild(chosenSpot).position);
            if(endSpot>.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, starCenter.GetChild(chosenSpot).position, (Time.deltaTime *2));
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        chosen = true;

    }
}
