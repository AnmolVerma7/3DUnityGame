using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    bool gameHasEnded = false;

    public float restartDelay = 1;
    
    public void CompleteLevel() 
    {
        completeLevelUI.SetActive(true);
    }
    public void EndGame() 
    {

        if (gameHasEnded == false) 
        {
            gameHasEnded = true;
            // Debug.Log("Game Over");
            Invoke("Restart", restartDelay );
        }
    }

    void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
