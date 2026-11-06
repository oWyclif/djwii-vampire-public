using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hordaManager : MonoBehaviour
{
    public hordaBase hordaAtual;
    public hordaTipoComplexa HordaComplexa = new hordaTipoComplexa();
    public hordaTipoSimples HordaSimples = new hordaTipoSimples();
    IEnumerator coroutineHorda;

    public void Awake()
    {
        Decisor();
    }

    public void Decisor()
    {
        float rngHorda = Random.Range(0f, 1f);

        if(rngHorda >= 0.5f)
        {
            hordaAtual = HordaComplexa;
            hordaAtual.HordaStart(this);
        }
        else
        {
            hordaAtual = HordaSimples;
            hordaAtual.HordaStart(this);
        }
    }

    public void CoroutineStarter(hordaBase crHorda, 
                                float crCooldown, 
                                Object crObject, 
                                int crAmount, 
                                Vector2 crCoord, 
                                float crArea)
    {
        coroutineHorda = SpawnHorda(crHorda, crCooldown, crObject, crAmount, crCoord, crArea);
        StartCoroutine(coroutineHorda);

        //Debug.Log("CoroutineStarter rodou. A horda veio e suas coordenadas são " + crCoord);
    }

    public IEnumerator SpawnHorda(hordaBase horda,
        float           Cooldown,
        Object          Object,
        int             Amount,
        Vector2         Coord,
        float           Area)
    {
        //Debug.Log("Coroutine rodando");

        hordaAtual = horda;
        
        for (int i = 0; i < Amount; i++){
            
            //Debug.Log("For loop Iniciado. O Object é " + Object + Cooldown);

            Instantiate(Object, new Vector2(Random.Range(Coord.x - Area, Coord.x + Area), 
                                            Random.Range(Coord.y - Area, Coord.y + Area)), Quaternion.identity);

            //Debug.Log("Inimigo spawnado");
                
            yield return new WaitForSeconds(Cooldown);
        }
        yield return new WaitForSeconds(10f);
        Decisor();
    }
}

