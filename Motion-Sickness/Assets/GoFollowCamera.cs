using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFollowCamera : MonoBehaviour {
    public Transform objectToFollow;

    public float distanceFromObject = 6f;

    void Update()
    {
        Vector3 lookOnObject = objectToFollow.position - transform.position;

        lookOnObject = objectToFollow.position - transform.position;
        transform.forward = lookOnObject.normalized;

        Vector3 PlayerLastPosition;
        PlayerLastPosition = objectToFollow.position - lookOnObject.normalized * distanceFromObject;

        PlayerLastPosition.y = objectToFollow.position.y + distanceFromObject / 2;

        transform.position = PlayerLastPosition;
    }
}
