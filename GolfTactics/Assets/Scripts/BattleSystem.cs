using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START , TEAMATURN, TEAMBTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject[] playerATeam;
    public int currentAUnit;
    public Unit[] playerAUnit;
    public GameObject[] playerBTeam;
    public int currentBUnit;
    public Unit[] playerBUnit;
    public Transform playerCamA;
    public Transform playerCamB;
    public GameObject mainCamera;
    public BattleState state; 
    public BallLauncher ballLauncher;
    // Start is called before the first frame update
    void Start()
    {
        currentAUnit = -1;
        currentBUnit = -1;
        state = BattleState.START;
        SetupBattle(); 
    }

    void SetupBattle()
    {
        mainCamera.transform.position = playerCamA.position;
        mainCamera.transform.rotation = playerCamA.rotation;
        for (int i = 0; i < playerATeam.Length; i++)
        {
            playerAUnit[i] = playerATeam[i].GetComponent<Unit>();         
        }
        for (int i = 0; i < playerBTeam.Length; i++)
        {
            playerBUnit[i] = playerBTeam[i].GetComponent<Unit>();         
        }
        state = BattleState.TEAMATURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        PickTeamBall();
        ballLauncher.ball = playerATeam[currentAUnit].GetComponent<Rigidbody>();
    }
    void PickTeamBall()
    {
        if (state == BattleState.TEAMATURN)
        {
            currentAUnit++;
        }
    }
}
