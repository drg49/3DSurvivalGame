using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    [SerializeField] private Animator fadeAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        fadeAnim.SetTrigger("FadeOutEndGame");
        Destroy(gameObject);
    }
}
