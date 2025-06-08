using UnityEngine;
using UnityEngine.SceneManagement;

public class LightDetection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Light spotLight;

    [Header("Setting")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationAngle;
    [SerializeField] private LayerMask playerLayer;

    public int gameOverScene;

    private Quaternion initialRotation;

    private bool detected;

    private void Start()
    {
        initialRotation = transform.rotation;
        detected = false;
    }

    private void Update()
    {
        CameraRotation();
        Detection();
    }

    void CameraRotation()
    {
        float currentAngle = Mathf.Sin(Time.time * (rotationSpeed / rotationAngle)) * rotationAngle;

        transform.rotation = (initialRotation * Quaternion.Euler(0, currentAngle, 0));
    }

    void Detection()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(spotLight.transform.position, spotLight.range, playerLayer);

        foreach (Collider hitCollider in detectedColliders)
        {
            if (hitCollider.CompareTag("Player") && !detected)
            {
                Vector3 directionToDetect = (hitCollider.transform.position - transform.position).normalized;
                float angleToDetect = Vector3.Angle(transform.forward, directionToDetect);
                
                if (angleToDetect < spotLight.spotAngle / 2f)
                {
                    Debug.Log("Detectado");
                    detected = true;
                    SceneManager.LoadScene(gameOverScene);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, spotLight.spotAngle, spotLight.range, 0f, 1f);
        Gizmos.matrix = Matrix4x4.identity;
    }
}