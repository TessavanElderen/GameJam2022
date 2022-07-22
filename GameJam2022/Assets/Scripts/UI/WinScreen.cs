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

    private void Start()
    {
        winCanvas.enabled = false;
        toggleWin = false;
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            pauzeScript.playerWon = true;
            pauzeScript.cursorVisible = true;
            winCanvas.enabled = true;
            pauzeScreen.enabled = false;
            toggleWin = true;

            movementScript.enabled = false;
        }
    }
}
