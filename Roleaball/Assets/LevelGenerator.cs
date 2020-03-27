using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform level_Start;
    [SerializeField] private PlayerMovement player;
    private string endPos = "EndPosition";

    private Vector3 lastEndPosition;
    private void Awake()
    {
        
        lastEndPosition = level_Start.Find(endPos).position;
        int startingSpawnLevelParts = 15;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();

        }

    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find(endPos).position;
    }

    private Transform SpawnLevelPart(Transform levelpart ,Vector3 spawnPos)
    {
        Transform levelPartTransform = Instantiate(levelpart, spawnPos, Quaternion.identity);
        return levelPartTransform;
    }

}