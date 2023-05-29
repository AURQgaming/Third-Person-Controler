using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snaploocation : MonoBehaviour
{
    private bool grabbled;

    private bool insideSnapzone;

    public bool Snapped;

    public GameObject MyPlayer;

    public GameObject SnapRoationRefrence;



    private void OntriggerEnter(Collider other)
    {
        if (other.gameObject.name == MyPlayer.name)
        {
            insideSnapzone = true;
        }
    }

    private void OntriggerExit(Collider other)
    {
        if (other.gameObject.name == MyPlayer.name)
        {
            insideSnapzone = false;
        }
    }

    void SnapObject()
    {
        if (grabbled == false  && insideSnapzone == true)
        {
            MyPlayer.gameObject.transform.position = transform.position;
            MyPlayer.gameObject.transform.rotation = SnapRoationRefrence.transform.rotation;
            Snapped = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        SnapObject();
        
    }
}
