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
    [SerializeField] GameObject nestPrefab;
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
    [Header("Win")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject nest;
    [SerializeField] GameObject camBase;
    [SerializeField] AnimController animController;
    [SerializeField] CameraControls[] camCon = new CameraControls[2];
    [SerializeField] Collider winTrigger;
    [SerializeField] bool eggReturned;
    [SerializeField] bool eggSacrificed;
    [SerializeField] bool endOfTime = true;
    [SerializeField] bool endOfGame = false;
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
        if (timeDown <= 0) TimerFinished();
        if (!endOfGame) TimerDown();
        if (endOfGame)
        {
            if (endOfTime) EndOfTime();
            camBase.transform.position = player.transform.position;
            camBase.transform.Rotate(0, 0.5f, 0);
        }
        playerHUD.timerText.text = mins + " : " + secs;
    }
    void TimerDown()
    {
        timeDown -= Time.deltaTime;
        mins = ((int)timeDown / 60).ToString();
        secs = (timeDown % 60).ToString(displayType);
    }
    void TimerFinished()
    {
        mins = 0.ToString();
        secs = 0.ToString("f0");
    }
    public void EggCaptured()
    {
        winTrigger.enabled = true;
        timeDown = eggTime;
        playerHUD.timerText.color = Color.red;
        displayType = "f2";
    }
    void SetPlayerSpawn()
    {
        spawnPlayerId = Random.Range(0, spawnPlayerLocation.Length);
        Instantiate(playerPrefab, spawnPlayerLocation[spawnPlayerId].transform.position, Quaternion.identity);
        Instantiate(cameraPrefab, spawnPlayerLocation[spawnPlayerId].transform.position, Quaternion.identity);
        Instantiate(nestPrefab, spawnPlayerLocation[spawnPlayerId].transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("DinoPlayer");
        nest = GameObject.FindGameObjectWithTag("Nest");
        camBase = GameObject.FindGameObjectWithTag("CameraBase");
        animController = FindObjectOfType<AnimController>();
        camCon = FindObjectsOfType<CameraControls>();
        winTrigger = nest.GetComponent<Collider>();
    }
    void SetEggSpawn()
    {
        spawnEggId = Random.Range(0, spawnEggLocation.Length);
        Instantiate(eggPrefab, spawnEggLocation[spawnEggId].transform.position, Quaternion.identity);
    }
    public void ReturnedEgg()
    {
        eggReturned = true;
        endOfGame = true;

    }
    public void Sacrifice()
    {
        eggSacrificed = true;
        endOfGame = true;

    }
    public void EndOfTime()
    {
        endOfGame = true;
        //mins = 0.ToString();
        //secs = 0.ToString("f0");
        //print("EndOfTime");
        if (eggSacrificed)
        {
            playerHUD.sacrificeScreen.SetActive(true);
        }
        else
        {
            switch (eggReturned)
            {
                case false:
                    playerHUD.failScreen.SetActive(true);
                    break;
                case true:
                    playerHUD.winScreen.SetActive(true);
                    break;
            }
        }
        player.GetComponent<PlayerInput>().enabled = false;
        animController.isMovable = false;
        camCon[0].enabled = false;
        camCon[1].enabled = false;
        playerHUD.menuHolder.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endOfTime = false;
    }
}