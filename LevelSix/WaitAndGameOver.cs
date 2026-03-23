using System.Collections;
using UnityEngine;

public class WaitAndGameOver : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float delay = 5f;

    [Header("References")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private AudioSource grudeAudio;
    [SerializeField] private AudioSource chaseMusic;
    [SerializeField] private GameObject demon;
    [SerializeField] private GameObject demonAudio;
    [SerializeField] private MonsterChase monsterChase;
    [SerializeField] private Transform demonOriginalTarget;
    [SerializeField] private GameObject player;
    [SerializeField] private FirstPersonController playerFPS;
    [SerializeField] private Transform playerRunAwayTarget;


    private void OnEnable()
    {
        StartCoroutine(WaitThenGameOver());
    }

    private IEnumerator WaitThenGameOver()
    {
        yield return new WaitForSeconds(delay);
        gameOverPanel.SetActive(true);

        // Pause player controls while we move it back to original position
        playerFPS.enabled = false;

        // Show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        grudeAudio.Stop();
        chaseMusic.Stop();

        // Turn off MonsterChase script
        monsterChase.enabled = false;

        // Set demon and demon_audio to inactive
        demon.SetActive(false);
        demonAudio.SetActive(false);

        // Reset demon position
        demon.transform.SetPositionAndRotation(
           demonOriginalTarget.position,
           demonOriginalTarget.rotation
        );

        // Move player back to chase target
        player.transform.SetPositionAndRotation(
           playerRunAwayTarget.position,
           playerRunAwayTarget.rotation
        );

        // Must be called last!
        // Hides the FPS demon (which this script is attached to)
        gameObject.SetActive(false);
    }
}
