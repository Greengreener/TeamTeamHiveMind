using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject cameraPrefab;
    [SerializeField] GameObject eggPrefab;
    [Header("Spawning")]
    [SerializeField] GameObject[] spawnPlayerLocation;
    [SerializeField] int spawnPlayerId;
    [SerializeField] GameObject[] spawnEggLocation;
    [SerializeField] int spawnEggId;

    void Start()
    {
        spawnPlayerLocation = GameObject.FindGameObjectsWithTag("SpawnPlayer");
        spawnEggLocation = GameObject.FindGameObjectsWithTag("SpawnEgg");
        SetPlayerSpawn();
        SetEggSpawn();
    }
    void SetPlayerSpawn()
    {
        spawnPlayerId = Random.Range(0, spawnPlayerLocation.Length - 1);
        Instantiate(playerPrefab, spawnPlayerLocation[spawnPlayerId].transform.position, Quaternion.identity);
        Instantiate(cameraPrefab, spawnPlayerLocation[spawnPlayerId].transform.position, Quaternion.identity);
    }
    void SetEggSpawn()
    {
        spawnEggId = Random.Range(0, spawnEggLocation.Length - 1);
        Instantiate(eggPrefab, spawnEggLocation[spawnEggId].transform.position, Quaternion.identity);
    }
}
