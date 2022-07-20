using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialSignTrigger : MonoBehaviour
{
    [SerializeField] private bool gravitySwitchTutorial;
    [SerializeField] private bool buttonTutorial;
    [SerializeField] private bool walkTutorial;
    [SerializeField] private Canvas tutorialCanvas;
    [SerializeField] private TMP_Text tutorialText;

    private void Start()
    {
        tutorialCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GravitySwitchTutorial();
            ButtonTutorial();
            WalkTutorial();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tutorialCanvas.enabled = false;
    }

    private void GravitySwitchTutorial()
    {
        if(gravitySwitchTutorial)
        {
            tutorialText.text = "Press SPACE to change the gravity";
            tutorialCanvas.enabled = true;
        }
    }

    private void ButtonTutorial()
    {
        if(buttonTutorial)
        {
            tutorialText.text = "Land on the button to open the door";
            tutorialCanvas.enabled = true;
        }
    }

    private void WalkTutorial()
    {
        if (walkTutorial)
        {
            tutorialText.text = "Walk with A and D";
            tutorialCanvas.enabled = true;
        }
    }
}
