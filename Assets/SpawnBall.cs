using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    private Vector3 SpawnPos;
    [SerializeField] Transform SpawnPlaceholder;
    [SerializeField] GameObject spawnObject;
    private float newSpawnDuration = 1.0f;

    #region Singleton

    public static SpawnBall Instance; 

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        SpawnPos = SpawnPlaceholder.position;
        SpawnNewObject();
    }

    void SpawnNewObject()
    {
        Instantiate(spawnObject, SpawnPos, Quaternion.identity);
    }

    public void NewSpawnRequest()
    {
        Invoke(methodName: "SpawnNewObject", newSpawnDuration);
    }
}
