using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public Transform cameraPositionA;
    public Transform cameraPositionB;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = cameraPositionA.position;
            transform.rotation = cameraPositionA.rotation;
        } else if (Input.GetKeyDown(KeyCode.B))
        {
            transform.position = cameraPositionB.position;
            transform.rotation = cameraPositionB.rotation;
        }
    }
}
