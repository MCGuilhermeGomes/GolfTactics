using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public float fallTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Unit unit = other.gameObject.GetComponent<Unit>();
        if (unit)
        {
            StartCoroutine(BombFallCoroutine(unit.gameObject));
        }
    }

    IEnumerator BombFallCoroutine(GameObject bomb)
    {
        bomb.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(fallTime);

        bomb.GetComponent<Collider>().enabled = true;

        Unit unit = bomb.GetComponent<Unit>();

        unit.TakeDamage(999);
        unit.TryToKill();

        if (bomb.GetComponent<Unit>().team == 1)
        {
            ScoreManager.Instance.IncrementPlayerAScore(5);
        }
        else
        {
            ScoreManager.Instance.IncrementPlayerBScore(5);
        }

        bomb.GetComponent<Bomb>().hasExploded = true;
       
    }
}
