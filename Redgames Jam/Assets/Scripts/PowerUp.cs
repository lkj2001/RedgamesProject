using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

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

    [Header("PowerUp Type")]
    public PowerType PowerType;

    public void Start()
    {
        s = GetComponent<SpriteRenderer>();
        c = GetComponent<CircleCollider2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch(PowerType)
        {
            case PowerType.Kebab:
                if (StartCoroutine(kebab()) != null)
                {
                    StopCoroutine(StartCoroutine(kebab())); // Stop the existing coroutine if it's running
                }
                StartCoroutine(kebab());
                break;

            case PowerType.NasiLemak:
                break;

            case PowerType.IceCream:
                break;

            default:
                break;
        }
    }

    public IEnumerator kebab()
    {
        player.State = State.Invicible;
        player.speed *= 2;
        s.enabled = false;
        c.enabled = false;
        yield return new WaitForSeconds(5);
        player.State = State.Normal;
        player.speed /= 2;
        Destroy(gameObject);
    }
}
