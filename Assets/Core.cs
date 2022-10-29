using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    private float currentHP;
    public GameObject healthBar;
    private float maxWidthHP;
    public GameObject gameOverAudio;
    float percentageHP;

    // Update is called once per frame
    void Start()
    {
        currentHP = maxHealth;
        maxWidthHP = healthBar.GetComponent<RectTransform>().rect.width;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bullet") DecreaseHP(5);
        if(other.gameObject.tag == "Bomb") DecreaseHP(15);
        if(other.gameObject.tag == "Enemies") DecreaseHP(10);
    }
    void DecreaseHP(int damage){
        currentHP -= damage;
        percentageHP = currentHP/maxHealth;
        if(percentageHP <= 0) GameOver();
        Debug.Log(percentageHP);
     
        Slider HPBar = healthBar.GetComponent<Slider>();
        HPBar.value = percentageHP;
    }

    void GameOver(){
        Debug.Log("game over");
        if(!gameOverAudio.GetComponent<AudioSource>().isPlaying){
            gameOverAudio.GetComponent<AudioSource>().Play();
        }
        Time.timeScale = 0;
        return;
    }
    
}
