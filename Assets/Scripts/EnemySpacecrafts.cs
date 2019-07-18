using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpacecrafts : MonoBehaviour
{
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
    }

    private void AddBoxCollider() {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) {
        GameObject deathFX = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);// Before destroying the enemy, there has to be an explosion dropped or instantiated 
                                                                                                //at the position of enemy with no roation
        deathFX.transform.parent = parent;
        Destroy(gameObject); //when it is attached to the enemy gameobjects, it will print out
    }
}
