using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    [SerializeField] private float gravityChange;
    private bool gravityUp;
    [SerializeField] private bool canSwitchGravity;

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

    private void SwitchGravity()
    {
        // if you press the space the gravity turns positive so the player would go up
        if (Input.GetKeyDown(KeyCode.Space) && !gravityUp && canSwitchGravity)
        {
            canSwitchGravity = false;
            gravityUp = true;

            Physics.gravity = new Vector3(0f,gravityChange,0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
        }
        // if you press the space the gravity turns positive so the player would go down
        else if (Input.GetKeyDown(KeyCode.Space) && gravityUp && canSwitchGravity)
        {
            canSwitchGravity = false;
            gravityUp = false;

            Physics.gravity = new Vector3(0f, -gravityChange, 0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("T");
            canSwitchGravity = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("F");
            canSwitchGravity = false;
        }
    }
}
