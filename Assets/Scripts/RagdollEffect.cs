using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : MonoBehaviour
{
    private Animator animator;
    bool isRagdoll = false;

    public void RagdollOn()
    {
        if(isRagdoll == false)
        {
            animator.enabled = true;
            isRagdoll = true;
        }
        else if(isRagdoll == true)
        {
            animator.enabled = false;
            isRagdoll = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //On E turn on the ragdoll
        if(Input.GetKeyDown(KeyCode.E))
        {
            RagdollOn();
        }
    }
}
