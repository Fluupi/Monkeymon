using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Localizer : MonoBehaviour
{
    public List<GameObject> UIUpdateList;

    public List<LocalizedStringTable> localizedStringTable;

    [SerializeField] private Image englishFlag;
    [SerializeField] private Image frenchFlag;
    private bool active = false;

    private string localeTag = "locale";

    private void Start()
    {
        if(!PlayerPrefs.HasKey(localeTag))
            PlayerPrefs.SetInt(localeTag, 0);

        ChangeLocale(PlayerPrefs.GetInt(localeTag));
    }

    private IEnumerator SetUpFromSystemCoroutine()
    {
        yield return LocalizationSettings.InitializationOperation;
        ChangeLocale(PlayerPrefs.GetInt(localeTag));
    }

    public void SetUpFromSystem()
    {
        StartCoroutine(SetUpFromSystemCoroutine());
    }

    public void ChangeLocale(int localeID)
    {
        if (active == true)
            return;
        StartCoroutine(SetLocale(localeID));
        PlayerPrefs.SetInt(localeTag, localeID);
        UpdateVisual(localeID);
        StartCoroutine(UpdateUI());
    }

    private void UpdateVisual(int localeID)
    {
        if (englishFlag == null || frenchFlag == null)
        {
            Debug.LogWarning("Don't forget the flags");
            return;
        }

        switch (localeID)
        {
            case 0:
                englishFlag.color = Color.gray;
                frenchFlag.color = Color.white;
                break;

            case 1:
                englishFlag.color = Color.white;
                frenchFlag.color = Color.gray;
                break;

            default:
                Debug.LogError("Language Unknown");
                break;
        }
    }

    private IEnumerator UpdateUI()
    {
        foreach (GameObject element in UIUpdateList)
        {
            if (!element.activeSelf)
            {
                element.SetActive(true);
                yield return null;
                element.SetActive(false);
            }
        }
    }

    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }
}