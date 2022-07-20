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
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    //Going to the next scene. 
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
