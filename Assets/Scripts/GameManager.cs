using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ClickerTextPrefab;
    [SerializeField] private Transform clickerTextBounds;

    private void Start()
    {
        GameEvents.OnClick += GameEvents_OnClick;
    }

    private void GameEvents_OnClick(int amount)
    {
        var obj = Instantiate(ClickerTextPrefab);
        obj.GetComponent<RectTransform>().SetParent(clickerTextBounds, false);
        obj.GetComponent<TextMeshProUGUI>().text = $"+{amount}";
    }
}
