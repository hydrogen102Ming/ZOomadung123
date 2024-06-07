using UnityEngine;
using UnityEngine.AI;

public class MovementController
{
    private NavMeshAgent agent;
    private Animator animator;
    private Transform target;

    public MovementController(NavMeshAgent agent, Animator animator, Transform target)
    {
        this.agent = agent;
        this.animator = animator;
        this.target = target;
    }

    public void GoToTarget()
    {
        agent.SetDestination(target.position);
        animator.SetTrigger("Walk");
        animator.ResetTrigger("Attack");
    }

    public void HandleMovement(Transform soldier, AttackController attackController)
    {
        float distanceToSoldier = Vector3.Distance(agent.transform.position, soldier.position);

        if (distanceToSoldier <= attackController.AttackRange && !attackController.SoldierDead)
        {
            attackController.StartAttack();
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(soldier.position);
            animator.SetTrigger("Walk");
            animator.ResetTrigger("Attack");
        }
    }
}
