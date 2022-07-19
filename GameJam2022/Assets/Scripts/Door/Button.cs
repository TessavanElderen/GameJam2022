using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private CameraToDoor cameraScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraScript.Cam();
            Debug.Log("Knop Ingedrukt");
        }
    }
}
