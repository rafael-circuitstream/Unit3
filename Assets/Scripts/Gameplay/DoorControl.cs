using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    public void OpenDoor()
    {
        if(!animator.GetBool("DoorOpen"))
            animator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        if (animator.GetBool("DoorOpen"))
            animator.SetBool("DoorOpen", false);
    }

    public void DynamicOpenCloseDoor()
    {
        if(animator.GetBool("DoorOpen"))
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
}
