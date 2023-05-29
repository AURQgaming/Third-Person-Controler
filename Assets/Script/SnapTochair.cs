using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTochair : MonoBehaviour
{
    public GameObject SnapLocation;
    public Vector3 targetPosition;
    public Vector3 snapPosition;
    public float snapDistance = 1;
    public bool Snapped;
    private bool insideSnapzone;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            insideSnapzone = true;
        }
    }
}
