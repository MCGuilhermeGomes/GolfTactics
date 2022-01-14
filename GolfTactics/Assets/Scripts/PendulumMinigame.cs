using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMinigame : MonoBehaviour
{
    public static PendulumMinigame main;

    public GameObject pendulum;

    public float maxAngle = 55f;
    public float baseSwingSpeed = 1f;

    public float maxInfluence;

    private int direction = 1;
    private float progress = 0;

    bool swinging = true;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
        ResetPendulum();
    }

    // Update is called once per frame
    void Update()
    {
        if (swinging)
        {
            float p = progress;
            progress += direction * baseSwingSpeed * Time.deltaTime;

            pendulum.transform.Rotate(0, 0, (progress - p) * maxAngle);

            if ((progress > 1 && direction == 1) || (progress < -1 && direction == -1))
            {
                direction *= -1;
            }
        }
    }

    public void StartPendulum()
    {
        swinging = true;
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
}
