using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] int index;

    [SerializeField] Canvas canvas;
    [SerializeField] bool TogglePauze;
    public bool cursorVisible;

    public void OnClick()
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }
    public void Resume()
    {
        canvas.enabled = false;
        TogglePauze = false;
        cursorVisible = false;
        Time.timeScale = 1f;
        Debug.Log("Resume");
    }
}
