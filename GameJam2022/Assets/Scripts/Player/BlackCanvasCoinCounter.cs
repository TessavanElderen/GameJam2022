using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlackCanvasCoinCounter : MonoBehaviour
{


    [Header("Black Canvas Coin Text")]
    [SerializeField] TMP_Text blackCanvasCoin;
    [SerializeField] TMP_Text blackCanvasSpecialCoin;
    [SerializeField] CoinCounter coinCounterScript;


    private int emptyCoinCount = 0;
    private int emptySpecialCoinCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        blackCanvas();
    }

    // tijdens het zwarte scherm hoeft er niks te staan.
    void blackCanvas()
    {
        blackCanvasCoin.text = $"{coinCounterScript.coinCount}/5";
        blackCanvasSpecialCoin.text = $"{coinCounterScript.specialCoinCount}/1";
    }
}
