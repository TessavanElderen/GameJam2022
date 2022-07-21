using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraToDoor : MonoBehaviour
{
    [Header("Pref")]
    [SerializeField] private GameObject doorCamera;
    [SerializeField] private GameObject followCamera;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Door doorScript;
    [SerializeField] private DisenableMovement disableMovementScript;

    [Header("Timer Settings")]
    [SerializeField] private int timer = 3;

    void Update()
    {
        CheckCamPosition();
    }

    public void Cam()
    {
        disableMovementScript.disableMovement = true;
        doorCamera.SetActive(true);
        followCamera.SetActive(false);
    }

    private IEnumerator TimeDoor()
    {
        doorScript.canDissolve = true;
        yield return new WaitForSeconds(timer);
        disableMovementScript.disableMovement = false;
        followCamera.SetActive(true);
        doorCamera.SetActive(false);
    }

    void CheckCamPosition()
    {
        if (mainCamera.transform.position == doorCamera.transform.position)
        {
            StartCoroutine(TimeDoor());
            Debug.Log("Timer werkt");
        }
    }


}