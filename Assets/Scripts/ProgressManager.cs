using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public Color ProgressColor = Color.green;
    public Image progressFill;

    public Slider progressBar;

    public GameObject ClickerTextPrefab;
    public Transform clickerTextBounds;

    public int RequiredWork = 100;
    public int CompletedWork = 0;

    // Start is called before the first frame update
    void Start()
    {
        progressFill.color = ProgressColor;
        GameEvents.OnClick += GameEvents_OnClick;
    }

    private void GameEvents_OnClick(int amount)
    {
        var obj = Instantiate(ClickerTextPrefab);
        obj.GetComponent<RectTransform>().SetParent(clickerTextBounds, false);
        obj.GetComponent<TextMeshProUGUI>().text = $"+{amount}";

        CompletedWork += amount;
        progressBar.value = CompletedWork;
        if (CompletedWork >= RequiredWork) CompleteHomework();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHomework()
    {
        CompletedWork = 0;
        progressBar.value = CompletedWork;
        RequiredWork = Random.Range(1, 100);
        progressBar.maxValue = RequiredWork;
    }
    public void CompleteHomework()
    {
        GetHomework();
        GameEvents.HomeworkComplete();
    }
}
