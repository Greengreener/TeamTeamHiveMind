using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float _speed = 5;
    [SerializeField] CharacterController charCon;
    [SerializeField] float turnSmooth = 0.1f;
    float turnSmoothVel;
    [SerializeField] Transform cam;

    [SerializeField] GameObject interactTrigger;
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        cam = Camera.main.gameObject.transform;
    }

    void Update()
    {
        #region Movement
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(hor, 0, ver).normalized;
        if (dir.magnitude >= 0.1f)
        {
            float targAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targAngle, ref turnSmoothVel, turnSmooth);
            transform.rotation = Quaternion.Euler(0, targAngle, 0);
            Vector3 moveDir = Quaternion.Euler(0, targAngle, 0) * Vector3.forward;
            charCon.Move(moveDir.normalized * _speed * Time.deltaTime);
        }
        #endregion
        #region Interaction
        float interactInput = Input.GetAxisRaw("Interact");


        // Temp
        switch (interactInput)
        {
            case 0:
                interactTrigger.SetActive(false);
                break;
            case 1:
                interactTrigger.SetActive(true);
                break;
        }
        #endregion
    }
    void Interact()
    {

    }
}
