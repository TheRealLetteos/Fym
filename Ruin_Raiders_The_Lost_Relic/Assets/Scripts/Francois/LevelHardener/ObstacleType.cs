using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    ExtraEnemy,
    Spikes,
    Lava,
    SpeedIncrease,
    ExtraHealth,
    DamageTimerDecrease,
    DamageReduction,
    ExtraTile
    //TimeReduction
    //RemoveCoinPowerup
    //JumpLessHigh
    //ReduceHPBy1
} // easily extendable if needed, more obstacles...

[System.Serializable]
public class Obstacle
{
    public ObstacleType type;
    public float probability;  // Probability of this obstacle being chosen because it changes!
}

