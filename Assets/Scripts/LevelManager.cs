using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static GameObject gameOverScreen;
    private static Text gameOverMessage;
    private static GameObject levelLayout;
    void Start()
    {
        LevelState.ResetEnemies();
        LevelState.AddEnemy(GameObject.FindGameObjectsWithTag("Enemy").Length);
        gameOverScreen = GameObject.Find("GameOverScreen");
        levelLayout = GameObject.Find("LevelLayout");
        gameOverMessage = GameObject.Find("GameOverMessage").GetComponent<Text>();
        gameOverScreen.SetActive(false);
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public static void NotifyEnemyDestroyed()
    {
        LevelState.RemoveEnemy();
        CheckIfEnemiesLeft();
    }

    private static void CheckIfEnemiesLeft()
    {
        if(LevelState.GetEnemiesLeft() <=0) ShowGameOverScreen("You Won");
    }

    public static void ShowGameOverScreen(string message)
    {
        levelLayout.SetActive(false);
        gameOverScreen.SetActive(true);
        gameOverMessage.text = message;
    }

}
