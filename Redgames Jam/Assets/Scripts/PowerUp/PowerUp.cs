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
    //public Player player;
    //private SpriteRenderer s;
    //private CircleCollider2D c;
    //private PowerupManager powerUpManager;
    ////public CoinManager CM;

    //[Header("Sprite")]
    //public Sprite kebabSprite;
    //public Sprite nasiLemakSprite;
    //public Sprite iceCreamSprite;
    //private SpriteRenderer spriteRenderer;

    //[Header("PowerUp Type")]
    //public PowerType PowerType;

    //private void Start()
    //{
    //    s = GetComponent<SpriteRenderer>();
    //    c = GetComponent<CircleCollider2D>();
    //    powerUpManager = FindObjectOfType<PowerupManager>();
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    //public void Update()
    //{
    //    switch(PowerType)
    //    {
    //        case PowerType.Kebab:
    //            spriteRenderer.sprite = kebabSprite; 
    //            break;
    //        case PowerType.NasiLemak:
    //            spriteRenderer.sprite= nasiLemakSprite;
    //            break;
    //        case PowerType.IceCream:
    //            spriteRenderer.sprite= iceCreamSprite;
    //            break;
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        switch (PowerType)
    //        {
    //            case PowerType.Kebab:
    //                if (!powerUpManager.IsPowerUpActive(PowerType.Kebab))
    //                {
    //                    powerUpManager.SetPowerUpActive(PowerType.Kebab, true);
    //                    StartCoroutine(kebab());
    //                }
    //                else
    //                {
    //                    Destroy(gameObject);
    //                }
    //                break;

    //            case PowerType.NasiLemak:
    //                if(!powerUpManager.IsPowerUpActive(PowerType.NasiLemak))
    //                {
    //                    powerUpManager.SetPowerUpActive(PowerType.NasiLemak, true);
    //                    StartCoroutine(NasiLemak());
    //                }
    //                else
    //                {
    //                    Destroy(gameObject);
    //                }
    //                break;

    //            case PowerType.IceCream:
    //                if(!powerUpManager.IsPowerUpActive(PowerType.IceCream))
    //                {
    //                    powerUpManager.SetPowerUpActive(PowerType.IceCream, true);
    //                    IceCream();
    //                }
    //                else
    //                {
    //                    Destroy(gameObject);
    //                }
    //                break;

    //            default:
    //                break;
    //        }
    //    }
    //}

    //private IEnumerator kebab()
    //{
    //    player.State = State.Invicible;
    //    player.speed *= 2;
    //    s.enabled = false;
    //    c.enabled = false;
    //    yield return new WaitForSeconds(5);
    //    player.speed /= 2;
    //    yield return new WaitForSeconds(1);
    //    player.State = State.Normal;
    //    powerUpManager.SetPowerUpActive(PowerType.Kebab, false);
    //    Destroy(gameObject);
    //}

    //private void IceCream()
    //{
    //    player.isShielded = true;
    //    s.enabled = false;
    //    c.enabled = false;
    //}

    //private IEnumerator NasiLemak()
    //{
    //    CoinManager.Instance.DoublePoint = true;
    //    s.enabled = false;
    //    c.enabled = false;
    //    yield return new WaitForSeconds(7);
    //    CoinManager.Instance.DoublePoint = false;
    //    Debug.Log("NO MORE NASI");
    //    powerUpManager.SetPowerUpActive(PowerType.NasiLemak, false);
    //    Destroy(gameObject);
    //}
}
