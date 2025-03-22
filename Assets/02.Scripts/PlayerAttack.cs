using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float fullEnergy = 100f;
    public float Energy { get; private set; }
    private PlayerInput playerInput;
    private Animator playerAnimator;



    public SpriteRenderer weaponObj;
    public Sprite sword;
    public Sprite wand;
    public Sprite bow;

    public WeaponData swordData;
    public WeaponData wandData;
    public WeaponData bowData;

    public LayerMask enemyLayer;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        Energy = fullEnergy;
    }

    private void Update()
    {
        /*
        if (playerInput.Attack != -1)
        {
            if (playerInput.Attack == 0 && Energy >= swordData.energyCost)
            {
                SwordAttack();
            }
            else if (playerInput.Attack == 1 && Energy >= wandData.energyCost)
            {
                WandAttack();
            }
            else if (playerInput.Attack == 2 && Energy >= bowData.energyCost)
            {
                BowAttack();
            }
        }
        */
    }

    public void SwordAttack()
    {

        var EnemyObj = Physics2D.OverlapBox
            ((Vector2)transform.position + (Vector2.right * swordData.range * transform.localScale.x) / 2,
             new Vector2(swordData.range, 2), 0, enemyLayer);

        if (EnemyObj != null)
        {
            LivingEntity target = EnemyObj.GetComponent<LivingEntity>();
            target.OnDamage(swordData.damage);
        }
        weaponObj.sprite = sword;
        Energy -= swordData.energyCost;
        playerAnimator.SetFloat("Weapon", 0);
        playerAnimator.SetTrigger("2_Attack");
    }

    public void WandAttack()
    {
        var EnemyObj = Physics2D.OverlapBox
           ((Vector2)transform.position + (Vector2.right * wandData.range * transform.localScale.x) / 2,
           new Vector2(wandData.range, 2), 0, enemyLayer);

        if (EnemyObj != null)
        {
            LivingEntity target = EnemyObj.GetComponent<LivingEntity>();
            target.OnDamage(wandData.damage);
        }
        weaponObj.sprite = wand;
        Energy -= wandData.energyCost;
        playerAnimator.SetFloat("Weapon", 1);
        playerAnimator.SetTrigger("2_Attack");
    }

    public void BowAttack()
    {
        var EnemyObj = Physics2D.OverlapBox
                ((Vector2)transform.position + (Vector2.right * bowData.range * transform.localScale.x) / 2,
                new Vector2(bowData.range, 2), 0, enemyLayer);

        if (EnemyObj != null)
        {
            LivingEntity target = EnemyObj.GetComponent<LivingEntity>();
            target.OnDamage(bowData.damage);
        }
        weaponObj.sprite = bow;
        Energy -= bowData.energyCost;
        playerAnimator.SetFloat("Weapon", 2);
        playerAnimator.SetTrigger("2_Attack");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position +
        (Vector2.right * wandData.range) / 2, new Vector2(wandData.range, 1));
    }
}
