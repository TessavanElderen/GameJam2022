using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] int index;

    public void OnClick()
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }
}
