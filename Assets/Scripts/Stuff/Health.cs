using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float healthMax = 100;
    public float decay;
    public Slider slider;
    public GameObject destroySpawnObject;
    public static bool gameStarted = false;
    public UnityEvent deathEvent;
    public bool destroyOnDeath = false;

    public float health { get; set; }
    public bool isDead { get; set; } = false;

    void Start()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            AddHealth(-Time.deltaTime * decay);
        }
        if(slider != null) slider.value = health / healthMax;

        if (health <= 0 && !isDead)
        {
            isDead = true;
            deathEvent?.Invoke();
            if(destroySpawnObject != null)
            {
                Instantiate(destroySpawnObject, transform.position, transform.rotation);
            }
            if (destroyOnDeath) GameObject.Destroy(gameObject);
        }
    }

    public void AddHealth(float moreHealth)
    {
        health += moreHealth;
        health = Mathf.Clamp(health, 0, healthMax);
    }

    public void Reset()
    {
        Start();
        gameStarted = false;
    }
}
