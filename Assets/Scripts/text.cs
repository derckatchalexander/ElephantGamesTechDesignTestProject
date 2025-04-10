using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button myButton;  // Ссылка на кнопку
    public GameObject objectToDestroy;  // Ссылка на объект, который нужно уничтожить

    void Start()
    {
        // Привязываем метод к событию нажатия кнопки
        myButton.onClick.AddListener(DestroyObject);
    }

    void DestroyObject()
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }
}