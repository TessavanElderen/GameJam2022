using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChange : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int levelToLoad; 

    //This is a trigger to go to the next scene
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FadeToLevel();
        }
    }

    // The fade to next scene 
    void FadeToLevel()
    {
       
        animator.SetBool("FadeOut", true);
        animator.SetBool("FadeIn", false);

        
    }

    //Going to the next scene. 
    void OnFadeComplete()
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        SceneManager.LoadScene(levelToLoad);
    }
}
