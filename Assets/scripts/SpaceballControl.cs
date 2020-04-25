using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceballControl : MonoBehaviour
{
    
    public enum whoyou {slave,master};
    public whoyou WhoYouState;
    public int ListCount = -1;
    public List<int> ListSpot = new List<int>();
    public List<GameObject> Touchers = new List<GameObject>();
    public List<LineRenderer> LineRenders = new List<LineRenderer>(); 

    //Movement
    Rigidbody rbody;
    public float speed = 5f;
    public float DirectionValue =3f;
    Vector3 Direction;
    public bool Move = false;
    bool NewMove = true;

    private void Awake()
    {
        rbody = transform.parent.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Move)
        {
            rbody.AddForce(RandomDir() * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int choose;
        choose = Random.Range(0, 2);
        if (choose == 0)
            WhoYouState = whoyou.slave;
        else
            WhoYouState = whoyou.master;
        MakeItHappen(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    public void MakeItHappen(GameObject obj)
    {
        LineRenderer Line = new LineRenderer();
        
        switch (WhoYouState)
        {
            case whoyou.master:
                Line = transform.gameObject.AddComponent<LineRenderer>();
                Line.SetPosition(0, transform.position);
                Line.SetPosition(1, obj.transform.position);
                
                break;

            case whoyou.slave:
                
                break;

        }
        LineRenders.Add(Line);

    }

    public void MakeNotHappen()
    {

    }



    Vector3 RandomDir ()
    {
        Vector3 vec = new Vector3();
        if (NewMove)
        {
            print("testing");
            vec.x = Random.Range(DirectionValue * -1, DirectionValue);
            vec.y = Random.Range(DirectionValue * -1, DirectionValue);
            vec.z = Random.Range(DirectionValue * -1, DirectionValue);
            Direction = vec;
            NewMove = false;
            StartCoroutine(ChooseAgain());
        }
        print(Direction);

        return Direction;
    }

    IEnumerator ChooseAgain()
    {
        yield return new WaitForSeconds(3f);
        NewMove = true;
    }
}
