using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    [SerializeField] HUD playerHUD;
    [Header("Prefabs")]
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject cameraPrefab;
    [SerializeField] GameObject eggPrefab;
    [Header("Spawning")]
    [SerializeField] GameObject[] spawnPlayerLocation;
    [SerializeField] int spawnPlayerId;
    [SerializeField] GameObject[] spawnEggLocation;
    [SerializeField] int spawnEggId;
    [Header("Timer")]
    [SerializeField] float startTime = 360;
    [SerializeField] float eggTime = 120;
    [SerializeField] float timeDown;
    [SerializeField] string mins;
    [SerializeField] string secs;
    [SerializeField] string displayType = "f0";
    void Start()
    {

        spawnPlayerLocation = GameObject.FindGameObjectsWithTag("SpawnPlayer");
        spawnEggLocation = GameObject.FindGameObjectsWithTag("SpawnEgg");
        SetPlayerSpawn();
        SetEggSpawn();
        timeDown = startTime;
        playerHUD = GameObject.FindObjectOfType<HUD>();
    }
    void FixedUpdate()
    {
        timeDown -= Time.deltaTime;
        if (timeDown > 0) TimerDown();
        else EndOfTime();
        playerHUD.timerText.text = mins + " : " + secs;
    }
    void TimerDown()
    {
        mins = ((int)timeDown / 60).ToString();
        secs = (timeDown % 60).ToString(displayType);
    }
    public void EggCaptured()
    {
        timeDown = eggTime;
        playerHUD.timerText.color = Color.red;
        displayType = "f2";
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
    void EndOfTime()
    {
        mins = 0.ToString();
        secs = 0.ToString("f0");
        print("EndOfTime");
    }
}
