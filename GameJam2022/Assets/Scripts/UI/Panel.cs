using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Image myPanel;

    [SerializeField] private Color myColor;

    private void Start()
    {
        myColor.a = 1;
        myColor.b = 0;
    }
    void Update()
    {
        ColorChanger();
    }

    void ColorChanger()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            myColor.b = 1;
            myColor.a = 0;
        }
    }
}
//Color.Lerp(Color.white,Color.black, Mathf.PingPong(Time.time, 1));