using System;
using UnityEngine;

/*
interface ILoot
{
    void ApplyLoot();
}
*/

public class Boost : IEquatable<Boost>
{
    public int boostID;
    public string boostNome;
    public string categoria;
    public float boostValue;
    public string boostArea;
    
    public bool Equals(Boost other)
    {
        if (other == null) return false;
        Boost objAsBoost = other as Boost;
        if (objAsBoost == null) return false;
        else return Equals(objAsBoost);
    }
}