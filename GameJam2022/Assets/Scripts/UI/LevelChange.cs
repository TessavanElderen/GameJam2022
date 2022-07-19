using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChange : MonoBehaviour
{

    [SerializeField] private Animator animator;

    [SerializeField] private int levelToLoad; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FadeToLevel(1);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");

    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
