using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour {
    public GameObject Boat;
    public float frequencyMin = 1.0f;
    public float frequencyMax = 2.0f;
    public float magnitude = 0.0025f;
    private float randomInterval;

    void Start()
    {
        randomInterval = Random.Range(frequencyMin, frequencyMax);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += (Mathf.Cos(Time.time * randomInterval) * magnitude);
        Boat.transform.position = pos;

        //Vector3 angle = transform.eulerAngles;
        //angle.y += (Mathf.Cos(Time.time * randomInterval) * 2);
        //Boat.transform.eulerAngles = angle;
    }
}
