using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyChase : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    CharacterCombat combat;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent = animator.GetComponent<NavMeshAgent>();
       player = GameObject.FindGameObjectWithTag("Player").transform;
       agent.speed = 2f;
       combat = animator.GetComponent<CharacterCombat>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(player.position);
       CharacterStats targetStats = player.GetComponent<CharacterStats>();
       float distance = Vector3.Distance(player.position, animator.transform.position);
        if(distance > 15){
        animator.SetBool("isChasing", false);
        }
        if(distance < 2.5f){
         animator.SetBool("isAttacking", true);
        }
        Vector3 direction = (player.position - animator.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation,lookRotation,Time.deltaTime*5f);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(animator.transform.position);
    }

    

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
