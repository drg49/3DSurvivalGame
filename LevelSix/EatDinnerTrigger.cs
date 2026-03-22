using UnityEngine;

public class EatDinnerTrigger : MonoBehaviour
{
    [SerializeField] private Animator fadeAnim;
    [SerializeField] private GameObject huntingArea;
    [SerializeField] private GameObject rabbitManager;
    [SerializeField] private GameObject rabbitText;
    [SerializeField] private AudioSource davidAudio;


    private void OnTriggerEnter()
    {
        fadeAnim.SetTrigger("FadeInOutDinner");
        // We don't want to hear david's footsteps during this event
        davidAudio.mute = true;
        Destroy(huntingArea);
        Destroy(rabbitManager);
        Destroy(rabbitText);
        Destroy(gameObject);
    }
}
