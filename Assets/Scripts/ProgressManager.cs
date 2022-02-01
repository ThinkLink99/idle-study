using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AssignmentProgress
{
    [SerializeField] private Color ProgressColor = Color.green;
    [SerializeField] private Image progressFill;

    [SerializeField] private Slider progressBar;

    [SerializeField] private int _requiredWork = 100;
    [SerializeField] private int _completedWork = 0;
    [SerializeField] private bool takingExam = false;

    public bool AssignmentFinished => _completedWork >= _requiredWork;
    public float AssignmentFillPercentage => (float)_completedWork / _requiredWork;
    public bool TakingExam { get => takingExam; }


    public void Start()
    {
        progressFill.color = ProgressColor;

        GameEvents.OnClick += GameEvents_OnClick;
    }
    private void GameEvents_OnClick(int amount)
    {
        _completedWork += amount;
        progressBar.value = _completedWork;

        progressFill.fillAmount = AssignmentFillPercentage;

        if (AssignmentFinished && !takingExam) 
            CompleteHomework();

        else if (AssignmentFinished && takingExam) 
            CompleteExam();
    }

    public void ResetProgress()
    {
        takingExam = false;
        _completedWork = 0;
        progressBar.value = _completedWork;
    }

    public void GetHomework(int min, int max)
    {
        ResetProgress();

        int minRequiredWork = min;
        int maxRequiredWork = max;

        _requiredWork = Random.Range(minRequiredWork, maxRequiredWork);
        progressBar.maxValue = _requiredWork;
    }
    public void CompleteHomework()
    {
        ResetProgress();
        GameEvents.HomeworkComplete();
    }

    public void GetExam(int workRequired)
    {
        ResetProgress();

        takingExam = true;

        _requiredWork = workRequired;
        progressBar.maxValue = _requiredWork;
    }
    private void CompleteExam()
    {
        ResetProgress();
        GameEvents.ExamPassed();
    }
}
