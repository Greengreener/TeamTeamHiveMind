using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    [SerializeField] Global g;
    void Start() { g = FindObjectOfType<Global>(); }
    private void OnTriggerEnter(Collider other)
    {
        Dino dino;
        if (other.gameObject.tag == "DinoPlayer")
        {
            dino = other.gameObject.GetComponent<Dino>();
            if (dino.hasEgg == true) g.ReturnedEgg();
        }
    }
}
