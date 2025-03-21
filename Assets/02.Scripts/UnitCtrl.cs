using System;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitCtrl : LivingEntity
{
    public UnitData unitData;
    private Animator unitAnimator;

    public LayerMask enemyLayer;
    private Rigidbody2D unitRigidbody;

    public Slider healthBar;

    private void Awake()
    {
        unitAnimator = GetComponent<Animator>();
        unitRigidbody = GetComponent<Rigidbody2D>();

        fullHP = unitData.hp;
        HP = fullHP;
        healthBar.maxValue = fullHP;
        healthBar.value = HP;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    private void Update()
    {
        var EnemyObj = Physics2D.OverlapBox
        (transform.position, new Vector2(1, unitData.range), -90, enemyLayer);
        if (EnemyObj != null)
        {
            LivingEntity target = EnemyObj.GetComponent<LivingEntity>();
            unitAnimator.SetBool("1_Move", false);
            unitAnimator.SetTrigger("2_Attack");
            target.OnDamage(unitData.damage);
        }
        else
        {
            Move(unitData.speed);
            unitAnimator.SetBool("1_Move", true);
        }
    }
    public virtual void Move(float speed)
    {
        Vector2 moveDistance = speed * Time.deltaTime * Vector2.right;

        unitRigidbody.MovePosition(unitRigidbody.position + moveDistance);
    }
    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        healthBar.value = HP;
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
