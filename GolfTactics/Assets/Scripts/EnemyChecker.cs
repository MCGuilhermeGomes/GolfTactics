using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public float radius;

    public int EnemiesInRadius(int team)
    {
        int result = 0;

        GameObject[] allBombs = GameObject.FindGameObjectsWithTag("Bomb");

        foreach (GameObject b in allBombs)
        {
            if (team == 2 && (b.name == "A0" || b.name == "A1" || b.name == "A2")
                && Vector3.Distance(b.transform.position, transform.position) < radius)
            {
                result++;
            }

            if (team == 1 && (b.name == "B0" || b.name == "B1" || b.name == "B2")
                && Vector3.Distance(b.transform.position, transform.position) < radius)
            {
                result++;
            }

        }

        Debug.Log(result + " enemies closeby");
        return result;
    }
}
