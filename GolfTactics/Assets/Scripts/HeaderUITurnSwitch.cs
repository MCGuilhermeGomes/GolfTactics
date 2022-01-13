using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderUITurnSwitch : MonoBehaviour
{
    public static HeaderUITurnSwitch main;

    public Image P1HeaderPanel;
    public Image P2HeaderPanel;

    public int currentPlayer = 1;
    public float fade = 5f;

    // Start is called before the first frame update
    void Start()
    {
        main = this;

        if (currentPlayer == 1)
        {
            P2HeaderPanel.color = new Color(P2HeaderPanel.color.r, P2HeaderPanel.color.g, P2HeaderPanel.color.b, 0f);
            P1HeaderPanel.color = new Color(P1HeaderPanel.color.r, P1HeaderPanel.color.g, P1HeaderPanel.color.b, 1f);
        }

        if (currentPlayer == 2)
        {
            P1HeaderPanel.color = new Color(P1HeaderPanel.color.r, P1HeaderPanel.color.g, P1HeaderPanel.color.b, 0f);
            P2HeaderPanel.color = new Color(P2HeaderPanel.color.r, P2HeaderPanel.color.g, P2HeaderPanel.color.b, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer == 1)
        {
            P1HeaderPanel.color = new Color(P1HeaderPanel.color.r, P1HeaderPanel.color.g, P1HeaderPanel.color.b, Mathf.Min(1, P1HeaderPanel.color.a + fade * Time.deltaTime));
            P2HeaderPanel.color = new Color(P2HeaderPanel.color.r, P2HeaderPanel.color.g, P2HeaderPanel.color.b, Mathf.Max(0, P2HeaderPanel.color.a - fade * Time.deltaTime));
        }
        if (currentPlayer == 2)
        {
            P1HeaderPanel.color = new Color(P1HeaderPanel.color.r, P1HeaderPanel.color.g, P1HeaderPanel.color.b, Mathf.Max(0, P1HeaderPanel.color.a - fade * Time.deltaTime));
            P2HeaderPanel.color = new Color(P2HeaderPanel.color.r, P2HeaderPanel.color.g, P2HeaderPanel.color.b, Mathf.Min(1, P2HeaderPanel.color.a + fade * Time.deltaTime));
        }
    }

    public void SwitchPlayer()
    {
        Debug.Log("switch " + currentPlayer);
        if(currentPlayer == 1)
        {
            currentPlayer = 2;
        }
        else
        {
            if (currentPlayer == 2)
            {
                currentPlayer = 1;
            }
        }
    }
}
