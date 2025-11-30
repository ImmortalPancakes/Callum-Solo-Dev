using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableManager : MonoBehaviour
{
    [Header("Spherecast settings")]
    [Tooltip("How big should the spherecast be?")]
    [SerializeField] private float m_radius = 10;
    [SerializeField] private float m_maxDistance = 10;
    [SerializeField] private float m_hintDistance = 10;

    [SerializeField] private InputAction m_interactionButton = new ("Keyboard", InputActionType.Button, "<Keyboard>/e");

    private RaycastHit[] m_hitObjects = new RaycastHit[32];
    private IInteractableObject m_currentInteractable = null;

    private void OnEnable()
    {
        m_interactionButton.Enable();
        m_interactionButton.performed += ButtonPressed;
    }

    private void OnDisable()
    {
        m_interactionButton.Disable();
    }

    private void ButtonPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Button Pressed");
        //Check if m_currentInteractable != null and in facing state then do action
    }

    private void Update()
    {

        //Actually use SphereCastAll


        if (Physics.SphereCast(transform.position, m_radius, transform.forward, out var hit, m_maxDistance))
        {
            if(hit.transform.TryGetComponent<IInteractableObject>(out var interactableObject))
            {
                m_currentInteractable = interactableObject;
                //Calculate distance
                var distance = Vector3.Distance(interactableObject.Position, transform.position);
                if (distance < m_hintDistance)
                {
                    interactableObject.Facing();
                }
            }
        }
    }
}
