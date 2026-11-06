using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [Header("Movimentação")]
    public float moveSpeed;
    public float friction = 0.95f;
    public Rigidbody2D rb;
    public Transform tr;

    [Header("Combate")]
    public float maxHealth;
    public float currentHealth;
    public Collider2D hitBox;
    public Collider2D damageBox;
    public float danoAtual;
    public float atkArea;

    [Header("Progressão e pontuação")]
    public int nivel;
    public int killCount;
}