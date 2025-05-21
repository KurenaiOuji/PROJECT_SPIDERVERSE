using UnityEngine;

public class Destroy : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Me Destrui");
        //Destroy(gameObject);
    }
}
