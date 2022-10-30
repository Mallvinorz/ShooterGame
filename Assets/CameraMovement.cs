using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 currentRotation;
    private float speedRotation = 2000;
    // Update is called once per frame
    void Update()
    {
        currentRotation.x += Input.GetAxis("Mouse X") * speedRotation * Time.deltaTime;
        currentRotation.y -= Input.GetAxis("Mouse Y") * speedRotation * Time.deltaTime;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -90, 45);
        
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, currentRotation.y * 0.05f + 2, Camera.main.transform.position.z);
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y,currentRotation.x,0);
    }
}
