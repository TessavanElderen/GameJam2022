using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisenableMovement : MonoBehaviour
{
    private Movement movementScript;
    private GravitySwitch gravitySwitchScript;
    public bool disableMovement;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<Movement>();
        gravitySwitchScript = GetComponent<GravitySwitch>();
        disableMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisableMovement();
    }

    private void DisableMovement()
    {
        if (disableMovement)
        {
            movementScript.enabled = false;
            gravitySwitchScript.enabled = false;
        }
        else if (!disableMovement)
        {
            gravitySwitchScript.enabled = true;
            movementScript.enabled = true;
        }
    }
}
