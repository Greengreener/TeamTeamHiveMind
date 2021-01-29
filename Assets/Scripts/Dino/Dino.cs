using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] Egg egg;
    [SerializeField] PlayerInput playerInput;
    void Start()
    {
        egg = GetComponent<Egg>();
        playerInput = GetComponent<PlayerInput>();
    }
}
