using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Spacecraft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float horizontalMvmt = CrossPlatformInputManager.GetAxis("Horizontal"); // generic input for keyboard and controller
        print(horizontalMvmt);
    }
}
