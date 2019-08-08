using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider other) {
        Death();
        print("Hit");
    }

    void Death() {
        DeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void DeathSequence() { // only to turn controls off and by using SendMessage, it will communicate with the script that deals with spacecraft movement and stop
        SendMessage("FighterJetDeath"); 
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(1);
    }
}
