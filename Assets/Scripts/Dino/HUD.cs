﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] public Text timerText;
    [SerializeField] public Text PlayerHealth;
    [SerializeField] public GameObject winScreen;
    [SerializeField] public GameObject failScreen;
    [SerializeField] public GameObject sacrificeScreen;
    [SerializeField] public GameObject menuHolder;
}
