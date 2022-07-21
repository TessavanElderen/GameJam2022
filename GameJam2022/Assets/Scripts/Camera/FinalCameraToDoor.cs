using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCameraToDoor : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject finalDoorCamera;
    [SerializeField] private GameObject followCamera;

    [SerializeField] private DisenableMovement disableMovementScript;
    [SerializeField] private Door doorScript;


    [Header("Timer Settings")]
    [SerializeField] private int timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckFinalCamPostion();
    }


    public void FinalDoorCam()
    {
        disableMovementScript.disableMovement = true;
        finalDoorCamera.SetActive(true);
        followCamera.SetActive(false);
    }
    private IEnumerator TimeDoor()
    {
        doorScript.canDissolve = true;
        yield return new WaitForSeconds(timer);
        disableMovementScript.disableMovement = false;
        followCamera.SetActive(true);
        finalDoorCamera.SetActive(false);
    }

    void CheckFinalCamPostion()
    {
        if (mainCamera.transform.position == finalDoorCamera.transform.position)
        {
            StartCoroutine(TimeDoor());
            Debug.Log("Timer werkt");
        }
    }
}
