using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerAttributes player;
    //public Loot loot;
    //public DanoBoost danoBoost = new DanoBoost();
    [SerializeField] private int degrausNivel = 7;


    private float chanceLootA = 0.75f;
    private float chanceLootB = 0.2f;
    private float chanceLootC = 0.05f;
    enum lootCategoria {C, B, A}

    public void addKill()
    {
        player.killCount++;

        //Debug.Log("Contagem de kills agora é de: " + player.killCount.ToString());
    }

    public void addLevel()
    {
        if (player.killCount % degrausNivel == 0)
        {
            player.nivel++;

            dropLoot();
        }
    }

    public void dropLoot()
    {
        float rngCategoriaLoot = UnityEngine.Random.Range(0f, 1f);

        if(rngCategoriaLoot <= chanceLootA)
        {
            lootCategoria cat = lootCategoria.A;

            Debug.Log("Seu próximo loot é da categoria " + cat);

        }else if(rngCategoriaLoot > chanceLootA && rngCategoriaLoot <= chanceLootA + chanceLootB)
        {
            lootCategoria cat = lootCategoria.B;
            Debug.Log("Seu próximo loot é da categoria " + cat);
        }else
        {
            lootCategoria cat = lootCategoria.C;
            Debug.Log("Seu próximo loot é da categoria " + cat);
        }

        //int rngClasseLoot = (int)UnityEngine.Random.Range(0f, 1f);


    }
}
