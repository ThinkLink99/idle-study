using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Countdown
{
    [SerializeField] private Color CountdownColor = Color.blue;

    [SerializeField] private Slider timer;
    [SerializeField] private Image timerFill;
    [SerializeField] private float _maxTime = 30;
    [SerializeField] private float CurrentTime = 30;
    [SerializeField] private bool Paused = false;
    [SerializeField] private bool takingExam = false;

    public float TimerFillPercentage => CurrentTime / _maxTime;
    public bool TakingExam { get => takingExam; }

    public void Start()
    {
        timerFill.color = CountdownColor;
    }
    public void Update()
    {
        // If we are paused, we don't want time to keep ticking down
        if (Paused) return;

        CurrentTime -= Time.deltaTime;
        int timeInt = (int)CurrentTime;
        if (timeInt == 0)
        {
            if (takingExam)
                GameEvents.ExamFailed();
            else
                GameEvents.HomeworkFailed();
        }

        timer.value = CurrentTime;
        timerFill.fillAmount = TimerFillPercentage;
    }

    public void ResetCountdown(float timeAlloted)
    {
        takingExam = false;

        _maxTime = timeAlloted;
        CurrentTime = timeAlloted;
        timer.maxValue = timeAlloted;
    }
}
