using System.Collections;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class enemyCombat : MonoBehaviour, IDamageable
{
    public simplesAttributes simplesAtr;

    private SpriteRenderer spriteProps;
    public TextMeshPro inVidaText;

    public void Awake()
    {
        spriteProps = this.gameObject.GetComponent<SpriteRenderer>();

        inVidaText = this.gameObject.GetComponentInChildren<TextMeshPro>();

        //DrawMostradorVida();
    }
    public void TakeDamage(float DamageAmount)
    {
        simplesAtr.currentHealth -= DamageAmount;

        Debug.Log("Inimigo levou dano. Foi de " + DamageAmount + "Sua vida agora é de " + simplesAtr.currentHealth);

        if (simplesAtr.currentHealth <= 0 )
        {
            Debug.Log("Inimigo morto.");
        
            Destroy(this.gameObject);
        }

        //tring healthString = ToString(simplesAtr.currentHealth);

        inVidaText.SetText(simplesAtr.currentHealth.ToString());
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.name == "player")
            {
                IDamageable obj = collision.gameObject.GetComponent<IDamageable>();
                obj?.TakeDamage(simplesAtr.dano);
            }
    }

}