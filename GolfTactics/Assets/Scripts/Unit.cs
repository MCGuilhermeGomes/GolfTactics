using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public bool isMoving;
    public bool wasLaunched;
    public int damage;
    public int maxHP;
    public int currentHP;
    public Bomb bomb;

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
    }

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
}