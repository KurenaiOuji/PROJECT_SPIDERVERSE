using UnityEngine;
using System;
using UnityEngine.Rendering.Universal;

public class EspejoManager : MonoBehaviour
{
    public static Action<int> OnChangeTime;

    [Header("References")]
    [Tooltip("Camara que muestra el Layer")]
    public Camera LayerCamera;
    public Canvas mirrorTexture;

    private int[] layerMask = new int[] { 129, 65, 257 };
    private int currentIndex = 1;

    public bool mirrorOn = false;

    private UniversalAdditionalCameraData cameraData;

    //64 Present, 65 Present/Default, 128 Past, 129 Past/Default, 256 Future, 257 Future/Default
    void Start()
    {
        LayerCamera.cullingMask = (65);
        cameraData = LayerCamera.GetComponent<UniversalAdditionalCameraData>();
        cameraData.SetRenderer(1);
    }

    void Update()
    {
        Showmirror();
        ChangeRenderTexture();
        ChangeTime();
    }

    void Showmirror()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mirrorOn = !mirrorOn;
            mirrorTexture.enabled = mirrorOn;
        }
    }

    void ChangeRenderTexture()
    {
        if (Input.GetKeyDown(KeyCode.Z) && mirrorOn)
        {
            currentIndex = Mathf.Max(0, currentIndex - 1);
            LayerCamera.cullingMask = layerMask[currentIndex];
            cameraData.SetRenderer(currentIndex);
        }

        if (Input.GetKeyDown(KeyCode.X) && mirrorOn)
        {
            currentIndex = Mathf.Min(layerMask.Length - 1, currentIndex + 1);
            LayerCamera.cullingMask = layerMask[currentIndex];
            cameraData.SetRenderer(currentIndex);
        }
    }

    void ChangeTime()
    {
        int currentMask = layerMask[currentIndex];

        if(Input.GetKeyDown(KeyCode.E) && mirrorOn)
        {
            OnChangeTime?.Invoke(currentMask);
        }
    }
}
