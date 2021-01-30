using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHolder : MonoBehaviour
{
    [SerializeField] Dino dino;
    [SerializeField] PlayerInput pInput;
    #region Speed variables
    float speedBase;
    float speedUp;
    [SerializeField] bool speedUpBool;
    #endregion
    #region Counters
    static float baseCountTime = 15;
    [SerializeField] float speedCounter;
    #endregion
    float healAmount = 10;
    void Start()
    {
        dino = GetComponent<Dino>();
        pInput = GetComponent<PlayerInput>();
        speedBase = pInput._speed;
        speedUp = speedBase * 1.75f;
    }
    void FixedUpdate()
    {
        switch (speedUpBool)
        {
            case true:
                pInput._speed = speedUp;
                CountDown("SpeedUp");
                break;
            case false:
                pInput._speed = speedBase;
                break;
        }
    }
    void CountDown(string _PUType)
    {
        switch (_PUType)
        {
            case "SpeedUp":
                speedCounter -= Time.deltaTime;
                if (speedCounter <= 0) speedUpBool = false;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpeedUpPU")
        {
            speedCounter = baseCountTime;
            speedUpBool = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "HealthUpPU")
        {
            dino.Heal(healAmount);
            Destroy(other.gameObject);
        }
    }
}
