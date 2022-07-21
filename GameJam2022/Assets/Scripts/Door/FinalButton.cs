using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalButton : MonoBehaviour
{
    [SerializeField] private FinalCameraToDoor finalCameraScript;
    private bool canBePressed;
    // Start is called before the first frame update
    void Start()
    {
        canBePressed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canBePressed)
        {
            canBePressed = false;
            finalCameraScript.FinalDoorCam();
            Debug.Log("Final knop is ingedrukt");
        }
    }
}
