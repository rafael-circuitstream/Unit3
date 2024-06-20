using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ShootBehaviour shoot;
    [SerializeField] private JumpBehaviour jump;

    private void Update()
    {
        CheckShootInput();
        CheckJumpImput();
    }

    private void CheckShootInput()
    {
        if (shoot)
        {
            if(Input.GetMouseButtonDown(0))
            {
                
                shoot.ShootWeapon();
            }
        }
    }

    private void CheckJumpImput()
    {
        if (jump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump.JumpCharacter();
            }
        }
    }
}
