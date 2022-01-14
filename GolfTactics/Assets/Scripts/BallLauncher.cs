using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour
{
	public GameObject ball;
	public Unit ballUnit;
	public Rigidbody ballBody;
	public Transform target;
	public Bomb ballBomb;
	public BattleSystem battleSystem;
	
	public float h = 25;
	public float gravity = -18;

	public bool debugPath;

	public static BallLauncher main;

    private void Start()
    {
		main = this;
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) //button/touch click
		{
			SwitchToPlayerCam();
			Launch();
		}

		if (debugPath)
		{
			DrawPath();
		}

		if (ballBomb.HasExploded()) // bomb i launched blew up, switch turn
		{
			battleSystem.SwitchTurn();
		}
	}

	public void updateBall()
    {
		ballUnit = ball.GetComponent<Unit>();
		ballBody = ball.GetComponent<Rigidbody>();
		ballBomb = ball.GetComponent<Bomb>();
	}

	public void Launch()
	{
		ballUnit.wasLaunched = true;
		Physics.gravity = Vector3.up * gravity;
		ballBody.useGravity = true;
		ballBody.velocity = CalculateLaunchData().initialVelocity;
	}

	LaunchData CalculateLaunchData()
	{
		float displacementY = target.position.y - ballBody.position.y;
		Vector3 displacementXZ = new Vector3(target.position.x - ballBody.position.x, 0, target.position.z - ballBody.position.z);
		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}

	void DrawPath()
	{
		LaunchData launchData = CalculateLaunchData();
		Vector3 previousDrawPoint = ballBody.position;

		int resolution = 30;
		for (int i = 1; i <= resolution; i++)
		{
			float simulationTime = i / (float)resolution * launchData.timeToTarget;
			Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
			Vector3 drawPoint = ballBody.position + displacement;
			Debug.DrawLine(previousDrawPoint, drawPoint, Color.red);
			previousDrawPoint = drawPoint;
		}
	}

	struct LaunchData
	{
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}

	}

	void SwitchToPlayerCam()
    {

    }
}
