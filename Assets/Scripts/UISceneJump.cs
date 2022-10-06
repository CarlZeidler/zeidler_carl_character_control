using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISceneJump : MonoBehaviour
{
    public TMP_Text playerNameDisplay;
    public TMP_Text scoreDisplay;
    public TMP_Text gameOverPlayerName;
    public TMP_Text gameOverScoreDisplay;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject UIElementsParent;
    public GameObject GameOverElements;

    void Start()
    {
        ShowPlayerName();
    }

    void Update()
    {
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        scoreDisplay.SetText("Score: " + GlobalValues.currentScore);
    }

    void ShowPlayerName()
    {
        if (!string.IsNullOrEmpty(GlobalValues.playerName))
        {
            playerNameDisplay.SetText("Player: " + GlobalValues.playerName);
        }
        else
        {
            playerNameDisplay.SetText("Unknown player (spooky!)");
        }
    }

    public void GameOverDisplay()
    {
        if (!string.IsNullOrEmpty(GlobalValues.playerName))
        {
            gameOverPlayerName.SetText(GlobalValues.playerName + "'s score:");
            gameOverScoreDisplay.SetText(GlobalValues.currentScore + "!");
        }
        else
        {
            gameOverPlayerName.SetText("A spooky skeleton was playing! No score!");
        }

        UIElementsParent.gameObject.SetActive(false);
        GameOverElements.gameObject.SetActive(true);

    }

}
