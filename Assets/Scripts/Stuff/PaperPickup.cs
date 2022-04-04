using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPickup : MonoBehaviour
{
    public GameObject spawnObject;

    private void OnTriggerEnter(Collider other)
    {
        if (spawnObject != null)
        {
            //GameObject gameObject = Instantiate(spawnObject, transform.position, transform.rotation);
            Destroy(gameObject, 2);
            GameSession.Instance.AddPoints(1);
        }
    }
}
