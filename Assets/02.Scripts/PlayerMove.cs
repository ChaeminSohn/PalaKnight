using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Animator playerAnimator;
    private PlayerInput playerInput;
    private Rigidbody2D playerRigidbody;


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (playerInput.Move > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (playerInput.Move < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            playerAnimator.SetBool("1_Move", false);
            return;
        }
        Vector2 moveDistance = moveSpeed * playerInput.Move * Time.deltaTime * Vector2.right;

        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
        playerAnimator.SetBool("1_Move", true);

    }
}
