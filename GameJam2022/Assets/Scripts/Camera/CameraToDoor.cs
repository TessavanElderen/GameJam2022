using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraToDoor : MonoBehaviour
{
    [Header("Pref")]
    [SerializeField] private GameObject doorCamera;
    [SerializeField] private GameObject followCamera;
    [SerializeField] private GameObject mainCamera;

    [Header("Timer Settings")]
    [SerializeField] private int timer = 3; 

    void Update()
    {
        Cam();
        CheckCamPosition();
    }

    void Cam()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorCamera.SetActive(true);
            followCamera.SetActive(false);
        }
    }

    private IEnumerator TimeDoor()
    {
        yield return new WaitForSeconds(timer);
        followCamera.SetActive(true);
        doorCamera.SetActive(false);
    } 

    void CheckCamPosition()
    {
        if(mainCamera.transform.position == doorCamera.transform.position)
        {
            StartCoroutine(TimeDoor());
            Debug.Log("Timer werkt");
        }
    }
}