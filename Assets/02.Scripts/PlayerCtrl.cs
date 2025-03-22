using UnityEngine;

public class PlayerCtrl : LivingEntity
{
    private Animator playerAnimator;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
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
        playerAnimator.SetTrigger("4_Death");
    }
}
