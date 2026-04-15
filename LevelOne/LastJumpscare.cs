using UnityEngine;

public class LastJumpscare : MonoBehaviour
{
    [SerializeField] private GameObject demon;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject jumpscareCamera;
    [SerializeField] private AudioSource jumpscareAudio;
    [SerializeField] private Animator fadeAnim;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (!other.CompareTag("Player")) return;

        hasTriggered = true;
        Destroy(player);
        jumpscareCamera.SetActive(true);
        demon.SetActive(true);
        jumpscareAudio.Play();
        fadeAnim.SetTrigger("FadeToCredits");
    }
}
