using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{
    public Color CountdownColor = Color.blue;

    public Slider timer;
    public Image timerFill;
    public float Countdown = 30;
    public float CurrentTime = 30;
    public bool Paused = false;

    public void Start()
    {
        timerFill.color = CountdownColor;

        ResetCountdown();

        GameEvents.OnHomeworkCompleted += GameEvents_OnHomeworkCompleted; ;
    }

    private void GameEvents_OnHomeworkCompleted(float obj)
    {
        ResetCountdown();
    }

    public void Update()
    {
        // If we are paused, we don't want time to keep ticking down
        if (Paused) return;

        CurrentTime -= Time.deltaTime;
        GameEvents.TimerTick(CurrentTime);

        int timeInt = (int)CurrentTime;
        if (timeInt == 0)
        {
            // we want to give a grade and change homework
            GameEvents.HomeworkFailed();

            ResetCountdown();
        }

        timer.value = CurrentTime;
    }

    public void ResetCountdown()
    {
        CurrentTime = Countdown;
        timer.maxValue = Countdown;
    }
}
