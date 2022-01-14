using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public Camera playerCamera;

    private void Start()
    {
        playerCamera.enabled = false;
    }

    public void enableCamera()
    {
        Camera.main.enabled = false;
        playerCamera.enabled = true;
    }

    public void disableCamera()
    {
        Camera.main.enabled = true;
        playerCamera.enabled = false;
    }
}
