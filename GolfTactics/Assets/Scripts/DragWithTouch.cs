using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWithTouch : MonoBehaviour
{
    private Touch touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * Time.deltaTime,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * Time.deltaTime);
            }
        }
    }
}
