using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START , TEAMATURN, TEAMBTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject[] playerATeam;
    public Unit[] playerAUnit;
    public GameObject[] playerBTeam;
    public Unit[] playerBUnit;
    public Transform playerCamA;
    public Transform playerCamB;
    public GameObject mainCamera;
    public BattleState state; 

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
