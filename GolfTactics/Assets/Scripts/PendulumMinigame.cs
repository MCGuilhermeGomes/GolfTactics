using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PendulumMinigame : MonoBehaviour
{
    public static PendulumMinigame main;

    public GameObject pendulum;
    public Transform actualTarget;
    public Transform launchPoint;

    public float maxAngle = 55f;
    public float baseSwingSpeed = 1f;
    public float allyBonus = 0.5f;
    private float alliesInRange;
    public float enemyPenalty = 0.5f;
    private float enemiesInRange;

    public float maxInfluence;

    private int direction = 1;
    private float progress = 0;

    bool swinging = true;

    public Text allyBonusText;
    public Text enemyPenaltyText;

    private void Start()
    {
        if (main != null && main != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            main = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (swinging)
        {
            float p = progress;
            progress += direction * baseSwingSpeed * Mathf.Pow(allyBonus,alliesInRange) * Time.deltaTime;

            pendulum.transform.Rotate(0, 0, (progress - p) * maxAngle);

            if ((progress > 1 && direction == 1) || (progress < -1 && direction == -1))
            {
                direction *= -1;
            }

            actualTarget.RotateAround(launchPoint.position, Vector3.up, (p - progress) * maxAngle);
        }
    }

    public void StartPendulum()
    {
        swinging = true;

        alliesInRange = AllyChecker.Instance.AlliesInRadius(HeaderUITurnSwitch.main.currentPlayer);

        if (alliesInRange > 0)
        {
            //allyBonusText.text = "Ally Aim Bonus!\nx " + Mathf.Pow(allyBonus, alliesInRange) + "%";

            allyBonusText.text = "Ally Aim Bonus!\n+ " + allyBonus * alliesInRange * 100 + "%";

            allyBonusText.gameObject.SetActive(true);
        }

        if (enemiesInRange > 0)
        {
            enemyPenaltyText.text = "Enemy Aim Penalty!\n+ " + enemyPenalty * enemiesInRange * 100 + "%";

            enemyPenaltyText.gameObject.SetActive(true);
        }
    }

    public float StopPendulum()
    {
        swinging = false;

        UIManager.main.state = UIGameState.MinigameEnd;
        BallLauncher.main.Launch();
        Debug.Log(progress);
        return progress;
    }

    public void ResetPendulum()
    {
        Debug.Log("RESET PENDULUM");
        progress = 0;
        pendulum.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void ButtonPress()
    {
        if (swinging)
            StopPendulum();
        else
            StartPendulum();
    }

    public void setLaunchPoint(Transform transform)
    {
        launchPoint = transform;
    }
}
