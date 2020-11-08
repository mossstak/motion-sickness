using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Acceleration : MonoBehaviour {
    public GameObject Boat;
    public GameObject SteeringWheel;
    public Vector3 COM;
    public float speed = 0f;
    float maxSpeed = 20f;
    float accel = .2f;
    public float steerSpeed = 1.0f;
    public float movementThreshold = 10.0f;



    
    Transform m_COM;
    float verticalInput;
    float Reverse_verticalInput;
    float movementFactor;
    float horizontalInput;
    float steerFactor;
    private float maxTurnAngle = 45.0f;



    // Update is called once per frame
    void Update()
    {
        Balance();
        Forward();
       posRightLeft();
    }

    void Balance()
    {
        if (!m_COM)
        {
            m_COM = new GameObject("CON").transform;
            m_COM.SetParent(transform);
        }

        m_COM.position = COM + transform.position;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }

    void Forward()
    {
        verticalInput = Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") * 1.0f;
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
        Boat.transform.Translate(0.0f, 0.0f, movementFactor * maxSpeed);
    }

    void posRightLeft()
    {
        horizontalInput = Input.GetAxis("Horizontal") * 1.0f;
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * verticalInput, Time.deltaTime / movementThreshold);
        Boat.transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
        //transform.localEulerAngles = Vector3.left * Mathf.MoveTowardsAngle(-maxTurnAngle, steerFactor * steerSpeed, maxTurnAngle);
        SteeringWheel.transform.localEulerAngles = Vector3.forward * Mathf.Clamp((Input.GetAxis("Horizontal") * 100), -maxTurnAngle, maxTurnAngle);
    }
}
