using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;

public class LanguageSwitcher : MonoBehaviour
{
    // Метод переключения языка по ID (например: "en", "ru")
    public void SetLanguageByID(string localeID)
    {
        StartCoroutine(SetLocaleByID(localeID));
    }

    IEnumerator SetLocaleByID(string localeID)
    {
        // Дожидаемся инициализации системы локализации
        yield return LocalizationSettings.InitializationOperation;

        // Создаём идентификатор нужного языка
        LocaleIdentifier targetLocaleID = new LocaleIdentifier(localeID);

        // Перебираем доступные локали
        foreach (Locale locale in LocalizationSettings.AvailableLocales.Locales)
        {
            if (locale.Identifier == targetLocaleID)
            {
                LocalizationSettings.SelectedLocale = locale;
                Debug.Log($"Язык переключен на: {localeID}");
                yield break;
            }
        }

        Debug.LogWarning($"Локаль с ID '{localeID}' не найдена!");
    }
}