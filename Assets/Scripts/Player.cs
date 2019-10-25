using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamagable
{
    public static UnityAction OnPlayerDeath;

    [SerializeField]
    private int hp = 100;
    public int HP
    {
        get => hp;
        set => hp = value;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Player takes {damage} damage");
        HP -= damage;
        if (HP <= 0)
            Die();
    }

    private void Die()
    {
        OnPlayerDeath?.Invoke();
    }
}
