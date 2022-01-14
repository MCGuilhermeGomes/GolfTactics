using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
private static ScoreManager instance;
public int PlayerAScore;
public int PlayerBScore;

public static ScoreManager Instance
{
    get{return instance; }
}
void Awake(){
    if (instance != null && instance != this)
    {
        Destroy(this.gameObject);
    } else
    {
        instance = this;
    }

}

public void IncrementPlayerAScore(int Score)
    {
        PlayerAScore += Score;
        AddScoreUI.main.SetScoreP1(PlayerAScore);
    }

public void IncrementPlayerBScore(int Score)
    {
        PlayerBScore += Score;
        AddScoreUI.main.SetScoreP2(PlayerBScore);

    }

}
