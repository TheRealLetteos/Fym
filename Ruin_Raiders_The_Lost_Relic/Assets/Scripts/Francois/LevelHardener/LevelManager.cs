using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Obstacle> obstacles = new List<Obstacle>
{
    new Obstacle { type = ObstacleType.ExtraEnemy, probability = 20 },
    new Obstacle { type = ObstacleType.Spikes, probability = 20 },
    new Obstacle { type = ObstacleType.Lava, probability = 10 },
    new Obstacle { type = ObstacleType.SpeedIncrease, probability = 10 },
    new Obstacle { type = ObstacleType.ExtraHealth, probability = 10 },
    new Obstacle { type = ObstacleType.DamageTimerDecrease, probability = 10 },
    new Obstacle { type = ObstacleType.DamageReduction, probability = 10 },
    new Obstacle { type = ObstacleType.ExtraTile, probability = 10 }
}; ///Suuuuuppeerrr extensible!!! 

    public void ApplyRandomObstacle()
    {
        float totalProbability = 0;
        foreach (var obstacle in obstacles)
        {
            totalProbability += obstacle.probability; //Probabilities don't even need to add to anything in particular!!!
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
      
    }

    void AddSpikes() 
    {
    
    }

    void ConvertTileToLava() 
    {  
    
    }

    void IncreaseEnemySpeed() 
    { 
    
    }

    void IncreaseEnemyHealth() 
    {  
    
    }

    void DecreaseDamageTimer() 
    {  
    
    }
    void ReducePlayerDamage() 
    { 
    
    }

    void AddExtraTile() 
    { 

    }
}