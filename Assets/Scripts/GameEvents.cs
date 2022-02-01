using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class GameEvents 
{
    public static bool shopOpen = false;
    public static bool utencilsOpen = false;

    public static event Action OnHomeworkCompleted;
    public static void HomeworkComplete()
    {
        OnHomeworkCompleted?.Invoke();
    }

    public static event Action OnHomeworkFailed;
    public static void HomeworkFailed()
    {
        OnHomeworkFailed?.Invoke();
    }

    public static event Action<int> OnClick;
    public static void Click(int amount)
    {
        OnClick?.Invoke(amount);
    }

    public static event Action<Utencil> OnUtencilPickup;
    public static void UtencilPickup(Utencil utencil)
    {
        OnUtencilPickup?.Invoke(utencil);
    }

    public static event Action<float, int> OnTakeExam;
    public static void TakeExam (float timeAlloted, int requiredWork)
    {
        OnTakeExam?.Invoke(timeAlloted, requiredWork);
    }

    public static event Action OnExamPassed;
    public static void ExamPassed ()
    {
        OnExamPassed?.Invoke();
    }

    public static event Action OnExamFailed;
    public static void ExamFailed()
    {
        OnExamFailed?.Invoke();
    }
}
