using System;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitCtrl : LivingEntity
{
    public enum State
    {
        Ready,
        Attacking
    }

    public State state { get; private set; }
    public UnitData unitData;
    private Animator unitAnimator;

    public LayerMask enemyLayer;
    private Rigidbody2D unitRigidbody;

    public Slider healthBar;

    private Coroutine attackCoroutine;
    private void Awake()
    {
        unitAnimator = GetComponent<Animator>();
        unitRigidbody = GetComponent<Rigidbody2D>();

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        fullHP = unitData.hp;
        HP = fullHP;
        healthBar.maxValue = fullHP;
        healthBar.value = HP;
        state = State.Ready;
    }

    private void Update()
    {
        if (IsDead)
        {
            return;
        }

        var EnemyObj = Physics2D.OverlapBox
        (transform.position, new Vector2(1, unitData.range), -90, enemyLayer);
        if (EnemyObj != null)
        {
            if (state != State.Attacking)
            {
                attackCoroutine = StartCoroutine(AttackRoutine(EnemyObj.GetComponent<LivingEntity>()));
            }
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
        if (!IsDead)
        {
            base.OnDamage(damage);
            healthBar.value = HP;
            // unitAnimator.SetTrigger("3_Damaged");
        }
    }

    private IEnumerator AttackRoutine(LivingEntity target)
    {
        state = State.Attacking;
        unitAnimator.SetBool("1_Move", false);
        unitAnimator.SetTrigger("2_Attack");


        yield return new WaitForSeconds(unitData.attackSpeed);
        target.OnDamage(unitData.damage);

        state = State.Ready;
    }

    public override void RecoverHP(float heal)
    {
        base.RecoverHP(heal);
    }
    public override void Die()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        base.Die();
        unitAnimator.SetTrigger("4_Death");
        Destroy(gameObject, 0.55f);
    }
}
