using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 movX;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        // Move the rb with the horizontal input
        movX = new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f);

        rb.MovePosition(transform.localPosition += movX * speed * Time.deltaTime);
    }
}
