using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
public int movementSpeed;
    // Update is called once per frame
    void Update()
    {
        MovingRelativeToCamera();
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
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
}
