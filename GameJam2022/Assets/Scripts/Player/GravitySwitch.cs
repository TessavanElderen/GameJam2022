using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    [SerializeField] private float gravityChange;
    [SerializeField] private bool canSwitchGravity;
    [SerializeField] private float RaycastRange;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float animatieDemp;
    [SerializeField] Animator animator;

    public bool gravityUp;
    private Ray ray;
    private RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        canSwitchGravity = true;
        gravityUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchGravity();
    }

    private void FixedUpdate()
    {
        RayacstCheck();
    }

    private void SwitchGravity()
    {
        // if you press the space the gravity turns positive so the player would go up
        if (Input.GetKeyDown(KeyCode.Space) && !gravityUp && canSwitchGravity)
        {
            animator.SetBool("Jumping", true);
            animator.SetFloat("isJumping", 0, animatieDemp, Time.deltaTime);
            canSwitchGravity = false;
            gravityUp = true;

            Physics.gravity = new Vector3(0f,gravityChange,0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
        }
        // if you press the space the gravity turns positive so the player would go down
        else if (Input.GetKeyDown(KeyCode.Space) && gravityUp && canSwitchGravity)
        {
            animator.SetBool("Jumping", true);
            animator.SetFloat("isJumping", 0, animatieDemp, Time.deltaTime);
            canSwitchGravity = false;
            gravityUp = false;

            Physics.gravity = new Vector3(0f, -gravityChange, 0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void RayacstCheck()
    {
        //check if the player can change the gravity
        ray.origin = transform.position;
        ray.direction = -transform.up;

        if(Physics.Raycast(ray,out hitInfo, RaycastRange, groundLayer) && !canSwitchGravity)
        {
            animator.SetFloat("isJumping", .5f, animatieDemp, Time.deltaTime);
            animator.SetBool("Jumping", false);
            canSwitchGravity = true;
        }
    }
}
