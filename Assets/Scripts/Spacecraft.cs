using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Spacecraft : MonoBehaviour {

    [Header("Guns")]
    [SerializeField] GameObject[] bullets;

    [Header("Fighter Jet Speed")]
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 25f; // used to control the speed at which the spaceship moves
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 25f; 

    [Header("Fighter Jet Boundaries")]
    [SerializeField] float xMax = 15f;
    [SerializeField] float xMin = -15f; //used to limit the movement of the ship (x and y)
    [SerializeField] float yMax = 7f;
    [SerializeField] float yMin = -7f;

    [Header("Fighter Jet Position")]
    [SerializeField] float positionPitchFactor = -1f; // number got from moving the rotation and is used to pitch the ship (up and down)
    [SerializeField] float positionYawFactor = 1.5f;

    [Header("Fighter Jet Control Throw")]
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float controlRollFactor = -35f;

    float xMvmt, yMvmt;
    bool controlsOn = true;


    // Update is called once per frame
    void Update() {
        if (controlsOn) {
            SpaceshipPosition();
            SpaceshipRotation();
            SpaceshipShooting();
        }
    }

    
    void FighterJetDeath() { // named from string reference from CollisionController
        controlsOn = false; 
    }

    private void SpaceshipPosition() {
        float xPosition = xControls();
        float yPosition = yControls();

        transform.localPosition = new Vector3(xPosition, yPosition, transform.localPosition.z);
    }

    private float xControls() {
        xMvmt = CrossPlatformInputManager.GetAxis("Horizontal"); // generic horizontal input for keyboard and controller
        float xOffset = xMvmt * xSpeed * Time.deltaTime; // Time.deltaTime is based off of whatever computer you are playing on so the movement is consistent throughout devices
        float rawXPos = transform.localPosition.x + xOffset; //changes the local x transform of the Spacecraft but doesn't restrict movement
        float xPos = Mathf.Clamp(rawXPos, xMin, xMax); //restricts the movement of the spacecraft to only move from -15 to 15 units
        return xPos;
    }

    private float yControls() {
        yMvmt = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yMvmt * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawYPos, yMin, yMax);
        return yPos;
    }

    private void SpaceshipRotation() {
        float pitchPosition = transform.localPosition.y * positionPitchFactor; // to pitch the plane based off of y location not of control throw
        float pitchControlThrow = yMvmt * controlPitchFactor; // to pitch the plane based off of user input and control throw (jerky motion of controller)
        float pitch = pitchPosition + pitchControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor; // to make the nose of the plane stay in front which means it's not user control throw and just x location

        float roll = xMvmt * controlRollFactor; // roll is based on controller throw or keyboard movement which is why xMvmt is needed because it's based off user input

        // pitch (x) and the roll (z) is what needs the ontrol throw meaning xMvmt and yMvmt because it's based off of user input

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void SpaceshipShooting() {
       if (CrossPlatformInputManager.GetButton("Fire")) {
            GunsActive(true);
       }
       else {
            GunsActive(false); 
        }
    }

    private void GunsActive(bool isActive) {
        foreach (GameObject bullet in bullets) {
            var bullets = bullet.GetComponent<ParticleSystem>().emission;
            bullets.enabled = isActive;
        }
    }

    
}
