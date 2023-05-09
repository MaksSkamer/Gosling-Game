using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : StateMachineBehaviour
{
    private Transform transform;
    private Transform target;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        Shake();
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
    void Shake()
    {
        ShakeUp();
        ShakeDown();      
    }
    void ShakeUp()
    {
        transform.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 0.27f, transform.position.z);
    }
    void ShakeDown()
    {
        transform.transform.position = new Vector3(target.transform.position.x, target.transform.position.y - 0.30f, transform.position.z);
    }
}
