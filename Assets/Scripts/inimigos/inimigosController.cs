using UnityEngine;
using System.Collections;

public class inimigosController : MonoBehaviour
{
    public GameObject inimigo;
    public IEnumerator coroutineHorda;
    public Vector2 _hordaCoord;


    void Start()
    {
        _hordaCoord = new Vector2(3, 3);
        coroutineHorda = spawnHorda(3f, inimigo, 6, _hordaCoord, 2f);
        StartCoroutine(coroutineHorda);
    }

    void Update()
    {
        
    }

    // Essa construção abaixo é igual a "IEnumerator spawnHorda(float hordaCool, int horda[...])". 
    // Está disposto dessa forma para visualização mais fácil
    IEnumerator spawnHorda(
        float       hordaCooldown, 
        GameObject  hordaObject,
        int         hordaAmount,
        Vector2     hordaCoord,
        //float       hordaCoord_X,
        //float       hordaCoord_Y,
        float       hordaSize)
    {
        for (int i = 0; i < hordaAmount; i++){
            Instantiate(hordaObject, new Vector2(Random.Range(hordaCoord.x - hordaSize, hordaCoord.x + hordaSize), Random.Range(hordaCoord.y - hordaSize, hordaCoord.y + hordaSize)), Quaternion.identity);
            yield return new WaitForSeconds(hordaCooldown);
        }
    }
}
