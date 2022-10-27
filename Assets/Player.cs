using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
public int movementSpeed;
    // Update is called once per frame
    public GameObject gun;
    private Vector2 currentRotation;
    void Update()
    {
        MovingRelativeToCamera();
        RotateGun();
        
        float speed = 0.1f;
        Quaternion currentRot = transform.rotation;
        transform.rotation = Quaternion.Slerp(currentRot, Camera.main.transform.rotation, speed);
        // Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // movementDirection.Normalize();
        // this.transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);
    }

    void MovingRelativeToCamera(){
        float playerVerInput = Input.GetAxis("Vertical");
        float playerHorInput = Input.GetAxis("Horizontal");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Vector3 forwardRelativeVerticalInput = forward * playerVerInput;
        Vector3 rightRelativeVerticalInput = right * playerHorInput;

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        transform.Translate(cameraRelativeMovement * movementSpeed * Time.deltaTime, Space.World);
    }

    void RotateGun(){
        currentRotation.x += Input.GetAxis("Mouse X") * 1000 * Time.deltaTime;
        currentRotation.y -= Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -90, 90);
        // currentRotation.y - 105.945f
        gun.transform.rotation = Quaternion.Euler( currentRotation.y - 105.945f, currentRotation.x, this.transform.rotation.z);
    }
}
