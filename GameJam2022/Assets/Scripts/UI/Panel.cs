using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Image myPanel;

    [SerializeField] Color whiteColor, blackColor;
    Color currentColor;
    Image panelImage;

    private void Start()
    {
        panelImage = GetComponent<Image>();
        panelImage.material.color = whiteColor;
        currentColor = whiteColor; 
    }
    void Update()
    {
        if (player.gameObject.name == "Door")
        {
            panelImage.material.color = Color.Lerp(panelImage.material.color, currentColor, 0.1f);
        }
    }
}
