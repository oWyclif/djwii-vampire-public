using UnityEngine;

public class enemyCombat : MonoBehaviour, IDamageable
{
    public simplesAttributes simplesAtr;
    public void TakeDamage(float DamageAmount)
    {
        Debug.Log("Inimigo levou dano. Foi de " + DamageAmount);
    }
}