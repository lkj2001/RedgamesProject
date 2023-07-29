using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    Kebab,
    NasiLemak,
    IceCream
}

public class PowerUp : MonoBehaviour
{
    public Player player;
    private SpriteRenderer s;
    private CircleCollider2D c;
    private PowerupManager powerUpManager;

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
                    if (!powerUpManager.IsPowerUpActive(PowerType.Kebab))
                    {
                        Debug.Log("ACTIVATE");
                        powerUpManager.SetPowerUpActive(PowerType.Kebab, true);
                        StartCoroutine(kebab());
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    break;

                case PowerType.NasiLemak:
                    break;

                case PowerType.IceCream:
                    break;

                default:
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
        player.State = State.Normal;
        player.speed /= 2;
        powerUpManager.SetPowerUpActive(PowerType.Kebab, false);
        Destroy(gameObject);
    }
}
