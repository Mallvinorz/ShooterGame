using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float maximumBulletDistance;
    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x;
        float zPos = transform.position.z;
        float distance = Mathf.Sqrt((xPos*xPos) + (zPos*zPos));
        
        if(distance >= maximumBulletDistance) Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        string tag = other.gameObject.tag;
        if(tag == "Obstacles" || tag == "Enemies"){
            Destroy(this.gameObject);
        }
    }
}
