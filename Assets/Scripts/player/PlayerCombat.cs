using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour, IDamageable
{
    public PlayerAttributes playerAtr;

    public void Awake()
    {
        playerAtr.currentHealth = playerAtr.maxHealth;
    }

    public void FixedUpdate()
    {
        Attack();
    }

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable obj = collision.GetComponent<IDamageable>();
        
        obj?.TakeDamage(playerAtr.danoAtual);
    }
    */

    public void Attack()
    {
        Debug.Log("Attack called");

        Collider2D[] inimigosAtingidos = Physics2D.OverlapCircleAll(playerAtr.tr.position, 5f);
 
        foreach(Collider2D inimigoColisor in inimigosAtingidos)
        {
            if (inimigoColisor.gameObject.name != "player")
            {
                IDamageable obj = inimigoColisor.GetComponent<IDamageable>();
                obj?.TakeDamage(playerAtr.danoAtual);

            }
        }
    }

    public void TakeDamage(float DamageAmount)
    {
        playerAtr.currentHealth -= DamageAmount;

        Debug.Log("Player sofreu dano");

        if (playerAtr.currentHealth <= 0 )
        {
            Debug.Log("Player morto.");
        
            SceneManager.LoadScene("scene_level");
        }
    }
}
