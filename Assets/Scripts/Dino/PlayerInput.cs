using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float speed;
    //[SerializeField] Rigidbody rb;
    [SerializeField] CharacterController charCon;
    [SerializeField] float turnSmooth = 0.1f;
    float turnSmoothVel;
    [SerializeField] Transform cam;
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
            float targAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targAngle, ref turnSmoothVel, turnSmooth);
            transform.rotation = Quaternion.Euler(0, targAngle, 0);
            Vector3 moveDir = Quaternion.Euler(0, targAngle, 0) * Vector3.forward;
            charCon.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
