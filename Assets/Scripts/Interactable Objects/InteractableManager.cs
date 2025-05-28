using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public Camera Camera;
    public int layerMask = 0;
    public GameObject Player;
    int layerIndex;

    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Past"); 
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            layerMask++;

            Camera.cullingMask = (129); //64 Present, 65 Present/Default, 128 Past, 129 Past/Default, 256 Future, 257 Future/Default

            Player.layer = (7);
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            layerMask++;

            Camera.cullingMask = (65);

            Player.layer = (6);

        }
    }
}
