using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public float projectileVelocity;
    public GameObject shootPoint;

    public float maximumBulletDistance;
    private int SPEED_KONSTAN = 10;
    private float fireRate = 0.2f;
    private float fireTimer = 0;
    private bool canShooting = true;
    // Update is called once per frame
    void Update()
    {
        CheckCanShoot();
        if(Input.GetButton("Fire1") && canShooting){
            LaunchProjectile();
            SetShootTimer(0);
        }
    }

    void LaunchProjectile(){
        GameObject bullet = Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, -(projectileVelocity * SPEED_KONSTAN),0));
    }

    void CheckCanShoot(){
        fireTimer += Time.deltaTime;
        if(fireTimer >= fireRate){
            canShooting = true;
        }else{
            canShooting = false;
        }
    }

    void SetShootTimer(float arg){
        fireTimer = arg;
    }
}
