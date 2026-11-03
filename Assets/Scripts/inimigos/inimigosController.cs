using UnityEngine;
using System.Collections;

public class inimigosController : MonoBehaviour
{
    public GameObject inimigo;
    public IEnumerator coroutineHorda;


    void Start()
    {
        coroutineHorda = spawnHorda();
        StartCoroutine(coroutineHorda);
    }

    void Update()
    {
        
    }

    IEnumerator spawnHorda()
    {
        for (int i = 0; i < 5; i++){
            Instantiate(inimigo, new Vector2(0, 0), Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
