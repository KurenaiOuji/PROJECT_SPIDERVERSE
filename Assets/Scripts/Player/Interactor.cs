using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{/*
    [Header("References")]
    [SerializeField] private Transform InteractorSource;

    [Space(5)]
    [Header("Interactor Settings")]
    [SerializeField] private float InteractorRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray InteractorRay = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(InteractorRay, out RaycastHit hitInfo, InteractorRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }*/


}
