using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] Global g;
    [Header("ObjectsIDK")]
    [SerializeField] Egg egg;
    [SerializeField] public bool hasEgg;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject cameraBase;
    [SerializeField] HUD playerHUD;
    [Header("Attributes")]
    [SerializeField] float healthMax = 100;
    [SerializeField] float health = 100;
    [SerializeField] bool Dead = false;
    void Start()
    {
        g = FindObjectOfType<Global>();
        playerInput = GetComponent<PlayerInput>();
        cameraBase = GameObject.FindGameObjectWithTag("CameraBase");
        egg = FindObjectOfType<Egg>();
        playerHUD = FindObjectOfType<HUD>();
    }
    private void LateUpdate()
    {
        cameraBase.transform.position = gameObject.transform.transform.position;
        if (Input.GetKeyDown(KeyCode.Q) && !hasEgg) egg.EggNotificationSound(transform.position);

        if (health > 0) playerHUD.PlayerHealth.text = health.ToString("f0");
        if (health <= 0)
        {
            playerHUD.PlayerHealth.text = "0";
            Death();
        }
    }
    #region Health/Damage
    public void Damage(float _inputDamge)
    {
        health -= _inputDamge;
    }
    public void Heal(float _inputHeal)
    {
        health += _inputHeal;
        if (health > healthMax) health = healthMax;
    }
    void Death()
    {
        g.EndOfTime();
        Dead = true;
    }
    #endregion
}
