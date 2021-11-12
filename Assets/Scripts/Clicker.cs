using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public Color ProgressColor = Color.green;
    public Image progressFill;
    public GameObject ClickerTextPrefab;
    public Transform clickerTextBounds;

    public int RequiredWork = 100;
    public int CompletedWork = 0;

    

    public Slider progressBar;

    public void Start()
    {
        progressFill.color = ProgressColor;

        GetHomework();
        GameManager.OnHomeworkFailed += GameManager_OnHomeworkFailed;
    }
    private void Update()
    {
        
    }

    private void GameManager_OnHomeworkFailed()
    {
        GetHomework();
    }

    public void GetHomework()
    {
        CompletedWork = 0;
        progressBar.value = CompletedWork;
        RequiredWork = Random.Range(1, 100);
        progressBar.maxValue = RequiredWork;
    }
    public void Click ()
    {
        CompletedWork++;
        progressBar.value = CompletedWork;

        var obj = Instantiate(ClickerTextPrefab);
        obj.GetComponent<RectTransform>().SetParent(clickerTextBounds, false);

        if (CompletedWork >= RequiredWork) CompleteHomework();
    }
    public void CompleteHomework()
    {
        GameManager.HomeworkComplete();
        GetHomework();
    }
}
