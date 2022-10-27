using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float maximumBulletDistance;
    public Projectile projectile;
    private Vector3 startPos;
    // Update is called once per frame
    void Start(){
        startPos = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }
    void Update()
    {
        float xMagnitude = Mathf.Abs(this.transform.position.x) - Mathf.Abs(startPos.x);
        float zMagnitude = Mathf.Abs(this.transform.position.z) - Mathf.Abs(startPos.z);
        
        float distance = Mathf.Sqrt((xMagnitude*xMagnitude) + (zMagnitude*zMagnitude));
        Debug.Log(distance);

        if(distance >= maximumBulletDistance) Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        string tag = other.gameObject.tag;
        if(tag == "Obstacles" || tag == "Enemies"){
            Destroy(this.gameObject);
        }
    }
}
