using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Player player;
    public GameObject shield;
    private SpriteRenderer sprite;
    private SpriteRenderer enemySprite;

    public void Start()
    {
        sprite = shield.GetComponent<SpriteRenderer>();
        enemySprite = GetComponent<SpriteRenderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(player.isShielded)
            {
                StartCoroutine(shieldSprite1());
                StartCoroutine(Enemysprite());
                  
            }
            else
            {
                Destroy(collision.gameObject);
                //Destroy(gameObject);
                StartCoroutine(Enemysprite());
            }

        }
    }

    public IEnumerator Enemysprite()
    {
        enemySprite.enabled = false;

        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);

    }

    public IEnumerator shieldSprite()
    {
        sprite.enabled = false;

        yield return new WaitForSeconds(1);

        player.isShielded = false;
    }

    public IEnumerator shieldSprite1()
    {
        sprite.enabled = false;

        yield return new WaitForSeconds(0.3f);

        sprite.enabled = true;

        yield return new WaitForSeconds(0.3f);

        sprite.enabled = false;

        yield return new WaitForSeconds(0.3f);

        sprite.enabled = true;

        yield return new WaitForSeconds(0.1f);

        player.isShielded = false;
    }
}
