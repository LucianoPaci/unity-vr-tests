using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickPlane : MonoBehaviour
{

    public static Action OnPlaneClicked = null;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Fire1") || Input.GetButtonDown("BottomTrigger"))
        {
            OnPlaneClicked();
        }
        
    }
}
