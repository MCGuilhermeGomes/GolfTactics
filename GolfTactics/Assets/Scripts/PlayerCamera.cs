using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public Camera playerCamera;
    public Camera mainCamera;

    private void Start()
    {
        playerCamera.enabled = false;
    }

    public void enableCamera()
    {
        mainCamera.enabled = false;
        playerCamera.enabled = true;
    }

    public void disableCamera()
    {
        mainCamera.enabled = true;
        playerCamera.enabled = false;
    }
}
