using UnityEngine;

public abstract class simplesBaseState
{
    //Esta é a classe abstrata da State Machine do meu inimigo. Serve de base para os dois estados que ele tem: Idle e Mov. Mesmo sistema do Boss, do bimestre passado
    public abstract void EnterState(simplesStateManager simples);
    //     abstract aqui significa que a lógica dessa função é definidida dentro de cada classe que a herda.
    //     ela também é OBRIGATÓRIA.

    public abstract void UpdateState(simplesStateManager simples);
    
    public abstract void OnCollisionEnter(simplesStateManager simples, Collision collision);

    public abstract void OnTriggerEnter(simplesStateManager simples, Collider2D collider);

}
