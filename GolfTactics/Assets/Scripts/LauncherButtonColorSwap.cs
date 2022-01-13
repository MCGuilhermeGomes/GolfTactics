using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LauncherButtonColorSwap : MonoBehaviour
{
    public static LauncherButtonColorSwap main;

    public GameObject ButtonObject;

    public int currentPlayer = 1;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer == 1)
        {
            ButtonObject.GetComponent<Image>().color = Color.blue;
            ColorBlock c = ButtonObject.GetComponent<Button>().colors;
            c.pressedColor = new Color(0, 0, 0.5f);
            ButtonObject.GetComponent<Button>().colors = c;
        }

        if (currentPlayer == 2)
        {
            ButtonObject.GetComponent<Image>().color = Color.red;
            ColorBlock c = ButtonObject.GetComponent<Button>().colors;
            c.pressedColor = new Color(0.5f, 0, 0f);
            ButtonObject.GetComponent<Button>().colors = c;
        }
    }

    public void SwitchPlayer()
    {
        if (currentPlayer == 1)
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
