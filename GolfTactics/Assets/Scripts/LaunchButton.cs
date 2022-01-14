using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchButton : MonoBehaviour
{
    public void StartMinigame()
    {
        UIManager.main.state = UIGameState.Minigame;
    }
}
