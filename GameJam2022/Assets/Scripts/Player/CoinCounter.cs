using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    [Header("Coin Count")]
    [SerializeField] public int coinCount;
    [SerializeField] public int specialCoinCount;

    [Header("Coin Text")]
    [SerializeField] TMP_Text textCoin; 
    [SerializeField] TMP_Text textSpecialCoin;

    [Header("Black Canvas Coin Text")]
    [SerializeField] TMP_Text blackCanvasCoin; 
    [SerializeField] TMP_Text blackCanvasSpecialCoin;

    private int emptyCoinCount = 0;
    private int emptySpecialCoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        emptyCoinCount = 0;
        emptySpecialCoinCount = 0;

        coinCount = 0;
        specialCoinCount = 0;
    }

    private void Update()
    {
        Counter();
        blackCanvas();
    }

    // Counter mag niet gezien worden tijdens het zwarte scherm
    void Counter()
    {
        textCoin.text = $"{coinCount}";
        textSpecialCoin.text = $"{specialCoinCount}";
    }

    // tijdens het zwarte scherm hoeft er niks te staan.
    void blackCanvas()
    {   
        blackCanvasCoin.text = $"{emptyCoinCount}/5";
        blackCanvasSpecialCoin.text = $"{emptySpecialCoinCount}/1";
    }
    
}
