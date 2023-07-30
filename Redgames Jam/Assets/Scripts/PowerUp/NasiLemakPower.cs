using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NasiLemakPower : MonoBehaviour
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
                case PowerType.NasiLemak:
                    if (!powerUpManager.IsPowerUpActive(PowerType.NasiLemak))
                    {
                        powerUpManager.SetPowerUpActive(PowerType.NasiLemak, true);
                        StartCoroutine(NasiLemak());
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }

    private IEnumerator NasiLemak()
    {
        CoinManager.Instance.DoublePoint = true;
        s.enabled = false;
        c.enabled = false;
        yield return new WaitForSeconds(7);
        CoinManager.Instance.DoublePoint = false;
        Debug.Log("NO MORE NASI");
        powerUpManager.SetPowerUpActive(PowerType.NasiLemak, false);
        Destroy(gameObject);
    }
}
