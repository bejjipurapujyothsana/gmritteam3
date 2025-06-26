using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class arscale : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text text2;
    public Vector3 scale;
    public float startDistance;
    public GameObject SObject;

    void Start()
    {
        text.text = "Debug Data";
    }

    void Update()
    {
        // Display touch data
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

        // Raycast from mouse/tap to get selected object
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            text2.text = hit.transform.tag;
            SObject = hit.transform.gameObject;
        }

        // Handle two-finger scaling gesture
        if (Input.touchCount >= 2 && SObject != null)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                startDistance = Vector2.Distance(touch0.position, touch1.position);
                scale = SObject.transform.localScale;
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch0.position, touch1.position);
                float factor = currentDistance / startDistance;

                // Optional clamp to prevent too much shrinking/enlarging
                factor = Mathf.Clamp(factor, 0.1f, 10f);

                SObject.transform.localScale = scale * factor;
                text.text += $"\nScaling Factor: {factor:F2}";
            }
        }
    }
}

