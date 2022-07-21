using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private CameraToDoor cameraScript;
    private bool canBePressed;

    private void Start()
    {
        canBePressed = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canBePressed)
        {
            canBePressed = false;
            cameraScript.Cam();
            Debug.Log("Knop Ingedrukt");
        }
    }
}
