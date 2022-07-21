using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float dissolveSpeed;
    private Material dissolveMat;
    public bool canDissolve;
    private float maxLifeTime;

    private void Start()
    {
        dissolveMat = GetComponent<Renderer>().material;
        maxLifeTime = 1;
        canDissolve = false;
    }

    private void Update()
    {
        DissolveDoor();
        DestroyObject();
    }

    private void DissolveDoor()
    {
        if (canDissolve)
        {
            maxLifeTime -= dissolveSpeed * Time.deltaTime;
            dissolveMat.SetFloat("LifeTime", maxLifeTime);
        }
    }

    private void DestroyObject()
    {
        if (maxLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
