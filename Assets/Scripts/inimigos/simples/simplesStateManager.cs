using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplesStateManager : MonoBehaviour
{
    simplesBaseState currentState;

    public simplesStateIdle IdleState = new simplesStateIdle();
    public simplesStateMov MovState = new simplesStateMov();

    public Transform Transform;
    public GameObject simplesGO;


    void Start()
    {
        //Transform = simplesGO.GetComponent<Transform>();

        currentState = IdleState;

        // Depois de definir o state do simples como idle, rodamos a função "EnterState();
        // que ele herda do "template" (simplesBaseState).
        currentState.EnterState(this);

        Debug.Log(this.gameObject);
    }

    void Update()
    {
        currentState.UpdateState(this);

        Debug.Log(currentState);
    }
    
    //Estamos trazendo o OnTriggerEnter da Unity para cá, e lançando para nossos
    // states. Cada um deles tem um comportamento na colisão, apresentado na 
    // função "public override void OnTriggerEnter(simplesStateManager simples)"
    void OnTriggerEnter2D(Collider2D collider2D){
        currentState.OnTriggerEnter(this, collider2D);
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }

    public void SwitchState(simplesBaseState state){
        // Aqui, a Unity espera um state (simplesBaseState state)
        // Definiremos então nosso currentState para o state recebido
        currentState = state;

        // Depois de definir isso, rodamos a lógica de enterState, iniciando
        // nosso novo state.
        state.EnterState(this);
    }
}