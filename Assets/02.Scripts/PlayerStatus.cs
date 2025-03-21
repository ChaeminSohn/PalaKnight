using UnityEngine;

public class PlayerStatus : LivingEntity
{
    private void Awake()
    {

    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
    }

    public override void RecoverHP(float heal)
    {
        base.RecoverHP(heal);
    }

    public override void Die()
    {
        base.Die();
    }
}
