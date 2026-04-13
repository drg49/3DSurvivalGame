using UnityEngine;

public class JesterJumpscare : MonoBehaviour
{
    [SerializeField] private GameObject jester;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        jester.SetActive(true);
        Destroy(gameObject);
    }
}
