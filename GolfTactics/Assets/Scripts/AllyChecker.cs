using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyChecker : MonoBehaviour
{
    public float radius;

    private static AllyChecker instance;
    public static AllyChecker Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public int AlliesInRadius(int team)
    {
        int result = 0;

        GameObject[] allBombs = GameObject.FindGameObjectsWithTag("Bomb");

        foreach(GameObject b in allBombs)
        {
            if(team == 1 && (b.name == "A0" || b.name == "A1" || b.name == "A2")
                && Vector3.Distance(b.transform.position,transform.position) < radius)
            {
                result++;
            }

            if (team == 2 && (b.name == "B0" || b.name == "B1" || b.name == "B2")
                && Vector3.Distance(b.transform.position, transform.position) < radius)
            {
                result++;
            }

        }

        Debug.Log(result + " allies in range");
        return result;
    }
}
