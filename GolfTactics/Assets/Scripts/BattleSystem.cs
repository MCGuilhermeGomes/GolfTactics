using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START , TEAMATURN, TEAMBTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject[] teamA;
    public int currentAUnit;
    public Unit[] teamAUnit;
    public GameObject[] teamB;
    public int currentBUnit;
    public Unit[] teamBUnit;
    public Transform playerCamA;
    public Transform playerCamB;
    public BattleState state; 
    public BallLauncher ballLauncher;

    public Camera mainCamera;
    //public Respawner respawner;

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
        for (int i = 0; i < teamA.Length; i++)
        {
            teamAUnit[i] = teamA[i].GetComponent<Unit>();
        }
        for (int i = 0; i < teamB.Length; i++)
        {
            teamBUnit[i] = teamB[i].GetComponent<Unit>();
        }

        state = BattleState.TEAMATURN;

        PickTeamBall();
        ballLauncher.updateBall();
        SwitchCamera();
    }

    bool PickTeamBall()
    {
        if (state == BattleState.TEAMATURN)
        {
            currentAUnit++;
            if (currentAUnit >= teamA.Length)
            {
                currentAUnit = 0;
            }

            if (!teamA[currentAUnit].activeInHierarchy)
            {
                teamAUnit[currentAUnit].Respawn();
            }

            ballLauncher.ball = teamA[currentAUnit];
            return true;
        }

        else if (state == BattleState.TEAMBTURN)
        {
            currentBUnit++;
            if (currentBUnit >= teamB.Length)
            {
                currentBUnit = 0;
            }

            if (!teamB[currentBUnit].activeInHierarchy)
            {
                teamBUnit[currentBUnit].Respawn();
            }
            ballLauncher.ball = teamB[currentBUnit];

            return true;
        }
        return false;
    }

    void SwitchCamera()
    {
        if (state == BattleState.TEAMATURN)
        {
            mainCamera.transform.position = playerCamA.position;
            mainCamera.transform.rotation = playerCamA.rotation;
        }
        else if (state == BattleState.TEAMBTURN)
        {
            mainCamera.transform.position = playerCamB.position;
            mainCamera.transform.rotation = playerCamB.rotation;
        }
    }

    public void SwitchTurn(bool switchTeam)
    {
        switchTeam = true;
        foreach (Camera camera in Camera.allCameras)
        {
            camera.enabled = false;
        }

        mainCamera.enabled = true;
        
        if (switchTeam)
        {
            if (state == BattleState.TEAMATURN)
            {
                state = BattleState.TEAMBTURN;
            } else if (state == BattleState.TEAMBTURN)
            {
                state = BattleState.TEAMATURN;
            }  
            
            HeaderUITurnSwitch.main.SwitchPlayer();
            LauncherButtonColorSwap.main.SwitchPlayer();
            SwitchCamera();
        }

        if (PickTeamBall())
        {
            ballLauncher.updateBall();
        }

        UIManager.main.state = UIGameState.Aiming;
        ballLauncher.target.GetComponent<DragWithTouch>().enabled = true;

    }
} 
