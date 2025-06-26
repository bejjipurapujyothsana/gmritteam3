using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Don't forget this for TMP_Text

public class arscale : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text text2;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Debug Data";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            text.text = "Touch Data\n";
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                text.text += $"i: {i}, Position: {touch.position}\n";
            }
        }
        else
        {
            text.text = "No touch detected";
        }
    }
}

