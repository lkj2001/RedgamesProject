using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamPower : MonoBehaviour
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
                case PowerType.IceCream:
                    AudioManager.instance.playSFX("Shield");
                    if (!powerUpManager.IsPowerUpActive(PowerType.IceCream))
                    {
                        powerUpManager.SetPowerUpActive(PowerType.IceCream, true);
                        IceCream();
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }

    private void IceCream()
    {
        player.isShielded = true;
        s.enabled = false;
        c.enabled = false;
    }
}
