using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeBar : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Slider s = GetComponent<Slider>();
        Unit u = gameObject.GetComponentInParent<Unit>();

        s.value = u.currentHP / u.maxHP;
    }
}
