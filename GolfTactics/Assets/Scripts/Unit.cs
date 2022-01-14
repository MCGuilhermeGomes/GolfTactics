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
            if(speed < 0.5) 
            {
                rb.velocity = new Vector3(0, 0, 0);
                isMoving = false;
                wasLaunched = false;
                bomb.Explode();
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
        isMoving = false;
        wasLaunched = false;
        currentHP = maxHP;
    }
}