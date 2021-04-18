using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color newColor;
    private void OnEnable()
    {
        ClickPlane.OnPlaneClicked += NewColor;
    }

    private void OnDisable()
    {
        ClickPlane.OnPlaneClicked -= NewColor;
    }

    void NewColor()
    {
        GetComponent<Renderer>().material.color = newColor;
    }

   
}
