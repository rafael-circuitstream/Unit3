using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("ENTER COLLISION");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ENTER COLLISION");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("FRICTION - IMAGINE DRAGONS");
    }
}
