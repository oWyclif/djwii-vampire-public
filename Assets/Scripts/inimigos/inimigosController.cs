using UnityEngine;

public class inimigosController : MonoBehaviour
{
    public GameObject inimigo;


    void Start()
    {
        SpawnHorda();
    }

    void Update()
    {
        
    }

    public void SpawnHorda()
    {
        for (int i = 0; i < 5; i++){
            Instantiate(inimigo, new Vector2(0, 0), Quaternion.identity);
        }
    }
}
