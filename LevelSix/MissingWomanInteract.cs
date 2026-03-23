using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissingWomanInteract : Interactable
{
    [Header("Player")]
    [SerializeField] private GameObject player;

    [Header("Dialogue")]
    [SerializeField] private InkDialogueManager dialogueManager;
    [SerializeField] private TextAsset inkJSON;

    [Header("Camera")]
    [SerializeField] private Camera cameraToActivate;

    [Header("Scene References")]
    [SerializeField] private Image reticleImage;
    [SerializeField] private GameObject missingWoman;
    [SerializeField] private GameObject demon;
    [SerializeField] private GameObject missingWomanLight;
    [SerializeField] private GameObject missingWomanAudio;
    [SerializeField] private AudioSource jumpscareAudioTwo;
    [SerializeField] private Transform playerRunAwayTarget;
    [SerializeField] private GameObject runAwayObjective;
    [SerializeField] private MonsterChase monsterChase;
    [SerializeField] private Animator monsterAnim;
    [SerializeField] private AudioSource chasePulseSong;
    [SerializeField] private GameObject femaleFreakAudio;

    public override void Interact()
    {
        base.Interact();

        // Disable player
        player.SetActive(false);

        // Switch camera
        cameraToActivate.gameObject.SetActive(true);

        missingWomanLight.SetActive(true);

        Destroy(missingWomanAudio);

        // Hide reticle
        reticleImage.enabled = false;

        // Start dialogue
        dialogueManager.OnDialogueFinished += DialogueEnded;
        dialogueManager.StartStory(inkJSON);
    }

    private void DialogueEnded()
    {
        dialogueManager.OnDialogueFinished -= DialogueEnded;
        StartCoroutine(JumpscareSequence());
    }

    private IEnumerator JumpscareSequence()
    {
        yield return new WaitForSeconds(1f);

        Destroy(missingWoman);
        demon.SetActive(true);
        jumpscareAudioTwo.Play();

        yield return new WaitForSeconds(1f);

        player.transform.SetPositionAndRotation(
            playerRunAwayTarget.position,
            playerRunAwayTarget.rotation
        );

        // Restore player
        Destroy(cameraToActivate.gameObject);
        player.SetActive(true);
        Destroy(missingWomanLight);

        // Show reticle again
        reticleImage.enabled = true;

        runAwayObjective.SetActive(true);
        femaleFreakAudio.SetActive(true);

        // Start chase after 2 seconds
        yield return new WaitForSeconds(2f);

        monsterChase.enabled = true;
        monsterAnim.SetTrigger("Chase");
        chasePulseSong.Play();

        Destroy(gameObject);
    }
}