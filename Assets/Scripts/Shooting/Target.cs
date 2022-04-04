using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 0;
    public Material material;
    public GameObject destroyGameObject;

    void Start()
    {
        GetComponent<Renderer>().material = material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Game.Instance.AddPoints(points);
            Destroy(this.gameObject);
        }
    }
}
