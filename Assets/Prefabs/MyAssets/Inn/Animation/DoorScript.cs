using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator animator;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isInCollider", true);
        source.PlayDelayed(0.6f);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isInCollider", false);
        source.PlayDelayed(0.6f);
    }
}
