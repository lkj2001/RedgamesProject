using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrallex : MonoBehaviour
{
    //private float length, startpos;
    //public GameObject cam;
    //public float parallaxEffect;

    //private void Start()
    //{
    //    startpos = transform.position.x;
    //    length = GetComponent<SpriteRenderer>().bounds.size.x;
    //}

    //private void Update()
    //{
    //    float temp = (cam.transform.position.x * (1 - parallaxEffect));
    //    float dist = (cam.transform.position.x * parallaxEffect);

    //    transform.position = new Vector3(startpos*dist, transform.position.y, transform.position.z);

    //    if (temp > startpos + length) startpos += length;
    //    else if (temp< startpos- length) startpos -= length;
    //}
    public Transform player;
    public float parallaxEffect;

    private float length;
    private float startPos;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (player.position.x * (1 - parallaxEffect));
        float dist = (player.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}
