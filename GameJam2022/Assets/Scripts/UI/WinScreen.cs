using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class WinScreen : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    public bool cursorVisible;
    public bool toggleWin; 

    [SerializeField] private Canvas pauzeScreen;
    [SerializeField] private Movement movementScript;
    [SerializeField] private PauzeScreen pauzeScript;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        winCanvas.enabled = false;
        toggleWin = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            pauzeScript.playerWon = true;
            pauzeScript.cursorVisible = true;
            winCanvas.enabled = true;
            pauzeScreen.enabled = false;
            toggleWin = true;

            movementScript.enabled = false;
        }
    }
}
