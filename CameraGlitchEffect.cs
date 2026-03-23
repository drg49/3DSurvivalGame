using UnityEngine;

public class CameraGlitchEffect : MonoBehaviour
{
    [Header("Glitch Settings")]
    [SerializeField] private float duration = 1.5f;
    [SerializeField] private float positionIntensity = 0.08f;
    [SerializeField] private float rotationIntensity = 2f;
    [SerializeField] private float fovIntensity = 10f;
    [SerializeField] private float snapChance = 0.15f;

    private float timer;

    private Vector3 originalPos;
    private Quaternion originalRot;
    private float originalFOV;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        originalPos = transform.localPosition;
        originalRot = transform.localRotation;

        if (cam != null)
            originalFOV = cam.fieldOfView;
    }

    private void OnEnable()
    {
        // Reset timer every time it's enabled
        timer = duration;
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;

            // --- POSITION GLITCH ---
            if (Random.value < snapChance)
            {
                // Hard snap glitch
                transform.localPosition = originalPos + Random.insideUnitSphere * positionIntensity * 3f;
            }
            else
            {
                // Subtle jitter
                transform.localPosition = originalPos + Random.insideUnitSphere * positionIntensity;
            }

            // --- ROTATION GLITCH ---
            float rotX = Random.Range(-rotationIntensity, rotationIntensity);
            float rotY = Random.Range(-rotationIntensity, rotationIntensity);
            transform.localRotation = originalRot * Quaternion.Euler(rotX, rotY, 0f);

            // --- FOV GLITCH ---
            if (cam != null)
            {
                cam.fieldOfView = originalFOV + Random.Range(-fovIntensity, fovIntensity);
            }
        }
        else
        {
            ResetCamera();
            enabled = false; // Auto-disable after effect
        }
    }

    private void ResetCamera()
    {
        transform.localPosition = originalPos;
        transform.localRotation = originalRot;

        if (cam != null)
            cam.fieldOfView = originalFOV;
    }
}