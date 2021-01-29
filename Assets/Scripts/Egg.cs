using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] Dino dino;
    [SerializeField] AudioSource eggSounder;
    [SerializeField] AudioClip eggSound;
    void Start()
    {
        dino = GetComponent<Dino>();
        eggSounder = GetComponent<AudioSource>();
    }
    void Captured()
    {
        print("Captured");
    }
    private void OnTriggerEnter(Collider other)
    {
        Captured();
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
        else
        {
            return;
        }
    }
}
