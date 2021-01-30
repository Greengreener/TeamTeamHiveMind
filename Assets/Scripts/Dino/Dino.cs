using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [Header("ObjectsIDK")]
    [SerializeField] Egg egg;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject cameraBase;
    [Header("Attributes")]
    [SerializeField] float healthMax = 100;
    [SerializeField] float health = 100;
    [SerializeField] bool Dead = false;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cameraBase = GameObject.FindGameObjectWithTag("CameraBase");
        egg = GameObject.FindObjectOfType<Egg>();
    }
    private void Update()
    {
        cameraBase.transform.position = gameObject.transform.transform.position;
        if (Input.GetKeyDown(KeyCode.Q)) egg.EggNotificationSound(transform.position);
    }
    #region Health/Damage
    public void Damage(float _inputDamge)
    {
        health -= _inputDamge;
        if (health >= 0) Death();
    }
    public void Heal(float _inputHeal)
    {
        health += _inputHeal;
        if (health > healthMax) health = healthMax;
    }
    void Death()
    {
        Dead = true;
    }
    #endregion

}
