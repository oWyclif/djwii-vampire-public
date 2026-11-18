using System.Collections;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

                                        //IDamageable é a interface de dano do inimigo. Dessa forma, todos os scripts que o chamarem, sabem onde procurar para dar dano a ele.
                                        //Uma classe pode se inscrever a diversas interfaces.
public class enemyCombat : MonoBehaviour, IDamageable 
{
    //Aqui estou trazendo as variáveis do inimigo. simplesAttributes é a classe que elas estão, simplesAtr é como eu defini chamá-las neste script.
    public simplesAttributes simplesAtr;
    private SpriteRenderer spriteProps; //Inútil.

    //Classe de texto que eu defino no Awake (aqui eu colocaria um emoji de seta para baixo mas não tenho emoji no PC)
    public TextMeshPro inVidaText;
    
    //Evento ao qual os métodos de adição de kill e nível irão de inscrever. Está definido no Awake
    public UnityEvent inMorte; 

    
    public void Awake()
    {
        spriteProps = this.gameObject.GetComponent<SpriteRenderer>(); //Inútil.

        //Defino o TextMeshPro, componente presente no objeto filho do inimigo.
        inVidaText = this.gameObject.GetComponentInChildren<TextMeshPro>();

        //Adiciono os métodos inscritos ao evento de morte do inimigo. Primeiro, encontro o gameController, 
        //depois o seu componente GameController (ou seja, o script) e seus métodos addKill e addLevel
        inMorte.AddListener(GameObject.Find("gameController").GetComponent<GameController>().addKill);
        inMorte.AddListener(GameObject.Find("gameController").GetComponent<GameController>().addLevel);

        //DrawMostradorVida();
    }

    //Aqui tenho o método de tomar dano, derivado da minha interface "IDamageable"
    public void TakeDamage(float DamageAmount)
    {
        simplesAtr.currentHealth -= DamageAmount;

        //Debug.Log("Inimigo levou dano. Foi de " + DamageAmount + "Sua vida agora é de " + simplesAtr.currentHealth);

        //Se, ao levar dano, a vida do inimigo iguala ou vai abaixo de 0, ele MORRE.
        if (simplesAtr.currentHealth <= 0 )
        {
            Debug.Log("Inimigo morto.");
            
            //É destruúido
            Destroy(this.gameObject);

            //E o evento de morte é chamado. Dessa forma, os métodos inscritos (addKill, addLevel) são acionados
            inMorte.Invoke();            
        }

        //Mudo também o texto do filho do inimigo, para refletir sua vida atual.
        inVidaText.SetText(simplesAtr.currentHealth.ToString());
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Quando eu colido com um objeto e o nome dele é player
        if (collision.gameObject.name == "player")
            {
                //Eu pego a interface IDamageable dele e rodo o método TakeDamage.
                IDamageable obj = collision.gameObject.GetComponent<IDamageable>();
                obj?.TakeDamage(simplesAtr.dano);
            }
    }

}