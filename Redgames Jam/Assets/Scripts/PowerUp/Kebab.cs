using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kebab : MonoBehaviour
{
    public Player player;
    private SpriteRenderer s;
    private CircleCollider2D c;
    private PowerupManager powerUpManager;
    //public CoinManager CM;

    [Header("PowerUp Type")]
    public PowerType PowerType;

    private void Start()
    {
        s = GetComponent<SpriteRenderer>();
        c = GetComponent<CircleCollider2D>();
        powerUpManager = FindObjectOfType<PowerupManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (PowerType)
            {
                case PowerType.Kebab:

                    AudioManager.instance.playSFX("Kebab");
                    if (!powerUpManager.IsPowerUpActive(PowerType.Kebab))
                    {
                        powerUpManager.SetPowerUpActive(PowerType.Kebab, true);
                        StartCoroutine(kebab());
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    break;    
            }
        }
    }

    private IEnumerator kebab()
    {
        player.State = State.Invicible;
        player.speed *= 2;
        s.enabled = false;
        c.enabled = false;
        yield return new WaitForSeconds(5);
        player.speed /= 2;
        yield return new WaitForSeconds(1);
        player.State = State.Normal;
        powerUpManager.SetPowerUpActive(PowerType.Kebab, false);
        Destroy(gameObject);
    }
}
