using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterChase : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject fpsDemon;
    [SerializeField] private CameraGlitchEffect cameraGlitchEffect;
    [SerializeField] private AudioSource grudgeSound;

    [Header("Settings")]
    [SerializeField] private float stopDistance = 1.5f;

    private NavMeshAgent agent;
    private bool isChasing = true;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        // Ensure agent settings
        agent.updatePosition = true;
        agent.updateRotation = true;
        agent.stoppingDistance = stopDistance;

        // Snap monster to NavMesh if off
        if (!agent.isOnNavMesh)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, 5f, NavMesh.AllAreas))
            {
                agent.Warp(hit.position);
            }
        }

        // Auto-find player if null
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }
    }

    private void Update()
    {
        if (!isChasing || player == null) return;

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        // Snap player position to NavMesh
        NavMeshHit hit;
        if (!NavMesh.SamplePosition(player.position, out hit, 2f, NavMesh.AllAreas))
            return;

        agent.SetDestination(hit.position);

        float distance = Vector3.Distance(transform.position, hit.position);
        if (distance <= stopDistance)
        {
            agent.isStopped = true;
            isChasing = false;
            Debug.Log("Monster caught the player!"); // Only log when caught
            cameraGlitchEffect.enabled = true;
            fpsDemon.SetActive(true);
            grudgeSound.Play();
            Destroy(gameObject);
        }
        else
        {
            if (agent.isStopped) agent.isStopped = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the stop distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}