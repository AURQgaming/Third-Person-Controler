using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapControler : MonoBehaviour
{
    public GameObject SnapLocation;

    public GameObject player;

    public bool isSnapped;

    private bool objectSnapped;

    private bool grabbed;

    void update()
    {
        objectSnapped = SnapLocation.GetComponent<Snaploocation>().Snapped;

        if (objectSnapped == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(player.transform);
            isSnapped = true;
        }

        if (objectSnapped == false && grabbed == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
