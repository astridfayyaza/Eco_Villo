using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private PlayerTools tools;

    void Start()
    {
        animator = GetComponent<Animator>();

        tools = GetComponent<PlayerTools>();
    }

    void Update()
    {
        animator.SetBool(
            "HasVacuum",
            tools.hasVacuum
        );
    }
}