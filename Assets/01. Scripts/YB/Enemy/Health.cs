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
        if (isDead) return; // �̹� ���� ���¸� �� �̻� �������� ���� ����

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
        // ���� ó�� ���� �߰�
        // ��: ���� ������Ʈ ��Ȱ��ȭ, ���� ����, ��Ÿ �̺�Ʈ Ʈ���� ��
    }
}
