using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceballControl : MonoBehaviour
{
    // I am adding this to show something lol
    // I am adding this to show something lol
    public enum whoyou {slave,master};
    public whoyou WhoYouState;
    public List<int> ListSpot = new List<int>();
    public List<GameObject> Touchers = new List<GameObject>();

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
        
    }

    private void OnTriggerExit(Collider other)
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
