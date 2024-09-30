using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("PlayAnimation");
        }
    }

}
