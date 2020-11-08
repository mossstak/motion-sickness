using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    public float moveForce = 0f;
    private Rigidbody rigidbody;
    public Vector3 moveDir;
    public LayerMask whatiswall;
    public float maxDistFromWall = 0f;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        moveDir = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
	
	// Update is called once per frame
	void Update () {
        rigidbody.velocity = moveDir * moveForce;
        
        if (Physics.Raycast(transform.position, transform.forward, maxDistFromWall, whatiswall))
        {
            moveDir = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
	}

    Vector3 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 3);
        Vector3 temp = new Vector3();

        if(i == 0)
        {
            temp = transform.forward;
        }
        else if (i == 1)
        {
            temp = -transform.forward;
        }
        else if (i == 2)
        {
            temp = transform.right;
        }
        else if (i == 3)
        {
            temp = -transform.right;
        }

        return temp;
    }
}
