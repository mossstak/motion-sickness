using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingBoat : MonoBehaviour
{

    public float yOffset = 0.5f;
    public GameObject Boat;

    void Update()
    {
        //simulate some noat motion - you can change the values until it look right
        //get the transform
        Vector3 position = transform.position;
        //rock the boat in y using a cos function wrt time
        //0.5
        position.y = 0f + (Mathf.Cos(Time.time) * 0.06f) - 0.15f;
        //assign this to the tranform
        Boat.transform.position = position;
        //The x, y, and z euler angles represent a rotation z degrees
        //around the z axis, x degrees around the x axis, 
        //and y degrees around the y axis (in that order)

        Vector3 angles = transform.eulerAngles;
        //rock the boat in x and z using a sin function wrt time
        angles.x = Mathf.Sin(Time.time) * 3.0f;
        angles.z = Mathf.Sin(Time.time * 0.8f) * 3.0f;
        Boat.transform.eulerAngles = angles;
    }
}
