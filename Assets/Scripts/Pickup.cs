using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private MeshRenderer myRend;

   void Start()
    {
        myRend = GetComponent<MeshRenderer>();
    }

    void ClickMe()
    {
        Destroy(myRend);
    }
}
