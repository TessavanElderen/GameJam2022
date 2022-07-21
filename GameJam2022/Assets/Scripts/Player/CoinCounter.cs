using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    [SerializeField] public int coinCount;
    [SerializeField] public int specialCoinCount;

    [SerializeField] TMP_Text textCoin; 
    [SerializeField] TMP_Text textSpecialCoin; 

    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        specialCoinCount = 0;
    }

    private void Update()
    {
        textCoin.text = $"{coinCount}";
        textSpecialCoin.text = $"{specialCoinCount}";
    }
}
