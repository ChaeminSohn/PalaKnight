using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Horizontal";
    public string attackButtonSword = "AttackSword";
    public string attackButtonWand = "AttackWand";
    public string attackButtonBow = "AttackBow";

    public float Move { get; private set; }

    public float Attack { get; private set; }

    private void Awake()
    {
        Move = 0;
        Attack = -1;
    }

    private void Update()
    {
        Move = Input.GetAxis(moveAxisName);

        if (Input.GetButtonDown(attackButtonSword))
        {
            Attack = 0;
        }
        else if (Input.GetButtonDown(attackButtonWand))
        {
            Attack = 1;
        }
        else if (Input.GetButtonDown(attackButtonBow))
        {
            Attack = 2;
        }
        else
            Attack = -1;

    }

}
