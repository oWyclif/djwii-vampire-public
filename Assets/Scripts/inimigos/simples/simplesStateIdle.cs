using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplesStateIdle : simplesBaseState
{


    public override void EnterState(simplesStateManager simples){
        //Debug.Log("simples inicializado");

        // Ao inicializar o state idle eu já lanço o método de escolher o próximo
        // state. Eu poderia esperar, se quissesse.
        Escolher(simples);
    }

    public override void UpdateState(simplesStateManager simples){
    }

    public override void OnCollisionEnter(simplesStateManager simples, Collision collision){

    }
    
    public override void OnTriggerEnter(simplesStateManager simples, Collider2D collider){
        
    }


    void Escolher(simplesStateManager simples)
    {
        simples.SwitchState(simples.MovState);
    }

}