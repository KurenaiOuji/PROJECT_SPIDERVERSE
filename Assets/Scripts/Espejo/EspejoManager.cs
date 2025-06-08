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
    public GameObject artefacto;

    private int[] layerMask = new int[] { 129, 65, 257 };
    private int currentIndex = 1;

    public int minLayer, maxLayer;

    public bool mirrorOn = false;

    private UniversalAdditionalCameraData cameraData;

    GameState currentState;
    bool state = true;

    enum GameState
    {
        PlayState,
        PauseState
    }

    private void OnEnable()
    {
        PauseManager.OnPauseGame += ChangeState;
        InteractableManager.OnPastUnlock += PastUnlock;
        InteractableManager.OnFutureUnlock += FutureUnlock;
    }

    private void OnDisable()
    {
        PauseManager.OnPauseGame -= ChangeState;
        InteractableManager.OnPastUnlock -= PastUnlock;
        InteractableManager.OnFutureUnlock -= FutureUnlock;
    }

    //64 Present, 65 Present/Default, 128 Past, 129 Past/Default, 256 Future, 257 Future/Default
    void Start()
    {
        LayerCamera.cullingMask = (65);
        cameraData = LayerCamera.GetComponent<UniversalAdditionalCameraData>();
        cameraData.SetRenderer(1);
    }

    void Update()
    {
        if (currentState == GameState.PlayState)
        {
            Showmirror();
            ChangeRenderTexture();
            ChangeTime();
        }
    }

    void Showmirror()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mirrorOn = !mirrorOn;
            mirrorTexture.enabled = mirrorOn;
            artefacto.SetActive(mirrorOn);
        }
    }

    void ChangeRenderTexture()
    {
        if (Input.GetKeyDown(KeyCode.Z) && mirrorOn)
        {
            currentIndex = Mathf.Max(minLayer, currentIndex - 1);
            LayerCamera.cullingMask = layerMask[currentIndex];
            cameraData.SetRenderer(currentIndex);
        }

        if (Input.GetKeyDown(KeyCode.X) && mirrorOn)
        {
            currentIndex = Mathf.Min(maxLayer, currentIndex + 1);
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

    void ChangeState()
    {
        state = !state;
        currentState = state ? GameState.PlayState : GameState.PauseState;
    }

    void FutureUnlock()
    {
        maxLayer = 2;
    }

    void PastUnlock()
    {
        minLayer = 0;
    }
}
