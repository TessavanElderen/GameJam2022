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

    [SerializeField] TMP_Text blackCanvasTextCoin;
    [SerializeField] TMP_Text blackCanvasTextSpecialCoin;

    [SerializeField] Image coinImg;
    [SerializeField] Image specialCoinImg;
    
    private void Start()
    {
        blackCanvasTextCoin.enabled = false;
        blackCanvasTextSpecialCoin.enabled = false;
        coinImg.enabled = false;
        specialCoinImg.enabled = false; 
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
        blackCanvasTextCoin.enabled = true;
        blackCanvasTextSpecialCoin.enabled = true;
        coinImg.enabled = true;
        specialCoinImg.enabled = true;

        yield return new WaitForSeconds(fadeSeconds);
        SceneManager.LoadScene(levelToLoad);
    }
}
