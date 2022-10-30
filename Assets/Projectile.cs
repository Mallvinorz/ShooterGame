using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] projectiles;
    public float projectileVelocity;
    public GameObject shootPoint;

    public GameObject[] ultimateShootPoints;
    public float ultimateDuration;
    private float currentUltimateDuration = 0f;

    private bool isUsingUltimate = false;

    public float maximumBulletDistance;
    private int SPEED_KONSTAN = 10;
    private float[] fireRates = {1.2f, 0.2f};
    private float fireTimer = 0;
    private bool canShooting = true;
    private Vector2 currentShootPointPos;

    public RawImage[] weaponTypes;
    private int currentActiveWeaponIdx = 0;

    public GameObject[] shootAudios;
    // Update is called once per frame

    public GameObject explosionAnim;
    // Gun explosion animation

    private void CheckWeaponType() {
        for (int i = 0; i < weaponTypes.Length; i++)
        {
            if(i == currentActiveWeaponIdx){
                weaponTypes[i].color = new Color32(255,255,225,255);
            }else{
                weaponTypes[i].color = new Color32(255,255,225,100);
            }

        }
    }
    void Update()
    {
        CheckWeaponType();
        currentShootPointPos = new Vector2(this.transform.position.x, this.transform.position.z);
        CheckCanShoot();
        if(Input.GetButton("Fire1") && canShooting){
            LaunchProjectile();
            PlayShootSFX(currentActiveWeaponIdx);
            explosionAnim.GetComponent<Animator>().SetTrigger("ExplosionStates");   
            SetShootTimer(0);
        }
    }

    public void SetWeaponTypeIndex(int arg){
        currentActiveWeaponIdx = arg;
    }

    public Vector2 GetShootPointPos(){
        return currentShootPointPos;
    }
    void LaunchProjectile(){
        GameObject bullet = Instantiate(projectiles[currentActiveWeaponIdx], shootPoint.transform.position, shootPoint.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, -(projectileVelocity * SPEED_KONSTAN),0));
    }

    void UltimateShooting(){
        currentUltimateDuration += Time.deltaTime;
        if(currentUltimateDuration >= ultimateDuration) isUsingUltimate = false;
        
        for (int i = 0; i < ultimateShootPoints.Length; i++){
            GameObject bullet = Instantiate(projectiles[0], ultimateShootPoints[i].transform.position, ultimateShootPoints[i].transform.rotation);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, -(projectileVelocity * SPEED_KONSTAN),0));
        }
    }
    void CheckCanShoot(){
        fireTimer += Time.deltaTime;
        if(fireTimer >= fireRates[currentActiveWeaponIdx]){
            canShooting = true;
        }else{
            canShooting = false;
        }
    }

    void SetShootTimer(float arg){
        fireTimer = arg;
    }

    void PlayShootSFX(int arg){
        if(!shootAudios[arg].GetComponent<AudioSource>().isPlaying){
            shootAudios[arg].GetComponent<AudioSource>().Play();
        }
        // else{
        //     shootingAudio.GetComponent<AudioSource>().Stop();
        // }
        // shootingAudio.GetComponent<AudioSource>().Stop();
    }


}
