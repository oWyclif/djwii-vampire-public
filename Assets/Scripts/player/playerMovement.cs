using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    //Instanciando o script de Atributos do player (PlayerAttributes) e o nomeando (Attributes)
    public PlayerAttributes playerAtr;

    // Declarando variáveis que serão puxadas dos atributos
    private Rigidbody2D _rb;
    private float _moveSpeed;
    private float _friction;

    //Outras variáveis, que não estão nos atributos
    bool moving = false;
    Vector2 movDirection;

    public void Awake()
    {
        _moveSpeed = playerAtr.moveSpeed;
        _friction = playerAtr.friction;
        _rb = playerAtr.rb;
    }

    void FixedUpdate()
    {
        if(moving){

            _rb.linearVelocity = movDirection * _moveSpeed;

        }else{

            _rb.linearVelocity *= _friction;

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
