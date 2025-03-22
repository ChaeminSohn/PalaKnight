using UnityEngine;
using UnityEngine.UI;
public class EnemyCtrl : LivingEntity
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

    }

    protected override void OnEnable()
    {
        base.OnEnable();

        fullHP = unitData.hp;
        HP = fullHP;
        healthBar.maxValue = fullHP;
        healthBar.value = HP;
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
        Vector2 moveDistance = speed * Time.deltaTime * Vector2.left;

        unitRigidbody.MovePosition(unitRigidbody.position + moveDistance);
    }
    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        healthBar.value = HP;
        unitAnimator.SetTrigger("3_Damaged");
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
