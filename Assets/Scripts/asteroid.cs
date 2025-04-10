using UnityEngine;

public class ConstantFall : MonoBehaviour
{
    public float fallSpeed = 5f;  // Скорость падения
    public float maxAngle = 40f;  // Максимальный угол отклонения от оси Y
    public GameObject prefab;  // Префаб, который будет создан

    private Rigidbody2D rb;
    private float lifetime = 10f;  // Время жизни объекта
    private float timer;  // Таймер для отслеживания времени жизни объекта

    void Start()
    {
        // Получаем ссылку на компонент Rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Генерируем случайный угол в пределах [-maxAngle, maxAngle]
        float randomAngle = Random.Range(-maxAngle, maxAngle);
        
        // Преобразуем угол в радианы
        float radians = randomAngle * Mathf.Deg2Rad;
        
        // Считаем случайное направление по оси X
        float xDirection = Mathf.Sin(radians);
        
        // Устанавливаем начальную скорость на оси X
        rb.velocity = new Vector2(xDirection * fallSpeed, -fallSpeed);

        // Инициализируем таймер
        timer = lifetime;
    }

    void FixedUpdate()
    {
        // Устанавливаем скорость падения (движение только по оси Y)
        rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
    }

    void Update()
    {
        // Отсчитываем время жизни объекта
        timer -= Time.deltaTime;

        // Если время жизни объекта истекло, уничтожаем его
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Уничтожаем объект при столкновении
        Destroy(gameObject);

        // Создаем префаб на том же месте, где был уничтоженный объект
        if (prefab != null)
        {
            // Создаем экземпляр префаба на позиции объекта
            GameObject newObject = Instantiate(prefab, transform.position, Quaternion.identity);

            // Уничтожаем созданный объект через 5 секунд
            Destroy(newObject, 5f);
        }

        // Сброс таймера (если столкновение произошло, таймер больше не будет использоваться)
        timer = 0f;
    }
}