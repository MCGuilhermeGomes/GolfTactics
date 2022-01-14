using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public bool isMoving;
    public bool wasLaunched;
    public int maxHP;
    public int currentHP;
    public Bomb bomb;
    public int team;

    private bool landed = false;
    private bool exploded = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isMoving = false;
        wasLaunched = false;
    }

    void Update()
    {
        if (wasLaunched)
        {
            speed = GetComponent<Rigidbody>().velocity.magnitude;

            if (GetComponent<Rigidbody>().velocity.y == 0 && !landed)
                landed = true;

            if (landed && !exploded)
            {
                bomb.Explode();
                exploded = true;
            }

            if (speed < 0.5) 
            {
                EndMove();
            } else
            {
                isMoving = true;
            }
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
    }

    public void EndMove()
    {
        rb.velocity = new Vector3(0, 0, 0);
        isMoving = false;
        wasLaunched = false;
        landed = false;
        exploded = false;
    }

    public bool TryToKill()
    {
        if (currentHP <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    void Die()
    {
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
        transform.localRotation.eulerAngles.Set(0, 0, 0);
        Debug.Log("I DIED");
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Collider>().enabled = true;
        isMoving = false;
        wasLaunched = false;
        currentHP = maxHP;
    }
}