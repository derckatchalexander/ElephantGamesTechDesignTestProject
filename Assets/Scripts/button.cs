using UnityEngine;
using UnityEngine.UI;

public class ButtonImageSwitcher : MonoBehaviour
{
    public Sprite normalSprite;  // Изображение для обычного состояния
    public Sprite pressedSprite; // Изображение для состояния нажатия
    private Image buttonImage;   // Ссылка на компонент Image

    void Start()
    {
        buttonImage = GetComponent<Image>(); // Получаем компонент Image кнопки
    }

    // Этот метод будет вызываться при наведении на кнопку (состояние PointerEnter)
    public void OnPointerEnter()
    {
        buttonImage.sprite = normalSprite; // Устанавливаем обычное изображение
    }

    // Этот метод будет вызываться, когда кнопка будет нажата
    public void OnPointerDown()
    {
        buttonImage.sprite = pressedSprite; // Устанавливаем изображение для нажатой кнопки
    }

    // Этот метод будет вызываться, когда нажатие завершится (состояние PointerUp)
    public void OnPointerUp()
    {
        buttonImage.sprite = normalSprite; // Возвращаем изображение в обычное состояние
    }

    // Этот метод будет вызываться при выходе указателя из области кнопки (состояние PointerExit)
    public void OnPointerExit()
    {
        buttonImage.sprite = normalSprite; // Возвращаем изображение в обычное состояние
    }
}