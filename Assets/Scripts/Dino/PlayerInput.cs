﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float speed;
    //[SerializeField] Rigidbody rb;
    [SerializeField] CharacterController charCon;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        charCon = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(hor, 0, ver).normalized;
        if (dir.magnitude >= 0.1f)
        {
            float targAngle = Mathf.Atan2(dir.x, dir.y);
            charCon.Move(dir * speed * Time.deltaTime);
        }
    }
}