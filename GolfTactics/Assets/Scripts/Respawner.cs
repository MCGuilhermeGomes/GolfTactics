using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject[] teamA;
    Unit[] teamAUnits;
    Vector3[] initialAPos;

    public GameObject[] teamB;
    Unit[] teamBUnits;
    Vector3[] initialBPos;

    private void LateStart()
    {

        for (int i = 0; i < teamA.Length; i++)
        {
            initialAPos[i] = teamA[i].transform.position;
            teamAUnits[i] = teamA[i].GetComponent<Unit>();
        }

        for (int i = 0; i < teamB.Length; i++)
        {
            initialBPos[i] = teamB[i].transform.position;
            teamBUnits[i] = teamB[i].GetComponent<Unit>();
        }
    }

    public void CheckForDeaths()
    {

        for (int i = 0; i < teamAUnits.Length; i++)
        {
            if (teamAUnits[i].currentHP <= 0)
            {
                teamA[i].transform.position = initialAPos[i];
            }
        }

        for (int i = 0; i < teamBUnits.Length; i++)
        {
            if (teamBUnits[i].currentHP <= 0)
            {
                teamB[i].transform.position = initialBPos[i];
            }
        }

    }

}
