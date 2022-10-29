using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 currentRotation;
    public GameObject player;
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
        currentRotation.y = Mathf.Clamp(currentRotation.y, -90, 45);
        // Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -3.22f + currentRotation.x * 0.01f) ;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, currentRotation.y * 0.05f + 2, Camera.main.transform.position.z);
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y,currentRotation.x,0);
    }
}
