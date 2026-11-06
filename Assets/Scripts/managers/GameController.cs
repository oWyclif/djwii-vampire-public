using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerAttributes player;
    [SerializeField] private int degrausNivel = 7;

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
        Debug.Log("Dropar loot aqui!");
    }
}
