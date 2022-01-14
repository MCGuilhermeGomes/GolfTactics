using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 100f;
    public int damage = 20;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start ()
    {
        countdown = delay;
    }

    public void Explode ()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            Unit unit = nearbyObject.GetComponent<Unit>();
            if (unit != null)
            {
                if (unit.team != this.GetComponent<Unit>().team)
                {
                    unit.TakeDamage(damage);
                    unit.TryToKill();
                }
            }
        }
        hasExploded = true;
    }

    public bool HasExploded ()
    {
        return hasExploded;
    }
}


