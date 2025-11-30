using UnityEngine;

public class ComputerInteractable : MonoBehaviour, IInteractableObject
{
    public Vector3 Position => transform.position;

    public void Facing()
    {
        Debug.Log("Facing");
    }

    public void DoAction()
    {
        Debug.Log("DoAction");
    }
}