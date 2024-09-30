using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : MonoBehaviour
{
    private Animator animator; //Will get the Animator component and name it animator
    bool isRagdoll = false; //A boolean to tell the computer if the isRagdoll function is active or not

    //Will determine what happens when the isRagdoll function is active or not
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

    void Start()
    {
        animator = GetComponent<Animator>(); //Will get the Animator component from the player
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
