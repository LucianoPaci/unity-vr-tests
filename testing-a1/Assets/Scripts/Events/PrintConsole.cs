using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintConsole : MonoBehaviour
{

    private void OnEnable()
    {
        ClickPlane.OnPlaneClicked += PrintSomething;
    }

    private void OnDisable()
    {
        ClickPlane.OnPlaneClicked -= PrintSomething;
    }


    void PrintSomething()
    {
        Debug.Log("Something");
    }
}
