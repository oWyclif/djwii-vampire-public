using UnityEngine;

public class simplesAttributes : MonoBehaviour
{
    //Neste script estou guardando os atributos do inimigo que utilizarei em outras áreas.
    //Para utilizá-los, declaro o simplesAttributes com o nome "simplesAtr" e assim tenho acesso a todas as variáveis relevantes do inimigo
    //Por que simples? Porque eu faria um para o inimigo simples e um para o complexo, mas essa foi uma escolha burra da minha parte. Tenho que mudar os nomes depois.

    [Header("Vida")] //Header para deixar mais bonitinho na Unity
    public float maxHealth;
    public float currentHealth;
    public float dano;

    //Acho que os nomes dessas variáveis são autoexplicativos
}