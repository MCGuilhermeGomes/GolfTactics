using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour
{
	public GameObject ball;
	public Unit ballUnit;
	public Rigidbody ballBody;
	public Transform target;
	public Transform actualTarget;
	public Bomb ballBomb;
	public BattleSystem battleSystem;
	public PendulumMinigame pendulum;
	
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
		if (debugPath)
		{
			DrawPath();
		}

		if (UIManager.main.state == UIGameState.Aiming)
			DrawArc();
		else
			ClearArc();


		if (ballBomb.hasExploded) // bomb i launched blew up, switch turn
		{
			target.GetComponent<CapsuleCollider>().enabled = true;
			target.position = Vector3.zero;
			actualTarget.position = Vector3.zero;
			battleSystem.SwitchTurn(false);
			ballBomb.hasExploded = false;
		}
	}

	public void updateBall()
    {
		ballUnit = ball.GetComponent<Unit>();
		ballBody = ball.GetComponent<Rigidbody>();
		ballBomb = ball.GetComponent<Bomb>();
		pendulum.setLaunchPoint(ball.transform);
	}

	public void Launch()
	{
		ball.transform.LookAt(actualTarget);
		ballUnit.wasLaunched = true;
		Physics.gravity = Vector3.up * gravity;
		ballBody.useGravity = true;
		ballBody.velocity = CalculateLaunchData().initialVelocity;
	}

	LaunchData CalculateLaunchData()
	{
		float displacementY = actualTarget.position.y - ballBody.position.y;
		Vector3 displacementXZ = new Vector3(actualTarget.position.x - ballBody.position.x, 0, actualTarget.position.z - ballBody.position.z);
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

	public void SwitchToPlayerCam()
    {
		target.GetComponent<DragWithTouch>().enabled = false;
		actualTarget.transform.position = target.transform.position;
		actualTarget.transform.rotation = target.transform.rotation;

		ball.transform.LookAt(target);
		ball.GetComponent<PlayerCamera>().enableCamera();
    }

    private void DrawArc()
	{
		LaunchData launchData = CalculateLaunchData();
		LineRenderer l = ArcPreview.instance.gameObject.GetComponent<LineRenderer>();
		Vector3 previousDrawPoint = ballBody.position;
		int resolution = 30;
		Vector3[] points = new Vector3[resolution];
		for (int i = 1; i <= resolution; i++)
		{
			float simulationTime = i / (float)resolution * launchData.timeToTarget;
			Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
			Vector3 drawPoint = ballBody.position + displacement;
			points[i-1] = drawPoint;
			previousDrawPoint = drawPoint;
		}

		l.positionCount = resolution;
		Color baseColor = ballUnit.team == 1 ? new Color(0f,0f,1f,0.5f) : new Color(1f, 0f, 0f, 0.5f);
		l.material.color = baseColor;
		l.SetPositions(points);
	}

	void ClearArc()
    {
		LineRenderer l = ArcPreview.instance.gameObject.GetComponent<LineRenderer>();
		l.positionCount = 0;
	}
}
