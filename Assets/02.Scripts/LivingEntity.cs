using System;
using UnityEngine;

//생명체로서 동작할 게임 오브젝트를 위한 뼈대
public class LivingEntity : MonoBehaviour
{
    public float fullHP = 100f;
    public float HP { get; protected set; }
    public bool IsDead { get; protected set; }
    public event Action OnDeath;

    protected virtual void OnEnable()
    {
        IsDead = false;
        HP = fullHP;
    }

    public virtual void OnDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0 && !IsDead)
        {
            Die();
        }
    }

    public virtual void RecoverHP(float heal)
    {
        if (IsDead)
        {
            return;
        }
        HP += heal;
        if (HP >= fullHP)
        {
            HP = fullHP;
        }
    }
    public virtual void Die()
    {
        if (OnDeath != null)
        {
            OnDeath();
        }
        IsDead = true;
    }
}
