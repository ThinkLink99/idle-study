using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public int RequiredWork = 100;
    public int CompletedWork = 0;

    public Slider progressBar;

    public void Start()
    {
        GameManager.OnHomeworkFailed += GameManager_OnHomeworkFailed;
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

        if (CompletedWork >= RequiredWork) CompleteHomework();
    }
    public void CompleteHomework()
    {
        GameManager.HomeworkComplete();
        GetHomework();
    }
}
