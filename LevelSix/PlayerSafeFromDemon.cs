using UnityEngine;

public class PlayerSafeFromDemon : MonoBehaviour
{
    [SerializeField] private GameObject demon;
    [SerializeField] private GameObject demonAudio;
    [SerializeField] private AudioSource chaseMusic;
    [SerializeField] private GameObject fpsDemon;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private CameraGlitchEffect cameraGlitch;
    [SerializeField] private GameObject playerSafeObjective;

    private void OnTriggerEnter()
    {
        chaseMusic.Stop();
        Destroy(demon);
        Destroy(fpsDemon);
        Destroy(demonAudio);
        Destroy(cameraGlitch);
        playerSafeObjective.SetActive(true);
        Destroy(gameObject);
    }
}
