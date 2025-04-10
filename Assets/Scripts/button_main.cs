using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Публичное поле для указания сцены, на которую нужно перейти
    public string sceneName;

    // Метод для перехода на другую сцену
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}