using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneScript : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.GetComponent<Animator>().enabled = false;
        }
    }
}
