using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Countdown
{
    [SerializeField] private Color CountdownColor = Color.blue;

    [SerializeField] private Slider timer;
    [SerializeField] private Image timerFill;
    [SerializeField] private float CurrentTime = 30;
    [SerializeField] private bool Paused = false;
    [SerializeField] private bool takingExam = false;

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
    }

    public void ResetCountdown(float timeAlloted)
    {
        takingExam = false;

        CurrentTime = timeAlloted;
        timer.maxValue = timeAlloted;
    }
}
