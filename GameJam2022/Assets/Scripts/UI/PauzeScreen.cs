using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeScreen : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] bool TogglePauze;
    public bool cursorVisible;
    public bool playerWon;

    private void Start()
    {
        Time.timeScale = 1;
        playerWon = false;
        canvas.enabled = false;
        cursorVisible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !playerWon)
        {
            canvas.enabled = !canvas.enabled;
            cursorVisible = true;
            Pause();
        }

        CursorV();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        canvas.enabled = true;
    }

    void CursorV()
    {
        if (cursorVisible == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}