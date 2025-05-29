using Cinemachine;
using UnityEngine;

public class CaneraManager : MonoBehaviour
{
    public CinemachineClearShot clearShot;
    public Camera monitorCamera;

    void LateUpdate()
    {
        CinemachineVirtualCameraBase activeVCam = (CinemachineVirtualCameraBase)(clearShot?.LiveChild);
        if (activeVCam != null)
        {
            Transform vcamTransform = activeVCam.transform;
            monitorCamera.transform.position = vcamTransform.position;
            monitorCamera.transform.rotation = vcamTransform.rotation;
        }
    }
}
