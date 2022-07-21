using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float animatorDampTime;
    [SerializeField] private Animator animator;
    [SerializeField] private GravitySwitch gravitySwitchScript;
    private Vector3 movX;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Animation();
        PlayerRotation();
    }

    private void FixedUpdate()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        // Move the rb with the horizontal input
        movX = new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f);

        rb.MovePosition(transform.localPosition += movX * speed * Time.deltaTime);
    }

    private void PlayerRotation()
    {
        if (movX.x < 0f && !gravitySwitchScript.gravityUp)
        {
            transform.localRotation = Quaternion.Euler(0f,-180f,0f);
        }
        else if (movX.x > 0f && !gravitySwitchScript.gravityUp)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (movX.x < 0f && gravitySwitchScript.gravityUp)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (movX.x > 0f && gravitySwitchScript.gravityUp)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void Animation()
    {
        if (movX.x > 0 || movX.x < 0)
        {
            animator.SetFloat("Move", 1, animatorDampTime, Time.deltaTime);
        }
        else if (movX.x == 0)
        {
            animator.SetFloat("Move", 0, animatorDampTime, Time.deltaTime);
        }
    }
}
