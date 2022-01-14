using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcPreview : MonoBehaviour
{
    public static ArcPreview instance;

    public static ArcPreview Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    public Gradient GetGradient(int team)
    {
        gradient = new Gradient();

        Color mainColor = team == 1 ? Color.blue : Color.red;

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = mainColor + (Color.green / 2);
        colorKey[0].time = 0.0f;
        colorKey[1].color = mainColor;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 0.7f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        return gradient;
    }

    public void DrawArc(Vector3[] positions, int team)
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.positionCount = positions.Length;
        lr.colorGradient = GetGradient(team);
    }
}