using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [Header("Movimentação")]
    public float moveSpeed;
    public float friction = 0.95f;
    public Rigidbody2D rb;

    [Header("Combate")]
    public float maxHealth;
    public Collider2D hitBox;
    public Collider2D damageBox;
    public float danoAtual;
}