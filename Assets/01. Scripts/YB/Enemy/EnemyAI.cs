using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // ���� ��ǥ ����
    public Transform rocket;
    // ���� ����
    public float attackRange = 2f;
    // ���� ���̾�
    public LayerMask soldierLayer;
    // Ž�� �ݰ�
    public float detectionRadius = 10f;

    // NavMesh ������Ʈ
    private NavMeshAgent agent;
    // �ִϸ�����
    private Animator animator;
    // �̵� ��Ʈ�ѷ�
    private MovementController movementController;
    // ���� ��Ʈ�ѷ�
    private AttackController attackController;
    // ���� Ÿ���� ü��
    private Health currentTargetHealth;

    void Start()
    {
        // ������Ʈ �ʱ�ȭ
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        movementController = new MovementController(agent, animator, rocket);
        attackController = new AttackController(animator, attackRange);
        // ���� ��ǥ �������� �̵� ����
        movementController.GoToTarget();
    }

    void Update()
    {
        // ���� ����� ���縦 ã��
        Transform nearestSoldier = FindNearestSoldier();
        if (nearestSoldier != null)
        {
            // Ÿ�� ������ ü�� ��������
            currentTargetHealth = nearestSoldier.GetComponent<Health>();
            if (attackController.IsAttacking)
            {
                // ���� ���̸� ���� ó��
                attackController.HandleAttack(nearestSoldier, currentTargetHealth, movementController);
            }
            else
            {
                // �̵� ó��
                movementController.HandleMovement(nearestSoldier, attackController);
            }
        }
        else
        {
            if (attackController.IsAttacking)
            {
                // ���簡 ������ ������ ����
                attackController.HandleAttack(rocket, null, movementController);
            }
            else
            {
                // ���� ��ǥ �������� �̵�
                movementController.GoToTarget();
            }
        }
    }

    // ���� ����� ���縦 ã�� �޼ҵ�
    Transform FindNearestSoldier()
    {
        // Ž�� �ݰ� ���� ��� ���� ã��
        Collider[] soldiersInRange = Physics.OverlapSphere(transform.position, detectionRadius, soldierLayer);
        Transform nearestSoldier = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider soldier in soldiersInRange)
        {
            // �� ������� �Ÿ� ���
            float distance = Vector3.Distance(transform.position, soldier.transform.position);
            if (distance < minDistance)
            {
                // ���� ����� ���� ������Ʈ
                minDistance = distance;
                nearestSoldier = soldier.transform;
            }
        }

        return nearestSoldier;
    }

    // Gizmo�� �׷��� ���� ������ Ž�� �ݰ��� �ð������� ǥ��
    void OnDrawGizmos()
    {
        // Ž�� �ݰ��� ��������� ǥ��
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // ���� ������ ���������� ǥ��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}