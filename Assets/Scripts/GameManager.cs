using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class GameManager 
{
    public static event Action OnHomeworkCompleted;
    public static event Action OnHomeworkFailed;

    public static bool shopOpen = false;
    public static bool utencilsOpen = false;

    public static void HomeworkComplete()
    {
        OnHomeworkCompleted?.Invoke();
    }
    public static void HomeworkFailed()
    {
        OnHomeworkFailed?.Invoke();
    }
}
