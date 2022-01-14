using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIGameState { Aiming, Minigame, MinigameEnd, Launching};

public class UIManager : MonoBehaviour
{
    public static UIManager main;

    public UIGameState state;

    public GameObject launchButton;
    public GameObject pendulumMinigame;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case UIGameState.Aiming:
                launchButton.SetActive(true);
                pendulumMinigame.SetActive(false);
                break;
            case UIGameState.Minigame:
                launchButton.SetActive(false);
                pendulumMinigame.SetActive(true);
                break;
        }

    }
}
