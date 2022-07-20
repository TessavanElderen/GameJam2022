using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void FadeToLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        animator.SetTrigger("FadeOut");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }
}
