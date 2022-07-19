using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float dissolveSpeed;
    private Material dissolveMat;
    public bool buttonPressed;
    private float maxLifeTime;

    private void Start()
    {
        dissolveMat = GetComponent<Renderer>().material;
        maxLifeTime = 1;
        buttonPressed = false;
    }

    private void Update()
    {
        DissolveDoor();
    }

    private void DissolveDoor()
    {
        if (buttonPressed)
        {
            //need to activate the camera Coroutine
            // in the Coroutine it activate the shader 
            maxLifeTime -= dissolveSpeed * Time.deltaTime;
            dissolveMat.SetFloat("LifeTime", maxLifeTime);
        }
    }
}
