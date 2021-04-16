using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{

    private void OnEnable()
    {
        ClickPlane.OnPlaneClicked += MoveUp;
    }

    private void OnDisable()
    {
        ClickPlane.OnPlaneClicked -= MoveUp;
    }

    void MoveUp()
    {
        transform.position = Vector3.up;
    }
}

