using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] Egg egg;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject cameraBase;
    void Start()
    {
        egg = GetComponent<Egg>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        cameraBase.transform.position = gameObject.transform.transform.position;
    }
}
