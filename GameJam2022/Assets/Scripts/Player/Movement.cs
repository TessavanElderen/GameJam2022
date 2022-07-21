using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float animatorDampTime;
    [SerializeField] private Animator animator;
    [SerializeField] private GravitySwitch gravitySwitchScript;
    [SerializeField] private AudioClip grassSound;
    [SerializeField] private AudioClip stoneSound;
    [SerializeField] private AudioClip woodSound;
    [SerializeField] private LayerMask grassLayer;
    [SerializeField] private LayerMask stoneLayer;
    [SerializeField] private LayerMask woodLayer;
    [SerializeField] private Transform rayCastTransform;

    private bool canPlay;
    private AudioSource audioSource;
    private Vector3 movX;
    private Rigidbody rb;

    private Ray ray;
    private RaycastHit hitInfo;

    private void Start()
    {
        canPlay = true;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Animation();
        PlayerRotation();
        PlaySound();
        CheckWhatForGround();
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

    private void PlaySound()
    {
        if ((movX.x < 0 || movX.x > 0) && canPlay)
        {
            audioSource.Play();
            canPlay = false;
        }
        else if (movX.x == 0)
        {
            audioSource.Stop();
            canPlay = true;
        }
    }

    private void CheckWhatForGround()
    {
        AudioClip currentAuidoClip;
        ray.origin = rayCastTransform.position;
        ray.direction = -rayCastTransform.up;

        if (Physics.Raycast(ray, out hitInfo, 1f, grassLayer))
        {
            currentAuidoClip = audioSource.clip;

            Debug.DrawLine(ray.origin, hitInfo.point, Color.green, 1f);
            audioSource.volume = 0.5f;
            audioSource.clip = grassSound;

            if (currentAuidoClip != audioSource.clip)
            {
                audioSource.Play();
                currentAuidoClip = audioSource.clip;
            }
        }
        else if (Physics.Raycast(ray, out hitInfo, 1f, stoneLayer))
        {
            currentAuidoClip = audioSource.clip;

            Debug.DrawLine(ray.origin, hitInfo.point, Color.grey, 1f);
            audioSource.volume = 0.6f;
            audioSource.clip = stoneSound;

            if (currentAuidoClip != audioSource.clip)
            {
                audioSource.Play();
                currentAuidoClip = audioSource.clip;
            }
        }
        else if (Physics.Raycast(ray, out hitInfo, 1f, woodLayer))
        {
            currentAuidoClip = audioSource.clip;

            Debug.DrawLine(ray.origin, hitInfo.point, Color.blue, 1f);
            audioSource.volume = 0.2f;
            audioSource.clip = woodSound;

            if (currentAuidoClip != audioSource.clip)
            {
                audioSource.Play();
                currentAuidoClip = audioSource.clip;
            }
        }
        else
        {
            audioSource.volume = 0f;
        }
    }
}
