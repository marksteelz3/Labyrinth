using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject manager;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crystal"))
        {
            manager.GetComponent<LabyrinthManager>().AddCrystal();
        }
        if (other.CompareTag("Enemy"))
        {
            manager.GetComponent<LabyrinthManager>().TakeDamage(10);
        }
        Destroy(other.gameObject);
    }
}
