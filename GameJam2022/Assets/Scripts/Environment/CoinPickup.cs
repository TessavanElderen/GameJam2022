using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private float heightDifference;
    [SerializeField] private float frequency;
    [SerializeField] private float rotateSpeed;
    [SerializeField] CoinCounter coinCounterScript;
 
    private Vector3 posOffset;
    private Vector3 tempPos;

    private void Start()
    {
        posOffset = transform.position;
    }

    private void Update()
    {
        RotateCoin();
        BumpCoin();
    }

    private void BumpCoin()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * heightDifference;

        transform.position = tempPos;
    }

    private void RotateCoin()
    {
        transform.Rotate(0, 360 * rotateSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Add a coin to you UI
            coinCounterScript.coinCount++;
            Destroy(gameObject);
        }
    }
}
