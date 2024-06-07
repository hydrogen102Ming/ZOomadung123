using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform rocket;
    public float attackRange = 2f;
    public LayerMask soldierLayer;
    public float detectionRadius = 10f;

    private NavMeshAgent agent;
    private Animator animator;
    private MovementController movementController;
    private AttackController attackController;
    private Health currentTargetHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        movementController = new MovementController(agent, animator, rocket);
        attackController = new AttackController(animator, attackRange);
        movementController.GoToTarget();
    }

    void Update()
    {
        Transform nearestSoldier = FindNearestSoldier();
        if (nearestSoldier != null)
        {
            currentTargetHealth = nearestSoldier.GetComponent<Health>();
            if (attackController.IsAttacking)
            {
                attackController.HandleAttack(nearestSoldier, currentTargetHealth, movementController);
            }
            else
            {
                movementController.HandleMovement(nearestSoldier, attackController);
            }
        }
        else
        {
            if (attackController.IsAttacking)
            {
                attackController.HandleAttack(rocket, null, movementController);
            }
            else
            {
                movementController.GoToTarget();
            }
        }
    }

    Transform FindNearestSoldier()
    {
        Collider[] soldiersInRange = Physics.OverlapSphere(transform.position, detectionRadius, soldierLayer);
        Transform nearestSoldier = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider soldier in soldiersInRange)
        {
            float distance = Vector3.Distance(transform.position, soldier.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestSoldier = soldier.transform;
            }
        }

        return nearestSoldier;
    }
}
