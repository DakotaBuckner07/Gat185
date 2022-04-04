using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum eType
    {
        TimerRepeat,
        TimeOneTime,
        Event
    }

    public GameObject spawnGameObject;
    public float SpawnTimeMin = 2;
    public float SpawnTimeMax = 5;
    public bool isSpawnChild = true;
    float spawnTimer;
    int spawnCount = 0;

    public eType type = eType.TimerRepeat;

    void Start()
    {
        spawnTimer = Random.Range(SpawnTimeMin, SpawnTimeMax);
    }

    void Update()
    {

        if (transform.childCount == 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        if (spawnTimer <= 0 && (type == eType.TimerRepeat || (type == eType.TimeOneTime && spawnCount == 0)))
        {
            spawnTimer = Random.Range(SpawnTimeMin, SpawnTimeMax);
            OnSpawn();
        }
    }

    public void OnSpawn()
    {
        spawnCount++;
        Transform parent = (isSpawnChild) ? transform : null;
        Instantiate(spawnGameObject, transform.position, transform.rotation, parent);
    }
}
