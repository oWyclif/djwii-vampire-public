using UnityEngine;
using System.Collections;

public class hordaTipoSimples : hordaBase
{
    //public GameObject inimigo = Resources.Load("in_simples.prefab") as GameObject; 

    public new float Cooldown        = 3f;
    public new Object Object;
    public new int Amount            = 7;
    public new Vector2 Coord;
    public new float Area            = 3f;



    public override void HordaStart(hordaManager horda)
    {
        Object = Resources.Load("in_simples");
        Coord = new Vector2(3,3);

        //Debug.Log("Horda Simples iniciada, objeto definido como " + this.Object + " Coordenadas definidas como: " + this.Coord);

        horda.CoroutineStarter(this, Cooldown, Object, Amount, Coord, Area);
    }
}
