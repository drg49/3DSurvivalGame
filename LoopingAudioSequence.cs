using System.Collections;
using UnityEngine;

public class LoopingAudioSequence : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float delayBetweenClips = 2f;

    private Coroutine loopCoroutine;

    private void OnEnable()
    {
        if (audioSource == null)
        {
            Debug.LogWarning($"{nameof(LoopingAudioSequence)}: AudioSource is null on {gameObject.name}");
            return;
        }

        if (clips == null || clips.Length == 0)
        {
            Debug.LogWarning($"{nameof(LoopingAudioSequence)}: No clips assigned on {gameObject.name}");
            return;
        }

        loopCoroutine = StartCoroutine(PlayLoop());
    }

    private void OnDisable()
    {
        if (loopCoroutine != null)
        {
            StopCoroutine(loopCoroutine);
        }
    }

    private IEnumerator PlayLoop()
    {
        int index = 0;

        while (true)
        {
            // ?? Runtime safety check (VERY important)
            if (audioSource == null)
            {
                yield break;
            }

            AudioClip clip = clips[index];

            if (clip == null)
            {
                Debug.LogWarning($"Clip at index {index} is null.");
                index = (index + 1) % clips.Length;
                continue;
            }

            audioSource.clip = clip;
            audioSource.Play();

            yield return new WaitForSeconds(clip.length);
            yield return new WaitForSeconds(delayBetweenClips);

            index = (index + 1) % clips.Length;
        }
    }
}