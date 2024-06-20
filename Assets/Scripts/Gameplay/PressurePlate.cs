using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour,  IPuzzlePiece
{
    //[SerializeField] private List<Rigidbody> correctRigidbodies = new List<Rigidbody>();

    [SerializeField] private Rigidbody correctRigidbody;
    [SerializeField] private UnityEvent OnActivate;
    [SerializeField] private UnityEvent OnDeactivate;
    private bool isCorrectRigidBodyOn;
    public bool IsCorrect { get => isCorrectRigidBodyOn; set => isCorrectRigidBodyOn = value; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody == correctRigidbody)
        {
            //DOOR WILL OPEN
            isCorrectRigidBodyOn = true;
            OnActivate.Invoke();
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody == correctRigidbody)
        {
            //DOOR WILL OPEN
            //OnActivate.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == correctRigidbody)
        {
            isCorrectRigidBodyOn = false;
            OnDeactivate.Invoke();
        }

        /*
        if(correctRigidbodies.Contains(other.attachedRigidbody))
        {
            OnActivate.Invoke();
        }
        */
    }
}
