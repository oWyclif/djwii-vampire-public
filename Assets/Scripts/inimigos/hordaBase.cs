using UnityEngine;
using System.Collections;

public class hordaBase
{
    public float Cooldown;
    public Object Object;
    public int Amount;
    public Vector2 Coord;
    public float Area;

    public virtual void HordaStart(hordaManager horda)
    {   

    }

    public virtual void HordaSpawn(hordaManager horda)
    {
        
    }
}
