using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List <Transform> levelPartList;
    [SerializeField] private Player player;
    [SerializeField] private Transform transitionTileset;

    private Vector3 lastEndPosition;

    private IEnumerator tilesetSwitchCoroutine;
    private bool continueSpawning = true;
    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;

        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelParts();
        }

        //tilesetSwitchCoroutine = SwitchToTransitionTileset();
        StartCoroutine(SwitchToTransitionTileset());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (continueSpawning && Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelParts();
        }
    }

    private void SpawnLevelParts()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        Debug.Log("Spawned level part at: " + lastLevelPartTransform.position);
    }

    private Transform SpawnLevelPart (Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private void SpawnTransitionTileset()
    {
        // Spawn the "Transition" tileset using the transitionTileset variable
        // You can modify this part based on how the "Transition" tileset should be spawned
        // For example, you can instantiate a specific set of tiles, etc.
        Transform lastLevelPartTransform = SpawnLevelPart(transitionTileset, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        Debug.Log("Spawned Transition tileset at: " + lastLevelPartTransform.position);
    }
    private IEnumerator SwitchToTransitionTileset()
    {
        // Wait for one minute
        yield return new WaitForSeconds(60f);

        // Call the function to spawn the "Transition" tileset
        SpawnTransitionTileset();

        // Stop tileset spawning
        continueSpawning = false;
    }
}
