using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{
    public Color CountdownColor = Color.blue;

    public Text countdownText;
    public Slider timer;
    //public GameObject timerFill;
    public float Countdown = 30;
    public float CurrentTime = 30;
    public void Start()
    {
        ResetCountdown();

        GameManager.OnHomeworkCompleted += ResetCountdown;
    }
    public void Update()
    {
        CurrentTime -= Time.deltaTime;
        int timeInt = (int)CurrentTime;
        if (timeInt == 0)
        {
            // we want to give a grade and change homework
            GameManager.HomeworkFailed();

            ResetCountdown();
        }

        timer.value = timeInt;
        countdownText.text = timeInt.ToString();
    }

    public void ResetCountdown()
    {
        CurrentTime = Countdown;
        timer.maxValue = Countdown;
    }
}
