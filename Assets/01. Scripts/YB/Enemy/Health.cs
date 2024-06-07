using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth { get; private set; } = 100f;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return; // 이미 죽은 상태면 더 이상 데미지를 받지 않음

        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        // 죽음 처리 로직 추가
        // 예: 게임 오브젝트 비활성화, 점수 증가, 기타 이벤트 트리거 등
    }
}
