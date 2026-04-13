public enum LevelMode
{
    LevelOne,
    LevelThree,
    LastLevel
}

public static class SceneContext
{
    // Default so normal playthroughs work
    public static LevelMode CurrentLevelMode = LevelMode.LevelOne;
}
