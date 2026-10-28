using UnityEngine;
using UnityEngine.InputSystem;


public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Movimentação")]
    public float moveSpeed;

    bool moving = false;

    Vector2 movDirection;

    public float friction = 0.95f;

    void FixedUpdate()
    {
        if(moving){

            rb.linearVelocity = movDirection * moveSpeed;

        }else{

            rb.linearVelocity *= friction;

        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moving = true;

        movDirection = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);

        if(context.canceled)
        {
            moving = false;
        }
    }
}
