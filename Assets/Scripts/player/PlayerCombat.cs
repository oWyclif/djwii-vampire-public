using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerAttributes playerAtr;

    public void Awake()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger. Objeto colidido foi o " + collision.gameObject);

        IDamageable obj = collision.GetComponent<IDamageable>();
        
        obj?.TakeDamage(playerAtr.danoAtual);
    }
}
