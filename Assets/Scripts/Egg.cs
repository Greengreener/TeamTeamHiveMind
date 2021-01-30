﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] Dino dino;
    [SerializeField] Global g;
    [SerializeField] AudioSource eggSounder;
    void Start()
    {
        dino = GetComponent<Dino>();
        g = FindObjectOfType<Global>();
        eggSounder = GetComponent<AudioSource>();
    }
    void Captured()
    {
        print("Captured");
        g.EggCaptured();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DinoPlayer") Captured();
    }
    public void EggNotificationSound(Vector3 _playerLocation)
    {
        float distance = Vector3.Distance(_playerLocation, transform.position);
        print("Distance 1 = " + distance);
        distance *= 0.01f;
        print("Distance 2 = " + distance);
        if (distance < 1)
        {
            eggSounder.volume = 1 - distance;
            print(eggSounder.volume);
            eggSounder.Play();
        }
        else return;
    }
}
