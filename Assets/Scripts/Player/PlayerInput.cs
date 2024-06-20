using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private ObjectPool bulletsPool;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private CharacterController controller;
    [SerializeField] private LayerMask layerFilter;

    [Header("Shooting Settings")]
    [SerializeField] private ShootBehaviour shootBehaviour;
    [SerializeField] private Camera myCamera;

    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactableFilter;
    [SerializeField] private Transform pickupTip;
    [SerializeField] private Rigidbody playerRigibody;

    [Header("Other Modules")]
    [SerializeField] private CommanderModule commanderModule;
    private IInteractable selectedInteraction;
    private Vector3 velocity;
    private const float gravity = -9.81f;
    private Vector3 moveDirection;
    private Vector2 lookDirection;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //GameManager.Singleton.number1 = 20;
    }
    private void Update()
    {
        MovePlayer();
        RotatePlayer();
        JumpPlayer();
        ShootWeapon();
        GravityCalculation();
        Interact();
        ChangeWeapon();
        SendCommand();
    }

    private void SendCommand()
    {
        if(Input.GetMouseButtonDown(1))
        {
            commanderModule.CreateCommand();
        }
    }
    private void ChangeWeapon()
    {
        float input = Input.GetAxisRaw("Mouse ScrollWheel");
        Debug.Log(input);
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            shootBehaviour.ChangeWeapon(1);
        }
    }
    private void Interact()
    {
        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f, interactableFilter)) //HIT SOMETHING ON THE RAYCAST
        {
            if(selectedInteraction == null) //BUT PREVIOUSLY I DIDN'T HAVE ANYTHING STORED
            {
                selectedInteraction = hit.collider.gameObject.GetComponent<IInteractable>();
                selectedInteraction.OnHoverEnter();
            }
            
            if (Input.GetKeyDown(KeyCode.E)) //IF I HAVE AN INTERACTION STORED AND PRE
            {
                selectedInteraction.Interact(this);
            }
        }
        else if(selectedInteraction != null) //IF DIDN'T FIND ANYTHING
        {
            selectedInteraction.OnHoverExit();
            selectedInteraction = null;
        }
    }
    private void ShootWeapon()
    {

        if(Input.GetMouseButtonDown(0))
        {
            shootBehaviour.ShootWeapon();
            //PooledObject pooledObj = bulletsPool.RetrievePoolObject();
            //Rigidbody projectileClone = pooledObj.GetRigidbody();
            //projectileClone.position = weaponTip.position;
            //projectileClone.rotation = weaponTip.rotation;
            //projectileClone.AddForce(myCamera.transform.forward * projectileSpeed, ForceMode.Impulse);
            //pooledObj.ResetPooledObject(4f);
        }
    }
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, controller.radius, layerFilter);
    }
    private void GravityCalculation()
    {
        if(!IsGrounded()) //THIS MEANS IM FALLING
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if(velocity.y <= 0)
        {
            velocity.y = -1f;
        }

        controller.Move(velocity * Time.deltaTime);
    }
    private void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            velocity.y = jumpForce;
        }
    }
    private void MovePlayer()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        Vector3 moveForward = transform.forward * moveDirection.z;
        Vector3 moveRight = transform.right * moveDirection.x;

        float speedMultiplier = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMultiplier = sprintMultiplier;
        }

        controller.Move((moveForward + moveRight) * Time.deltaTime * speed * speedMultiplier);
    }
    private void RotatePlayer()
    {
        lookDirection.x += Input.GetAxisRaw("Mouse X") * Time.deltaTime * lookSensitivity;
        lookDirection.y += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * lookSensitivity;

        lookDirection.y = Mathf.Clamp(lookDirection.y, -85f, 85f);

        myCamera.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);
    }

    public Rigidbody GetPlayerRigidbody()
    {
        return playerRigibody;
    }

    public Transform GetPickUpLocation()
    {
        return pickupTip;
    }
}
