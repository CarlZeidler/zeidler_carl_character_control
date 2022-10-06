using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text startMessage;
    public string playerName;
    
    public void GetPlayerName()
    {
        playerName = nameInput.text;
    }
    
    public void StartMessage()
    {
        startMessage.SetText("Welcome " + playerName + ",\nplease enjoy the game.");
        GlobalValues.playerName = playerName;
    }

}
