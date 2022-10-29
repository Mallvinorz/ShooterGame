using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
  
    public GameObject target;
    // Update is called once per frame
    void Update()
    {
         this.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 5);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Core" || other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bomb") Destroy(this.gameObject);
    }
}
