using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public enum GameEvent
    {

        Loading,
        Lobby,
        Playing,
        Pausing,
        Ending,
        NextLevel,
        LevelPassed,
        LevelFailed,
        //Restarting, // To be deprecated
        RestartCurrentLevel,
        Resuming,
        //SecondLevelScene, // To be deprecated
        EditingScene,
        LevelHarndenerScene,
        Quitting

    }
}
