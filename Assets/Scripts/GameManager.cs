using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winningScreen; // Referenz auf das Winning Screen GameObject
    public TextMeshProUGUI scoreText; // UI-Textobjekt zur Anzeige der Punkte
    private int score = 0; // Punktestand
    public int winScore = 100; // Punktestand der erreicht werden muss um den WinningScreen zu triggern. muss angepasst werden je nach Anzahl der Äpfel



    void Start()
    {
        UpdateScoreText(); 
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    //Score erhöht sich
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();

        //Überprüfen des Winning Scores
        if (score >= winScore)
        {
            ActivateWinningScreen();
        }
    }

    
    void ActivateWinningScreen()
    {
        if (winningScreen != null)
        {
            winningScreen.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
