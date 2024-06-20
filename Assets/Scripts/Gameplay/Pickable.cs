using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody myRigidbody;
    private FixedJoint joint;
    private Transform originalParent;
    public void Interact(PlayerInput player)
    {
        if(transform.parent == null)
        {
            transform.position = player.GetPickUpLocation().position;
            transform.SetParent(player.GetPickUpLocation());

            myRigidbody.useGravity = false;
            myRigidbody.isKinematic = true;
        }
        else
        {
            transform.SetParent(null);

            myRigidbody.useGravity = true;
            myRigidbody.isKinematic = false;
        }
    }


    public void OnHoverEnter()
    {
        
    }

    public void OnHoverExit()
    {
        
    }
}
