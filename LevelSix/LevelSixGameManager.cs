using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelSixGameManager : MonoBehaviour
{
    private PlayerInputActions inputActions;

    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI interactionText;

    [Header("Pause Reference")]
    [SerializeField] private PauseMenuController pauseMenu;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("Retry References")]
    [SerializeField] private GameObject demon;
    [SerializeField] private GameObject demonAudio;
    [SerializeField] private AudioSource chaseMusic;
    [SerializeField] private GameObject runAwayObjective;
    [SerializeField] private MonsterChase monsterChase;
    [SerializeField] private Animator demonAnim;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnInteract;
        inputActions.Player.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (pauseMenu != null && pauseMenu.IsPaused)
            return;

        // Clear interaction text
        if (interactionText != null)
            interactionText.text = "";
    }

    // Call this from your Retry button
    public void OnRetryClicked()
    {
        StartCoroutine(RetryRoutine());
    }

    private IEnumerator RetryRoutine()
    {
        if (gameOverPanel != null)
        {
            demon.SetActive(true);
            gameOverPanel.SetActive(false);

            // Hide and lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            demonAudio.SetActive(true);
            runAwayObjective.SetActive(true);

            // Start chase after 1.5 seconds
            yield return new WaitForSeconds(1.5f);
            monsterChase.enabled = true;
            monsterChase.StartChasing();
            demonAnim.SetTrigger("Chase");
            chaseMusic.Play();
        }
    }
}