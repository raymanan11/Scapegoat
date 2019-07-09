using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Spacecraft : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;
    [SerializeField] float xMax = 15f;
    [SerializeField] float xMin = -15f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float xMvmt = CrossPlatformInputManager.GetAxis("Horizontal"); // generic horizontal input for keyboard and controller
        float xOffset = xMvmt * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset; //changes the local x transform of the Spacecraft but doesn't restrict movement
        float xPos = Mathf.Clamp(rawXPos, xMin, xMax); //restricts the movement of the spacecraft to only move from -15 to 15 units

        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
    }
}
