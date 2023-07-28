using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List <Transform> levelPartList;
    //[SerializeField] private Player player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;

        for(int i = 0;i< startingSpawnLevelParts; i++)
        {
            SpawnLevelParts();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(player.GetPosition(),lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        //{
        //    SpawnLevelParts();
        //}
    }

    private void SpawnLevelParts()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
    }

    private Transform SpawnLevelPart (Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
