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
    }
    private void LateUpdate()
    {
        cameraBase.transform.position = gameObject.transform.transform.position;
        if (Input.GetKeyDown(KeyCode.Q) && !hasEgg) egg.EggNotificationSound(transform.position);
        if (health <= 0) Death();
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
