﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float addedHealth;
    public GameObject spawnObject;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null &&  health.health > 0)
        {
            health.AddHealth(addedHealth);
            Game.Score += 10;
            if(spawnObject != null)
            {
                GameObject gameObject = Instantiate(spawnObject, transform.position, transform.rotation);
                Destroy(gameObject, 2);
            }
            Destroy(gameObject);
        }
    }
}
