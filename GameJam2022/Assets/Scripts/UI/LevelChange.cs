using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class LevelChange : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int levelToLoad;
    [SerializeField] private float fadeSeconds;

    [Header("BlackCanvas Text")]
    [SerializeField] TMP_Text blackCanvasTextCoin;
    [SerializeField] TMP_Text blackCanvasTextSpecialCoin;
    [SerializeField] Image blackCoinImg;
    [SerializeField] Image blackSpecialCoinImg;

    [Header("Canvas Text")]
    [SerializeField] TMP_Text canvasTextCoin; 
    [SerializeField] TMP_Text canvasTextSpecialCoin;
    [SerializeField] Image coinImg;
    [SerializeField] Image specialCoinImg;

    private void Start()
    {
        //black canvas coins
        blackCanvasTextCoin.enabled = false;
        blackCanvasTextSpecialCoin.enabled = false;
        blackCoinImg.enabled = false;
        blackSpecialCoinImg.enabled = false;

        //normale canvas of the canvas in levels
        canvasTextCoin.enabled = true;
        canvasTextSpecialCoin.enabled = true;
        coinImg.enabled = true;
        specialCoinImg.enabled = true;
    }

    //This is a trigger to go to the next scene
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(FadeToLevel()) ;           
        }
    }

    // The fade to next scene 
    IEnumerator FadeToLevel()
    {
        animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(3);
        //black canvas coins
        blackCanvasTextCoin.enabled = true;
        blackCanvasTextSpecialCoin.enabled = true;
        blackCoinImg.enabled = true;
        blackSpecialCoinImg.enabled = true;

        //normale canvas of the canvas in levels
        canvasTextCoin.enabled = false;
        canvasTextSpecialCoin.enabled = false;
        coinImg.enabled = false;
        specialCoinImg.enabled = false;

        yield return new WaitForSeconds(fadeSeconds);
        SceneManager.LoadScene(levelToLoad);
    }
}
