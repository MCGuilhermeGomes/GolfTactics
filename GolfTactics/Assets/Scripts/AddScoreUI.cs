using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScoreUI : MonoBehaviour
{
    public static AddScoreUI main;

    public Text P1ScoreCounter;
    public Text P2ScoreCounter;

    private void Start()
    {
        main = this;
    }

    public void SetScoreP1(int score)
    {
        P1ScoreCounter.text = score.ToString();
    }

    public void SetScoreP2(int score)
    {
        P2ScoreCounter.text = score.ToString();
    }
}
