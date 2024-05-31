using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManagerInGame : MonoBehaviour
{

    public Tilemap tilemap; //put ground there, probably add in awake() for sprint 5
    public Tilemap enemyTilemap;
    public Tile spikeTile;
    public Tile groundTile;
    public Tile lavaTile; // dont have a lava asset yet, should be insta death, maybe burn stuff around?

    public GameObject[] enemyPrefabs;  // Array of enemy prefabs
    public Transform enemiesParent;
    public List<Obstacle> obstacles = new List<Obstacle>
{
    new Obstacle { type = ObstacleType.ExtraEnemy, probability = 10 },
    new Obstacle { type = ObstacleType.Spikes, probability = 20 },
    new Obstacle { type = ObstacleType.Lava, probability = 20 },
    new Obstacle { type = ObstacleType.SpeedIncrease, probability = 0 },
    new Obstacle { type = ObstacleType.ExtraHealth, probability = 0 },
    new Obstacle { type = ObstacleType.DamageTimerDecrease, probability =0 },
    new Obstacle { type = ObstacleType.DamageReduction, probability = 0 },
    new Obstacle { type = ObstacleType.ExtraTile, probability = 0 }
}; //Suuuuuppeerrr extensible!!! Nicolas H. would be proud!!!
    
    public void ApplyRandomObstacle()
    {
        float totalProbability = 0;
        foreach (var obstacle in obstacles)
        {
            totalProbability += obstacle.probability; // Probabilities don't even need to add to anything in particular!!!
        }

        float randomPoint = Random.value * totalProbability;

       
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (randomPoint < obstacles[i].probability)
                {
                    switch (obstacles[i].type)
                    {
                        case ObstacleType.ExtraEnemy:
                            SpawnExtraEnemy();
                            break;
                        case ObstacleType.Spikes:
                            AddSpikes();
                            break;
                        case ObstacleType.Lava:
                            ConvertTileToLava();
                            break;
                        case ObstacleType.SpeedIncrease:
                            IncreaseEnemySpeed();
                            break;
                        case ObstacleType.ExtraHealth:
                            IncreaseEnemyHealth();
                            break;
                        case ObstacleType.DamageTimerDecrease:
                            DecreaseDamageTimer();
                            break;
                        case ObstacleType.DamageReduction:
                            ReducePlayerDamage();
                            break;
                        case ObstacleType.ExtraTile:
                            AddExtraTile();
                            break;
                    }
                    break;
                }
                randomPoint -= obstacles[i].probability;
            }
    }

    // Each obstacle does...
    void SpawnExtraEnemy()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

       
        List<Vector3Int> suitableTilePositions = new List<Vector3Int>();

       
        for (int x = 3; x < bounds.size.x-3; x++)
        {
            for (int y = 3; y < bounds.size.y-3; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null) 
                {
                    Vector3Int groundPos = new Vector3Int(x + bounds.x, y + bounds.y, 0);
                    Vector3Int abovePos = new Vector3Int(groundPos.x, groundPos.y + 1, 0);

                    
                    if (!tilemap.HasTile(abovePos))
                    {
                        suitableTilePositions.Add(groundPos);
                    }
                }
            }
        } // again, build every time as level can change

        
        if (suitableTilePositions.Count > 0)
        {
            Vector3Int randomTilePosition = suitableTilePositions[Random.Range(0, suitableTilePositions.Count)];
            Vector3 spawnPosition = tilemap.CellToWorld(randomTilePosition) + new Vector3(0f, 0f, 0f);  // enemy are gameobjects in game, so float it is

            // Randomly pick one of the enemy prefabs
            if (enemyPrefabs.Length > 0)
            {
                GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                Debug.Log("Enemy spawned at: " + spawnPosition);
            }
            else
            {
                Debug.LogError("No enemy prefabs are assigned in the array!");
            }
        }
        else
        {
            Debug.Log("No suitable positions available for enemy placement.");
        }
    }

    void AddSpikes()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        // List to hold positions of suitable tiles for spikes
        List<Vector3Int> suitableTilePositions = new List<Vector3Int>();

        // Iterate through all tiles in the tilemap to find suitable positions
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 1; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null && tile != spikeTile && tile != lavaTile) // Ensure the tile is not already a spike!
                {
                    Vector3Int tilePosition = new Vector3Int(x + bounds.x, y + bounds.y, 0);
                    suitableTilePositions.Add(tilePosition);
                }
            }
        }

        // Choose a random tile position from the list of suitable positions
        if (suitableTilePositions.Count > 0)
        {
            Vector3Int selectedTilePosition = suitableTilePositions[Random.Range(0, suitableTilePositions.Count)];

            
            tilemap.SetTile(selectedTilePosition, null);  // Replace with a ground tile so no holes if you want (groundTile)

            // Place a spike tile on the enemy tilemap at the same position
            enemyTilemap.SetTile(selectedTilePosition, spikeTile);
        }
    } // Ideally, we'd build this vector of ground only once, as level is not made harder during play, so static once loaded

    void ConvertTileToLava()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        // List to hold positions of all good tiles for lava/fire if you prefer
        List<Vector3Int> suitableTilePositions = new List<Vector3Int>();

        // Iterate through all tiles in the tilemap to find suitable positions!
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 1; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null && tile != lavaTile && tile != lavaTile) // Ensure the tile is not already lava!
                {
                    Vector3Int tilePosition = new Vector3Int(x + bounds.x, y + bounds.y, 0);
                    suitableTilePositions.Add(tilePosition);
                }
            }
        }

        // Choose a random tile position from the list of okay positions
        if (suitableTilePositions.Count > 0)
        {
            Vector3Int selectedTilePosition = suitableTilePositions[Random.Range(0, suitableTilePositions.Count)];

            // Delete current tile so player can hit spike
            tilemap.SetTile(selectedTilePosition, null);  // or change to ground

            // Place a lava or fire tile 
            enemyTilemap.SetTile(selectedTilePosition, lavaTile);
        }
    }

    void IncreaseEnemySpeed() 
    { 
        // Cancelled
    }

    void IncreaseEnemyHealth() 
    {
        // Cancelled


    }

    void DecreaseDamageTimer() 
    {
        // Cancelled
    }
    void ReducePlayerDamage() 
    {
        // Cancelled
    }

    void AddExtraTile() 
    {
        // Cancelled
    }

   
}