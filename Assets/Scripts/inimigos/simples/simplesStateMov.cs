using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplesStateMov : simplesBaseState
{
    //Transform simplesTransform;
    float simplesMoverSpeed = 0.03f;


    public GameObject player; 
    public Transform playerTransform;

    
    public override void EnterState(simplesStateManager simples){


        player = GameObject.Find("player"); 
        playerTransform = player.GetComponent<Transform>(); 

        //simplesTransform = GameObject.Find("inimigo").GetComponent<Transform>();
    }

    public override void UpdateState(simplesStateManager simples){
        simples.Transform.position = Vector2.MoveTowards(simples.Transform.position, playerTransform.position, simplesMoverSpeed);
    }

    public override void OnCollisionEnter(simplesStateManager simples, Collision collision){
         
    }

    public override void OnTriggerEnter(simplesStateManager simples, Collider2D collider){

    }
}