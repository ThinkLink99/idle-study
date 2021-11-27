using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public Player player;

    public Color ProgressColor = Color.green;
    public Image progressFill;

    public Slider progressBar;

    public GameObject ClickerTextPrefab;
    public Transform clickerTextBounds;

    public int RequiredWork = 100;
    public int CompletedWork = 0;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        progressFill.color = ProgressColor;
        GameEvents.OnClick += GameEvents_OnClick;
        GameEvents.OnTimerTick += GameEvents_OnTimerTick;

        GetHomework();
    }

    private void GameEvents_OnTimerTick(float value)
    {
        time = value;
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

        var max = player.Worth + (25 * player.ClickAmount);
        var min = max - (max / 2);
        //Debug.Log($"Max: {max}\nWorth: {player.Worth}\nClickAMount: {player.ClickAmount}");
        RequiredWork = Random.Range(min, max);
        progressBar.maxValue = RequiredWork;
    }
    public void CompleteHomework()
    {
        var a = time / 30;

        GetHomework();
        GameEvents.HomeworkComplete(a * 100);
    }
}
