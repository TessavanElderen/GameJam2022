using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChange : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int levelToLoad;
    [SerializeField] private float fadeSeconds; 

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
        yield return new WaitForSeconds(fadeSeconds);
        SceneManager.LoadScene(levelToLoad);
    }
}
