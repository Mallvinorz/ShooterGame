using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation.x += Input.GetAxis("Mouse X") * 1000 * Time.deltaTime;
        currentRotation.y -= Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -90, 90);
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y,currentRotation.x,0);
    }
}
