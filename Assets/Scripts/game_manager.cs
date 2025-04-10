using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject loseWindow;
    public GameObject winWindow;
    public GameObject Text;

   

    public static GameManager instance;

    private void Start()
    {
        instance = this;
    }
    public void RestartScene() 
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     Time.timeScale = 1;
    }   

    public void Lose()
    {
        loseWindow.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
       
        Text.gameObject.SetActive(false);
        
    }
      public void Win()
    {
          winWindow.gameObject.SetActive(true);
          Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
      
        Time.timeScale = 0;
        Text.gameObject.SetActive(false);
    }
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
