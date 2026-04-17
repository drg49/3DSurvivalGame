using UnityEngine;
using System.Collections;

public class LevelFiveDebugManager : MonoBehaviour
{
   
    [SerializeField] private GameObject dialogueOne;
    [SerializeField] private GameObject dialogueOneCam;
    [SerializeField] private Animator fadeAnim;
   

    private void Start()
    {
        StartCoroutine(FastForward());
    }

    private IEnumerator FastForward()
    {
        // fade in
        fadeAnim.SetTrigger("FadeIntoCamp");

        // wait 5 seconds
        yield return new WaitForSeconds(5f);

        Destroy(dialogueOne);
        Destroy(dialogueOneCam);

        //// then next step
        fadeAnim.SetTrigger("SetUpTent");

        //// wait 5 seconds
        yield return new WaitForSeconds(5f);

        fadeAnim.SetTrigger("FadeToNight");

        // Temporarily speed it up
        fadeAnim.speed = 10f; // 3x faster
    }
}
