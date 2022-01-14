using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public int damage;
    public int maxHP;
    public int currentHP;
    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
    }
}