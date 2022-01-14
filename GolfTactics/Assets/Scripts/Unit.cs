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

            if (landed && !bomb.hasExploded)
            {
                bomb.Explode();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Landed");
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
    }

    public void EndMove()
    {
        bomb.hasExploded = false;
        rb.velocity = new Vector3(0, 0, 0);
        isMoving = false;
        wasLaunched = false;
        landed = false;
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
        transform.localRotation = Quaternion.identity;
        Debug.Log("I DIED");
    }

    public void Respawn()
    {
        if (currentHP <= 0)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<Collider>().enabled = true;
            isMoving = false;
            wasLaunched = false;
            currentHP = maxHP;   
        }
    }
}