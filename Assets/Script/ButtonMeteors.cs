using UnityEngine;
using UnityEngine.UI;  // Для работы с UI

public class ButtonObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  // Массив префабов объектов, которые могут появляться
    public Transform[] spawnPoints;      // Массив точек появления объектов
    public Button spawnButton;            // Ссылка на кнопку
    public int numberOfPointsToSpawn = 3; // Количество точек, из которых будет происходить спавн

    void Start()
    {
        // Назначаем обработчик события нажатия на кнопку
        spawnButton.onClick.AddListener(SpawnRandomObject);
    }

    // Метод для создания объектов в случайных точках
    void SpawnRandomObject()
    {
        if (objectsToSpawn.Length > 0 && spawnPoints.Length > 0)
        {
            // Создаем объект в нужном количестве случайных точек
            for (int i = 0; i < numberOfPointsToSpawn; i++)
            {
                // Выбираем случайный объект из массива объектов
                GameObject randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

                // Выбираем случайную точку из массива точек
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Создаем объект в выбранной точке
                Instantiate(randomObject, randomPoint.position, Quaternion.identity);
            }
        }
    }
}
