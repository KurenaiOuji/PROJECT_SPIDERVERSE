using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform PlayerCamera;

    float PlayerRange = 5f;

    Interactable currentInteractable;

    void Update()
    {
        CheckInteraction();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }      
    }

    void CheckInteraction()
    {
        RaycastHit hit;

        Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

        if(Physics.Raycast(ray, out hit, PlayerRange))
        {
            if(hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }

                else
                {
                    DisableCurrentInteractable();
                }
            }

            else
            {
                DisableCurrentInteractable();
            }
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HUDController.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();

        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
