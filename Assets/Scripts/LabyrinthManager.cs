using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LabyrinthManager : MonoBehaviour {

    public float health;
    public int totalCrystals;
    public int crystals;
    public AudioClip crystalAud;
    public AudioClip damageAud;
    public GameObject player;
    public Image hBar;

    private AudioSource sound;
    private float startHealth;

    // Use this for initialization
    void Start () {
        sound = this.GetComponent<AudioSource>();
        crystals = 0;
        startHealth = health;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCrystal()
    {
        sound.clip = crystalAud;
        sound.Play();
        crystals++;
    }

    public void WinGame()
    {
        if (crystals >= totalCrystals)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        hBar.fillAmount = health / startHealth;

        sound.clip = damageAud;
        sound.Play();

        if (health <= 0f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
