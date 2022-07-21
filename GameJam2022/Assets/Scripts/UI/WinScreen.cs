using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class WinScreen : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    public bool cursorVisible;
    public bool toggle; 
    [SerializeField] GameObject player;

    [SerializeField] PauzeScreen pauzeScreen;

    private void Start()
    {
        winCanvas.enabled = false;
        toggle = false;
        Cursor.lockState = CursorLockMode.Locked;
        cursorVisible = false;
    }
    private void Update()
    {
        CursorV();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            winCanvas.enabled = true;
            pauzeScreen.enabled = false;
            toggle = true;
            cursorVisible = true;
        }
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
