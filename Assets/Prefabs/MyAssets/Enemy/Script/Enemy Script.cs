using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    NavMeshAgent agent;
    PlayerScript playerScript;
    AudioSource AudioSource;
    bool Manul = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
        agent = GetComponent<NavMeshAgent>();
        playerScript = player.GetComponent<PlayerScript>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance <= 30 && distance >= 4)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
            animator.SetInteger("State", 1);
            animator.SetBool("Attacking", true);
        }
        else if(distance <= 4 && distance >= 1)
        {
            agent.isStopped = true;
            animator.SetInteger("State", 2);
            if (animator.GetBool("Attacking"))
            {
                playerScript.getHit();
                if(!AudioSource.isPlaying)
                    AudioSource.Play();
                animator.SetBool("Attacking", false);
                StartCoroutine(ChangeBool());
            }
        }
    }

    IEnumerator ChangeBool()
    {
        Manul = true;
        yield return new WaitForSeconds(3);
        if (Manul)
        {
            animator.SetBool("Attacking", true);
        }
        Manul = false;
    }
}
