using UnityEngine;

public class SwordDoneSwinging : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // This method will be called by the animation event
    public void AnimationFinished()
    {
        // Set the boolean parameter to false after the animation is done
        animator.SetBool("swingSword", false);
    }
}
