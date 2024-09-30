using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneScript : MonoBehaviour
{
    //Will find a listed GameObject called Player
    [SerializeField] GameObject Player;

    //Will detect when the player enters the box collider
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.GetComponent<Animator>().enabled = false; //Will turn of the Animator component on the Player
        }
    }
}
