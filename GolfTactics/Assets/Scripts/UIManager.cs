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
    public GameObject allyBonusText;
    public GameObject enemyPenaltyText;

    public float minigameEndTime = 0.5f;
    private float timer = 0f;

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
                allyBonusText.SetActive(false);
                enemyPenaltyText.SetActive(false);
                break;
            case UIGameState.Minigame:
                launchButton.SetActive(false);
                pendulumMinigame.SetActive(true);
                break;
            case UIGameState.MinigameEnd:
                timer += Time.deltaTime;
                if (timer > minigameEndTime)
                {
                    state = UIGameState.Launching;
                    timer = 0;
                }
                launchButton.SetActive(false);
                pendulumMinigame.SetActive(true);
                break;
            case UIGameState.Launching:
                launchButton.SetActive(false);
                pendulumMinigame.SetActive(false);
                break;
        }

    }
}
