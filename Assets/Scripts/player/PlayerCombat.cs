using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour, IDamageable
{
    public PlayerAttributes playerAtr;

    public void Awake()
    {
        playerAtr.currentHealth = playerAtr.maxHealth;
        DrawAtkArea();
    }

    public void FixedUpdate()
    {
        //O ataque acontece a cada frame. Isso pode ser modificado depois, criando uma coroutine que é roda um loop a cada 2seg, por exemplo.
        Attack();
    }

    //Talvez mover isto para uma interface de ataque um dia. Poderia facilitar na hora de criar diferentes ataques, recebendo parâmetros de área
    //dano, itens a buscar, etc.
    public void Attack()
    {
        Debug.Log("Attack called");
  
        Collider2D[] inimigosAtingidos = Physics2D.OverlapCircleAll(playerAtr.tr.position, playerAtr.atkArea);
 
        foreach(Collider2D inimigoColisor in inimigosAtingidos)
        {
            if (inimigoColisor.gameObject.name != "player")
            {
                IDamageable obj = inimigoColisor.GetComponent<IDamageable>();
                obj?.TakeDamage(playerAtr.danoAtual);
            }
        }
    }

    public void TakeDamage(float DamageAmount)
    {
        playerAtr.currentHealth -= DamageAmount;
        Debug.Log("Player sofreu dano");

        if (playerAtr.currentHealth <= 0 )
        {
            Debug.Log("Player morto.");
            SceneManager.LoadScene("scene_level");
        }
    }

    public void DrawAtkArea()
    {
        //Implementação burra, mas ok
        GameObject oldAtkArea = GameObject.Find("AtkArea");
        Destroy(oldAtkArea);

        //GameObject atkArea = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject atkArea = new GameObject("AtkArea");
        
        SpriteRenderer renderer = atkArea.AddComponent<SpriteRenderer>();
        renderer.color = new Color(0f, 0f, 1f, 0.4f);
        Texture2D tex = Resources.Load<Texture2D>("Circle");
        
        Sprite sprite = Sprite.Create(tex, new UnityEngine.Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), (float) tex.width);
        renderer.sprite = sprite;


        atkArea.transform.SetParent(playerAtr.tr);
        atkArea.transform.localScale = new Vector3(playerAtr.atkArea*2, playerAtr.atkArea*2, 0);
        //atkArea.name = "atkArea";
        //Destroy(atkArea.GetComponent<SphereCollider>());
    }
}
