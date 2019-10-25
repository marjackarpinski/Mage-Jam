using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int hp = 10;
    public int HP
    {
        get => hp;
        set => hp = value;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Enemy takes {damage} damage");
        HP -= damage;
        if (HP <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
