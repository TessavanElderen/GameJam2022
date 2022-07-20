using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] public int coinCount;
    [SerializeField] public int specialCoinCount;

    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        specialCoinCount = 0;
    }
}
