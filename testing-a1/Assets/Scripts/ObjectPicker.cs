using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(Collider))]
public class ObjectPicker : MonoBehaviour
{
    public GameObject obj, player;
    private bool looking = false;
    public float minDistance = 10.0f;
    private float distance;

    private Vector3 startingPosition;
    // Use this for initialization
    void Start()
    {
        startingPosition = transform.localPosition;
        looking = false;
    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, obj.transform.position);
        //Destroy(distance);
        //ChangeColor(distance);
        //ChangeMaterial(distance);
        RandomTeleport(distance);


    }

    void ChangeColor(float dist)
    {
        GetComponent<Renderer>().material.color = (looking && dist <= minDistance) ?
     Color.green : Color.red;
    }

    void ChangeMaterial(float dist)
    {
        if (looking)
        {
            if (dist <= minDistance)
            {
                if (Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("TopTrigger"))
                {
                    if (GetComponent<Renderer>().material != null)
                    {
                        GetComponent<Renderer>().material = null;
                        return;
                    }
                }
            }
        }

    }
    #region IGvrGazeResponder implementation
    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        looking = true;
    }
    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// /// was already called.
    public void OnGazeExit()
    {
        looking = false;
    }
    /// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
    public void OnGazeTrigger()
    {
        if (distance <= minDistance)
        {
            obj.SetActive(false);
        }
    }

    public void Destroy(float distance)
    {
        if (looking)
        {
            if (distance <= minDistance)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("BottomTrigger"))
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    public void RandomTeleport(float dist)
    {
        if (looking)
        {
            if (dist <= minDistance)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("BottomTrigger"))
                {
                    int sibIdx = transform.GetSiblingIndex();
                    int numSibs = transform.parent.childCount;
                    sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
                    GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

                    // Move to random new location ±90˚ horzontal.
                    Vector3 direction = Quaternion.Euler(
                        0,
                        Random.Range(-90, 90),
                        0) * Vector3.forward;

                    // New location between 2m and 4m.
                    float distance = (2 * Random.value) + 2f;
                    Vector3 newPos = direction * distance;

                    // Limit vertical position to be fully in the room.
                    newPos.y = Mathf.Clamp(newPos.y, -1.2f, 4f);
                    randomSib.transform.localPosition = newPos;

                    randomSib.SetActive(true);
                    gameObject.SetActive(false);
                    // SetGazedAt(false);
                    looking = false;
                }
                else
                {
                    return;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                if (Input.GetKeyDown("joystick button " + i))
                {
                    print("joystick 1 button " + i);

                    if (Input.GetButtonDown("BottomTrigger"))
                    {
                        print("BOTTOM TRIGGER!");
                    }
                    if (Input.GetButtonDown("TopTrigger"))
                    {
                        print("TOP TRIGGER!");
                    }
                }
            }
        }

    }
    #endregion

    public void Reset()
    {
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        for (int i = 0; i < numSibs; i++)
        {
            GameObject sib = transform.parent.GetChild(i).gameObject;
            sib.transform.localPosition = startingPosition;
            sib.SetActive(i == sibIdx);
        }
    }

    public void TeleportRandomly(BaseEventData eventData)
    {
        //Only trigger on TRIGGER BUTTON
        PointerEventData ped = eventData as PointerEventData;
        if (ped != null)
        {

            if (ped.button != PointerEventData.InputButton.Left && !Input.GetButtonDown("BottomTrigger"))
            {
                return;
            }
        }

        // Pick a random sibling, move them somewhere random, activate them,
        // deactivate ourself.
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
        GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

        // Move to random new location ±90˚ horzontal.
        Vector3 direction = Quaternion.Euler(
            0,
            Random.Range(-90, 90),
            0) * Vector3.forward;

        // New location between 2m and 4m.
        float distance = (2 * Random.value) + 2f;
        Vector3 newPos = direction * distance;

        // Limit vertical position to be fully in the room.
        newPos.y = Mathf.Clamp(newPos.y, -1.2f, 4f);
        randomSib.transform.localPosition = newPos;

        randomSib.SetActive(true);
        gameObject.SetActive(false);
        // SetGazedAt(false);
        looking = false;

    }

}