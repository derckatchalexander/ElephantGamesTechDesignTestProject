using UnityEngine;

public class ConstantFall : MonoBehaviour
{
    public float fallSpeed = 5f;  // Скорость падения
    public float maxAngle = 40f;  // Максимальный угол отклонения от оси Y

    private Rigidbody2D rb;

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
    }

    void FixedUpdate()
    {
        // Устанавливаем скорость падения (движение только по оси Y)
        rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Уничтожаем объект при столкновении
        Destroy(gameObject);
    }
}