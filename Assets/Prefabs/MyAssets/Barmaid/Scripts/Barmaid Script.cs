using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BarmaidScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TargetBar;
    public GameObject TargetKitchen;
    public GameObject TargetTable1;
    public GameObject TargetTable2;
    public GameObject TargetTable3;
    public GameObject TargetUpstairs;
    Vector3 currTarget = Vector3.zero;
    NavMeshAgent agent;
    Animator animator;
    int iterator = 0;
    bool agentAllowedToMove = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agentAllowedToMove)
        {

            switch (iterator)
            {
                case 0:
                    {
                        agent.SetDestination(TargetBar.transform.position);
                        currTarget = TargetBar.transform.position;
                        break;
                    }
                case 1:
                    {
                        agent.SetDestination(TargetKitchen.transform.position);
                        currTarget = TargetKitchen.transform.position;
                        break;
                    }
                case 2:
                    {
                        agent.SetDestination(TargetTable1.transform.position);
                        currTarget = TargetTable1.transform.position;
                        break;
                    }
                case 3:
                    {
                        agent.SetDestination(TargetTable2.transform.position);
                        currTarget = TargetTable2.transform.position;
                        break;
                    }
                case 4:
                    {
                        agent.SetDestination(TargetTable3.transform.position);
                        currTarget = TargetTable3.transform.position;
                        break;
                    }
                case 5:
                    {
                        agent.SetDestination(TargetUpstairs.transform.position);
                        currTarget = TargetUpstairs.transform.position;
                        break;
                    }
            }
            iterator += 1;
            iterator = iterator % 6;
            animator.SetBool("isMoving", true);
            agentAllowedToMove = false;
        }
        else
        {
            float distance = Vector3.Distance(transform.position, currTarget);
            if (distance < 2)
            {
                animator.SetBool("isMoving", false);
                agentAllowedToMove = true;
            }
        }
    }
}
