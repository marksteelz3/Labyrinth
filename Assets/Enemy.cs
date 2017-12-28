using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float health = 50f;
    public Image hBar;
    public float moveSpeed = 1f;
    public float moveRange = 100f;

    private float startHealth;
    private float movePos;
    private bool forward;

    private void Start()
    {
        startHealth = health;
        movePos = 0;
        forward = true;
    }

    private void Update()
    {
        if (forward)
        {
            this.transform.Translate(transform.forward * moveSpeed);
            movePos++;
            if (movePos >= moveRange)
            {
                forward = false;
                movePos = 0;
            }
        }
        if (forward == false)
        {
            this.transform.Translate(transform.forward * moveSpeed * (-1f));
            movePos++;
            if (movePos >= moveRange)
            {
                forward = true;
                movePos = 0;
            }
        }

    }

    public void GetHit(float damage)
    {
        health -= damage;
        hBar.fillAmount = health / startHealth;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
