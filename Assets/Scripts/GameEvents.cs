using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class GameEvents 
{
    public static event Action<float> OnTimerTick;
    public static event Action<float> OnHomeworkCompleted;
    public static event Action OnHomeworkFailed;
    public static event Action<int> OnClick;
    public static event Action<Utencil> OnUtencilPickup;
    public static event Action<float> OnPopQuizBubblePopped;
    public static event Action<float> OnAssignmentScored;

    public static bool shopOpen = false;
    public static bool utencilsOpen = false;

    public static void TimerTick (float value)
    {
        OnTimerTick?.Invoke(value);
    }
    public static void HomeworkComplete(float time)
    {
        OnHomeworkCompleted?.Invoke(time);
    }
    public static void HomeworkFailed()
    {
        OnHomeworkFailed?.Invoke();
    }
    public static void Click(int amount)
    {
        OnClick?.Invoke(amount);
    }
    public static void UtencilPickup(Utencil utencil)
    {
        OnUtencilPickup?.Invoke(utencil);
    }
    public static void PopQuizBubblePopped (float score)
    {
        OnPopQuizBubblePopped?.Invoke(score);
    }
    public static void AssignmentScored(float score)
    {
        OnAssignmentScored?.Invoke(score);
    }
}
