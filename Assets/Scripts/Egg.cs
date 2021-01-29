using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] Dino dino;
    void Start()
    {
        dino = GetComponent<Dino>();
    }
}
