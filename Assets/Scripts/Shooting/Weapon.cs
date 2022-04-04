using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Range(0, 3)]public float fireRate = 0.1f;
    [Range(0, 100)]public float fireAngle = 10.0f;
    public int ammoMax = 100;
    public GameObject projectile;
    public Transform emitTransform;

    protected float firetimer = 0;
    protected int ammo = 100;

    void Update()
    {
        firetimer += Time.deltaTime;
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        if(firetimer >= fireRate)
        {
            firetimer = 0;

            GameObject gameObject = Instantiate(projectile, position, Quaternion.identity);
            gameObject.GetComponent<Projectile>().Fire(direction);
            return true;
        }
        return false;
    }

    public bool Fire(Vector3 direction)
    {
        if(firetimer >= fireRate)
        {
            firetimer = 0;

            GameObject gameObject = Instantiate(projectile, emitTransform.position, emitTransform.rotation);
            gameObject.GetComponent<Projectile>().Fire(direction);
            return true;
        }
        return false;
    }
}
