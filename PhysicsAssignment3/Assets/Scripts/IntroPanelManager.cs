using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPanelManager : MonoBehaviour
{
    public GameObject introPanel;
    public GameUIManager gameUIManager;

    private bool gameStarted = false;

    void Start()
    {
        Time.timeScale = 0f; 
        introPanel.SetActive(true); 
    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            introPanel.SetActive(false);       
            Time.timeScale = 1f;               
            gameUIManager.StartChrono();       
            gameStarted = true;
        }
    }
}
