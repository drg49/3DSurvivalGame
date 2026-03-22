using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MonsterChase : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private float velocityY;
    private bool isChasing = true;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Reset()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    private void Update()
    {
        if (!isChasing || player == null)
            return;

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        // Flatten direction (no vertical movement)
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        direction.Normalize();

        Vector3 move = direction * moveSpeed;

        // Face player
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        ApplyGravity(move);
    }

    private void ApplyGravity(Vector3 horizontalMove)
    {
        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = -2f;
        }

        velocityY += gravity * Time.deltaTime;

        Vector3 finalMove = horizontalMove;
        finalMove.y = velocityY;

        controller.Move(finalMove * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isChasing)
            return;

        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("Monster caught the player!");
            isChasing = false;

            // Optional: fully stop movement
            velocityY = 0f;
        }
    }
}