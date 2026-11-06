using UnityEngine;
using System.Collections;

public class hordaTipoComplexa : hordaBase
{
    //public GameObject inimigo = Resources.Load("in_simples.prefab") as GameObject; 

    public new float Cooldown        = 0.1f;
    public new Object Object;
    public new int Amount            = 30;
    public new Vector2 Coord;
    public new float Area            = 5f;

    public override void HordaStart(hordaManager horda)
    {
        Object = Resources.Load("in_complexo");
        Coord = new Vector2(5,5);

        //Debug.Log("Horda Complexa iniciada, objeto definido como " + this.Object);

        horda.CoroutineStarter(this, 
                                Cooldown, 
                                Object, 
                                Amount, 
                                Coord, 
                                Area);
    }
}