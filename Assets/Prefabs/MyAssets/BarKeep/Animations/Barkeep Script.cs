using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkeepScript : MonoBehaviour
{
    public GameObject player;
    AudioSource audioSource;
    Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if ((!audioSource.isPlaying) && (distance <= 6))
        {
            audioSource.Play();
            animator.SetBool("isTalking", true);
        }
        else if(distance >= 10)
        {
            animator.SetBool("isTalking", false);
        }
    }
}
