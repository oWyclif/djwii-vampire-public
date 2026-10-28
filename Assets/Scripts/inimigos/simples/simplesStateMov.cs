using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplesStateMov : simplesBaseState
{
    Transform simplesTransform;
    float simplesMoverSpeed = 0.03f;


    public GameObject player; 
    public Transform playerTransform;
    
    public override void EnterState(simplesStateManager simples){
        //Debug.Log("simples Movendo");

        player = GameObject.Find("player"); //Aqui encontramos o Objeto player
        playerTransform = player.GetComponent<Transform>(); // E definimos o playertransform,
        // a posição do player

        simplesTransform = GameObject.Find("inimigo").GetComponent<Transform>();
    }

    public override void UpdateState(simplesStateManager simples){
        simplesTransform.position = Vector2.MoveTowards(simplesTransform.position, playerTransform.position, simplesMoverSpeed);
    }

    public override void OnCollisionEnter(simplesStateManager simples, Collision collision){
         
    }

    public override void OnTriggerEnter(simplesStateManager simples, Collider2D collider){

    }
}