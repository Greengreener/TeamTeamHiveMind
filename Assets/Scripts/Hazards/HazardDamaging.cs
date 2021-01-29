using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDamaging : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] Dino dino;
    private void Start()
    {
        dino = FindObjectOfType<Dino>();
    }
    // private void OnTriggerEnter(Collider Enter)
    // {
    //     if (Enter.gameObject.tag == "DinoPlayer")
    //     {
    //         dino.Damage(damage);
    //     }
    // }
    private void OnTriggerStay(Collider Stay)
    {
        if (Stay.gameObject.tag == "DinoPlayer")
        {
            dino.Damage(damage * 0.75f);
        }
    }
}
