using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI chronoText;
    public TextMeshProUGUI keysText;

    public float totalTime = 120f; // 2 minutes
    private float currentTime;

    public PlayerCheckpoint player;

    private bool gameEnded = false;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (gameEnded) return;

        // Chrono
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        chronoText.text = $"Time: {minutes:00}:{seconds:00}";

        // Key UI
        keysText.text = $"Keys: {player.keysCollected} / 5";

       
        if (currentTime <= 0f)
        {
            EndGame("Time's up!");
        }
        else if (player.keysCollected >= 5)
        {
            EndGame("You win!");
        }
    }

    void EndGame(string message)
    {
        gameEnded = true;
        chronoText.text = message;
        Debug.Log(message);
        // Tu peux aussi activer un menu de victoire/défaite ici
    }
}
