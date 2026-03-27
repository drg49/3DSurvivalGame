using UnityEngine;

public class GoToSleep : Interactable
{
    [SerializeField] private Animator fadeAnim;
    public override void Interact()
    {
        fadeAnim.SetTrigger("GoToSleep");
        Destroy(gameObject);
    }
}
