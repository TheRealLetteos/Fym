using fym;
using System.Collections.Generic;
using UnityEngine;
/**
* abstract factory pattern will be applied to this class
* 
*/
public class BaseNPCSpawner
{

    public static List<GameObject> GenerateGameObjectsForLevel(LevelConfig config)
    {

        List<GameObject> ret = new List<GameObject>();

        float sumOfEnemyLevels = config.enemyLevel * config.enemyCount;

        int maxNPCLevel = (int)Mathf.Ceil(config.enemyLevel);
        int minNPCLevel = (int)Mathf.Floor(config.enemyLevel);
        if(maxNPCLevel == minNPCLevel && minNPCLevel > 1)
        {
            minNPCLevel--;
        }

        float totalNPCLevels = 0;
        int currentNpcLevel = maxNPCLevel;
        while(totalNPCLevels < sumOfEnemyLevels)
        {
            if(currentNpcLevel + totalNPCLevels >= sumOfEnemyLevels)
            {
                currentNpcLevel = minNPCLevel;
            }

            GameObject npc = NPCPoolManager.Instance.GetRandomNPCByLevel(currentNpcLevel);
            if(npc != null)
            {
                ret.Add(npc);
            }
            else
            {
                Debug.LogWarning("NPC not found for level " + currentNpcLevel);
            }
            totalNPCLevels += currentNpcLevel;
        }
        if(ret.Count > 0)
        {
            Debug.Log("NPCs generated for level " + config.enemyLevel + ": " + ret.Count);
            return ret;
        }
        else
        {
            Debug.LogWarning("No NPCs generated for level " + config.enemyLevel);
            return null;
        }
        //return ret.Count > 0 ? ret : null;
    }

    public static Vector2[] PickSpawnPositions(int spawnCount, float screenWidth, float screenHeight, float spawnDensity, float spawnRange)
    {
        Vector2[] spawnPositions = new Vector2[spawnCount];
        int spawnIndex = 0;
        float spawnArea = screenWidth * screenHeight * spawnDensity;
        float spawnAreaPerNPC = spawnArea / spawnCount;
        float spawnRadius = Mathf.Sqrt(spawnAreaPerNPC / Mathf.PI);
        float spawnRadiusSquared = spawnRadius * spawnRadius;
        float spawnRangeSquared = spawnRange * spawnRange;
        while (spawnIndex < spawnCount)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(0, screenWidth), Random.Range(0, screenHeight));
            bool validSpawn = true;
            for (int i = 0; i < spawnIndex; i++)
            {
                Vector2 spawnPosition2 = spawnPositions[i];
                float distanceSquared = (spawnPosition - spawnPosition2).sqrMagnitude;
                if (distanceSquared < spawnRadiusSquared)
                {
                    validSpawn = false;
                    break;
                }
            }
            if (validSpawn)
            {
                spawnPositions[spawnIndex] = spawnPosition;
                spawnIndex++;
            }
        }
        return spawnPositions;
    }

    public static void SpawnNPCs(List<GameObject> npcs, Vector2[] spawnPositions)
    {
        int maxIndex = 0;
        if(npcs.Count != spawnPositions.Length)
        {
            Debug.LogWarning("NPC count does not match spawn position count.");
            //return;
        }
        maxIndex = Mathf.Min(npcs.Count, spawnPositions.Length);
        for (int i = 0; i < maxIndex; i++)
        {
            Vector2 spawnPosition = spawnPositions[i];
            GameObject npc = npcs[i];
            npc.transform.position = spawnPosition;
            npc.SetActive(true);
        }
    }


    public static void SpawnNPCs(List<GameObject> npcs, int spawnCount, float screenWidth, float screenHeight, float spawnDensity, float spawnRange)
    {
        Vector2[] spawnPositions = PickSpawnPositions(npcs.Count, screenWidth, screenHeight, spawnDensity, spawnRange);
        SpawnNPCs(npcs, spawnPositions);
    }

    public static void SpawnNPCs(LevelConfig levelConfig)
    {
        SpawnNPCs(GenerateGameObjectsForLevel(levelConfig),
            levelConfig.enemyCount, levelConfig.screenWidth, levelConfig.screenHeight, levelConfig.spawnDensity, levelConfig.spawnRange);
    }

}
