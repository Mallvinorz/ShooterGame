using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosionSfx;
    private AudioSource explosionSfxAudio;
    private bool isPlaying = false;
    void Start()
    {
        explosionSfxAudio = explosionSfx.GetComponent<AudioSource>();
        isPlaying = true;
        if(!explosionSfxAudio.isPlaying){
            explosionSfxAudio.Play();   
        }
    }

    private void Update() {
        if(!explosionSfxAudio.isPlaying && isPlaying){
            Destroy(this.gameObject);//destroy particle after it explode and sounded
        }
    }
}
