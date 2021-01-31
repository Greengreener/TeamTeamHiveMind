using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] bool isRunning = false;
    [SerializeField] public bool isMovable = true;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (isMovable)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            if (horizontal > 0.1f || horizontal < -0.1f || vertical > 0.1f || vertical < -0.1f)
            {
                animator.SetFloat("Speed", 1);
            }
            else animator.SetFloat("Speed", 0);
        }
        else animator.SetFloat("Speed", 0);
    }
    public void IsRunning(bool _input)
    {
        isRunning = _input;
        animator.SetBool("isRunning", _input);
    }
}
