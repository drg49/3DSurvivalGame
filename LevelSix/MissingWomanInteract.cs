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
    [SerializeField] private AudioSource missingWomanAudio;
    [SerializeField] private AudioSource jumpscareAudioTwo;

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

        yield return new WaitForSeconds(3f);

        // Restore player
        Destroy(cameraToActivate.gameObject);
        player.SetActive(true);
        Destroy(missingWomanLight);

        Destroy(gameObject);
    }
}