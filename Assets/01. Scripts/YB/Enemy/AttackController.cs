using UnityEngine;

public class AttackController
{
    private Animator animator;
    public float AttackRange { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool SoldierDead { get; private set; }

    public AttackController(Animator animator, float attackRange)
    {
        this.animator = animator;
        this.AttackRange = attackRange;
        this.IsAttacking = false;
        this.SoldierDead = false;
    }

    public void StartAttack()
    {
        IsAttacking = true;
        animator.SetTrigger("Attack");
        animator.ResetTrigger("Walk");
    }

    public void HandleAttack(Transform target, Health targetHealth, MovementController movementController)
    {
        if (targetHealth != null && Vector3.Distance(animator.transform.position, target.position) <= AttackRange && !SoldierDead)
        {
            // 공격 로직 추가 (예: targetHealth.TakeDamage(데미지))
            if (targetHealth.CurrentHealth <= 0)
            {
                SoldierDead = true;
                IsAttacking = false;
                animator.ResetTrigger("Attack");
                movementController.GoToTarget();
            }
        }
        else if (SoldierDead || targetHealth == null)
        {
            IsAttacking = false;
            movementController.GoToTarget();
        }
    }
}