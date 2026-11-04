using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class enemyCombat : MonoBehaviour, IDamageable
{
    public simplesAttributes simplesAtr;

    private SpriteRenderer spriteProps;

    private IEnumerator colorShine;

    public void Awake()
    {
        spriteProps = this.gameObject.GetComponent<SpriteRenderer>();

        colorShine = ColorShine();
    }
    public void TakeDamage(float DamageAmount)
    {
        simplesAtr.currentHealth -= DamageAmount;

        //StartCoroutine(colorShine);

        Debug.Log("Inimigo levou dano. Foi de " + DamageAmount + "Sua vida agora é de " + simplesAtr.currentHealth);

        if (simplesAtr.currentHealth <= 0 )
        {
            Debug.Log("Inimigo morto.");
        
            Destroy(this.gameObject);
        }
    }

    /*
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        IDamageable obj = collision.gameObject.GetComponent<IDamageable>();
        
        obj?.TakeDamage(simplesAtr.dano);
    }
    */

    IEnumerator ColorShine()
    {
        Color oldColor = spriteProps.color;
        spriteProps.color = new (255f, 255f, 255f);

        yield return new WaitForSeconds(0.2f);

        spriteProps.color = oldColor;
    }

}