using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnButtonPressed;
    [SerializeField] private Material highlightedMaterial;

    private Material originalMaterial;
    private MeshRenderer myRender;

    private void Awake()
    {
        myRender = GetComponent<MeshRenderer>();
        originalMaterial = myRender.material;
        
    }
    public void Interact(PlayerInput player)
    {
        OnButtonPressed.Invoke();
    }

    public void OnHoverEnter() //THIS SHOULD ONLY BE EXECUTED ONCE
    {
        myRender.material = highlightedMaterial;
    }

    public void OnHoverExit() //THIS SHOULD ONLY BE EXECUTED ONCE
    {
        myRender.material = originalMaterial;
    }
}
