using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // 로켓 목표 지점
    public Transform rocket;
    // 공격 범위
    public float attackRange = 2f;
    // 병사 레이어
    public LayerMask soldierLayer;
    // 탐지 반경
    public float detectionRadius = 10f;

    // NavMesh 에이전트
    private NavMeshAgent agent;
    // 애니메이터
    private Animator animator;
    // 이동 컨트롤러
    private MovementController movementController;
    // 공격 컨트롤러
    private AttackController attackController;
    // 현재 타겟의 체력
    private Health currentTargetHealth;

    void Start()
    {
        // 컴포넌트 초기화
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        movementController = new MovementController(agent, animator, rocket);
        attackController = new AttackController(animator, attackRange);
        // 로켓 목표 지점으로 이동 시작
        movementController.GoToTarget();
    }

    void Update()
    {
        // 가장 가까운 병사를 찾음
        Transform nearestSoldier = FindNearestSoldier();
        if (nearestSoldier != null)
        {
            // 타겟 병사의 체력 가져오기
            currentTargetHealth = nearestSoldier.GetComponent<Health>();
            if (attackController.IsAttacking)
            {
                // 공격 중이면 공격 처리
                attackController.HandleAttack(nearestSoldier, currentTargetHealth, movementController);
            }
            else
            {
                // 이동 처리
                movementController.HandleMovement(nearestSoldier, attackController);
            }
        }
        else
        {
            if (attackController.IsAttacking)
            {
                // 병사가 없으면 로켓을 공격
                attackController.HandleAttack(rocket, null, movementController);
            }
            else
            {
                // 로켓 목표 지점으로 이동
                movementController.GoToTarget();
            }
        }
    }

    // 가장 가까운 병사를 찾는 메소드
    Transform FindNearestSoldier()
    {
        // 탐지 반경 내의 모든 병사 찾기
        Collider[] soldiersInRange = Physics.OverlapSphere(transform.position, detectionRadius, soldierLayer);
        Transform nearestSoldier = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider soldier in soldiersInRange)
        {
            // 각 병사와의 거리 계산
            float distance = Vector3.Distance(transform.position, soldier.transform.position);
            if (distance < minDistance)
            {
                // 가장 가까운 병사 업데이트
                minDistance = distance;
                nearestSoldier = soldier.transform;
            }
        }

        return nearestSoldier;
    }

    // Gizmo를 그려서 공격 범위와 탐지 반경을 시각적으로 표시
    void OnDrawGizmos()
    {
        // 탐지 반경을 노란색으로 표시
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // 공격 범위를 빨간색으로 표시
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}