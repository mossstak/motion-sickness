using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

[RequireComponent(typeof(Rigidbody))]

public class BoatMovement : MonoBehaviour {
    [AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_ControllerEvents")]

    public GameObject SteeringWheel;
    public GameObject Boat;
    public Vector3 COM;
    public float speed = 5f;
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
        SteerFoward();
        Forward();
        Backward();
        SteerBackward();
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

    void Backward()
    {
        Reverse_verticalInput = Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") * -1.0f;
        movementFactor = Mathf.Lerp(movementFactor, Reverse_verticalInput, Time.deltaTime / movementThreshold);
        Boat.transform.Translate(0.0f, 0.0f, movementFactor * speed);
    }

    void Forward()
    {
        verticalInput = Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") * 1.0f;
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
        Boat.transform.Translate(0.0f, 0.0f, movementFactor * speed);
    }

    void SteerFoward()
    {
        horizontalInput = Input.GetAxis("Horizontal") * 1.0f;
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * verticalInput, Time.deltaTime / movementThreshold);
        Boat.transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
        //transform.localEulerAngles = Vector3.left * Mathf.MoveTowardsAngle(-maxTurnAngle, steerFactor * steerSpeed, maxTurnAngle);
        SteeringWheel.transform.localEulerAngles = Vector3.forward * Mathf.Clamp((Input.GetAxis("Horizontal") * 100), -maxTurnAngle, maxTurnAngle);
    }

    void SteerBackward()
    {
        horizontalInput = Input.GetAxis("Horizontal") * -1.0f;
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * Reverse_verticalInput, Time.deltaTime / movementThreshold);
        Boat.transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
        //transform.localEulerAngles = Vector3.left * Mathf.MoveTowardsAngle(-maxTurnAngle, steerFactor * steerSpeed, maxTurnAngle);
        SteeringWheel.transform.localEulerAngles = Vector3.forward * Mathf.Clamp((Input.GetAxis("Horizontal") * 100), -maxTurnAngle, maxTurnAngle);
    }   
}
