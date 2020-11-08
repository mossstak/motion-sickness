using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class FOVReduction : MonoBehaviour {

    private Vector3 oldPos;

    public float MaxSpeed = 0f;
    public float MaxFOV = 0.7f;

    private VignetteAndChromaticAberration fovReduction;

	// Use this for initialization
	void Start () {
        oldPos = transform.position;
        fovReduction = GetComponent<VignetteAndChromaticAberration>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = (transform.position - oldPos) / Time.deltaTime;
        oldPos = transform.position;

        float expectedLimit = MaxFOV;
        if(velocity.magnitude < MaxSpeed)
        {
            expectedLimit = (velocity.magnitude / MaxSpeed) * MaxFOV;
        }

        fovReduction.intensity = Mathf.Lerp(fovReduction.intensity, expectedLimit, .01f);
	}
}
