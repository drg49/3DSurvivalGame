using UnityEngine;

public class TellDavidAboutDemon : NPCDialogue
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private GameObject flashlightLight;

    private void OnEnable()
    {
        dialogueManager.OnDialogueFinished += DialogueEnded;
    }

    private void OnDisable()
    {
        dialogueManager.OnDialogueFinished -= DialogueEnded;
    }

    public override void Interact()
    {
        base.Interact();
        // Clean up
        Destroy(flashlight);
        Destroy(flashlightLight);
    }

    private void DialogueEnded()
    {
        Destroy(cameraToActivate.gameObject);
        player.SetActive(true);
        Destroy(gameObject);
    }
}
