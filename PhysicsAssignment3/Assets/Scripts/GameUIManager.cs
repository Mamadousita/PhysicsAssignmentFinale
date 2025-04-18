using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI chronoText;
    public TextMeshProUGUI keysText;

    [Header("Timer Settings")]
    public float totalTime = 120f; // 2 minutes

    [Header("Player Reference")]
    public PlayerCheckpoint player;

    private float currentTime;
    private bool chronoStarted = false;
    private bool gameEnded = false;

    void Start()
    {
        currentTime = totalTime;
        UpdateUI(); 
    }

    void Update()
    {
        if (!chronoStarted || gameEnded) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);

        UpdateUI();

       
        if (currentTime <= 0f)
        {
            EndGame("Time's up!");
        }
        else if (player.keysCollected >= 5)
        {
            EndGame("You win!");
        }
    }

    public void StartChrono()
    {
        chronoStarted = true;
    }

    void EndGame(string message)
    {
        gameEnded = true;
        chronoText.text = message;
        Debug.Log(message);
    }

    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        chronoText.text = $"Time: {minutes:00}:{seconds:00}";

        keysText.text = $"Keys: {player.keysCollected} / 5";
    }
}
