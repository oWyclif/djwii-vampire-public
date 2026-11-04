using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hordaManager : MonoBehaviour
{
    //public GameObject inimigo;
    IEnumerator coroutineHorda;
    //public Vector2 _hordaCoord;

    public hordaBase hordaAtual;

    public hordaTipoComplexa HordaComplexa = new hordaTipoComplexa();
    public hordaTipoSimples HordaSimples = new hordaTipoSimples();


    void Start()
    {
        /*
        _hordaCoord = new Vector2(3, 3);
        coroutineHorda = spawnHorda(3f, inimigo, 6, _hordaCoord, 2f);
        StartCoroutine(coroutineHorda);
        */

        hordaAtual = HordaSimples;
        hordaAtual.HordaStart(this);
        

    }

    void FixedUpdate()
    {
    }


    
    public void CoroutineStarter(hordaBase horda)
    {
        coroutineHorda = spawnHorda(horda);

        this.StartCoroutine(coroutineHorda);
    }


    // Essa construção abaixo é igual a "IEnumerator spawnHorda(float hordaCool, int hordaAmount [...])". 
    // Está disposto dessa forma para visualização mais fácil
    IEnumerator spawnHorda(hordaBase horda)
        /*
        float           Cooldown,
        Object          Object,
        int             Amount,
        Vector2         Coord,
        float           Area)
        */
    {
        hordaAtual = horda;
        //Debug.Log("Coroutine rodando");
        
        //for (int i = 0; i < Amount; i++){
            
            Debug.Log("For loop Iniciado. O Object é " + horda.Object + horda.Cooldown);

            Instantiate(horda.Object, new Vector2(Random.Range(horda.Coord.x - horda.Area, horda.Coord.x + horda.Area), 
                                            Random.Range(horda.Coord.y - horda.Area, horda.Coord.y + horda.Area)), Quaternion.identity);

            Debug.Log("Inimigo spawnado");
                
            yield return new WaitForSeconds(horda.Cooldown);
        //}
    }
    
}

