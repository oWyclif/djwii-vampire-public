using UnityEngine;

public abstract class simplesBaseState
{
    public abstract void EnterState(simplesStateManager simples);

    public abstract void UpdateState(simplesStateManager simples);
    
    public abstract void OnCollisionEnter(simplesStateManager simples, Collision collision);

    public abstract void OnTriggerEnter(simplesStateManager simples, Collider2D collider);

}
