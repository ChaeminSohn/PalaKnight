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

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
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
            playerAnimator.SetTrigger("2_Attack");
        }
    }

    public void SwordAttack()
    {
        Debug.Log("Sex");
        weaponObj.sprite = sword;
        playerAnimator.SetFloat("Weapon", 0);
    }

    public void WandAttack()
    {
        Debug.Log("Bozi");
        weaponObj.sprite = wand;
        playerAnimator.SetFloat("Weapon", 1);
    }

    public void BowAttack()
    {
        Debug.Log("Zazi");
        weaponObj.sprite = bow;
        playerAnimator.SetFloat("Weapon", 2);
    }
}
