using UnityEngine;

public class RemoveIdleFreak : MonoBehaviour
{
    [SerializeField] private GameObject idleFreak;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Destroy(idleFreak);
        Destroy(gameObject);
    }
}
