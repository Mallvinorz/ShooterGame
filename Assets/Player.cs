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
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementDirection.Normalize();
        this.transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);
    }
}
