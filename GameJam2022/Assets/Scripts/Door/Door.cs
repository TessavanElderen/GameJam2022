using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float dissolveSpeed;
    private Material dissolveMat;
    public bool canDissolve;
    private float maxLifeTime;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dissolveMat = GetComponent<Renderer>().material;
        maxLifeTime = 1;
        canDissolve = false;
        audioSource.volume = 0f;
        audioSource.Play();
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
            audioSource.volume = 0.5f;
            maxLifeTime -= dissolveSpeed * Time.deltaTime;
            dissolveMat.SetFloat("LifeTime", maxLifeTime);
        }
    }

    private void DestroyObject()
    {
        if (maxLifeTime <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }
}
