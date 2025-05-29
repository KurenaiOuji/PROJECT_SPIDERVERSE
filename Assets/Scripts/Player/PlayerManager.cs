using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    public GameObject player;   
    public Camera MainCamera;

    private void OnEnable()
    {
        EspejoManager.OnChangeTime += ChangeTime;
    }
    private void OnDisable()
    {
        EspejoManager.OnChangeTime -= ChangeTime;
    }

    void ChangeTime(int layer)
    {
        MainCamera.cullingMask = layer;

        switch (layer)
        {
            case 65: //Presente
                player.layer = 6;
                break;
            case 129: //Pasado
                player.layer = 7;
                break;
            case 257: //Futuro
                player.layer = 8;
                break;
        }
    }
}
