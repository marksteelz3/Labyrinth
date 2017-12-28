using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float damage = 5f;
    public Camera cam;
    public ParticleSystem flash;

    private AudioSource sound;

    // Use this for initialization
    void Start () {
        sound = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            Pop();
        }
	}

    void Pop()
    {
        flash.Play();

        sound.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetHit(damage);
            }
        }
    }
}
