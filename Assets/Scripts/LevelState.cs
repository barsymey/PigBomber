public static class LevelState
{
    private static int enemiesLeft;

    public static void AddEnemy(int amount)
    {
        enemiesLeft += amount;
    }

    public static void RemoveEnemy()
    {
        enemiesLeft -= 1;
    }

    public static void ResetEnemies()
    {
        enemiesLeft = 0;
    }

    public static int GetEnemiesLeft()
    {
        return enemiesLeft;
    }
}
