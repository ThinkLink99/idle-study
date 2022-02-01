using System.Collections;
using UnityEngine;

public class SchoolYearManager : MonoBehaviour
{
    [SerializeField] private int _workCompleted = 0;

    public Player player;
    public SchoolYear[] schoolYears;

    public AssignmentProgress assignmentProgress;
    public Countdown countdown;

    public SchoolYear CurrentSchoolYear => player.currentSchoolYear;
    public float CurrentSchoolYearTimeAlloted => CurrentSchoolYear.TimeAlloted;
    public int RequiredAssignmentsToNextYear => CurrentSchoolYear.AssignmentsToNextYear;
    public bool PlayerHasCompletedAllWork => WorkCompleted == RequiredAssignmentsToNextYear;

    public int NextSchoolYear => CurrentSchoolYear.Year + 1;
    public bool NextSchoolYearExists => NextSchoolYear < schoolYears.Length;

    public int WorkCompleted { get => _workCompleted; }
    public bool IsTakingExam => assignmentProgress.TakingExam || countdown.TakingExam;

    void Start()
    {
        player.currentSchoolYear = schoolYears[0];

        assignmentProgress.Start();
        countdown.Start();

        ResetWork();

        GameEvents.OnHomeworkCompleted += GameEvents_OnHomeworkCompleted;
        GameEvents.OnHomeworkFailed += GameEvents_OnHomeworkFailed;

        GameEvents.OnExamPassed += GameEvents_OnExamPassed;
        GameEvents.OnExamFailed += GameEvents_OnExamFailed;
    }

    private void Update()
    {
        countdown.Update();
    }

    private void TakeExam()
    {
        _workCompleted = 0;
        GameEvents.TakeExam(
            CurrentSchoolYear.FinalExam.TimeAlloted,
            CurrentSchoolYear.FinalExam.RequiredWork);

        countdown.ResetCountdown(CurrentSchoolYear.FinalExam.TimeAlloted);
        assignmentProgress.GetExam(CurrentSchoolYear.FinalExam.RequiredWork);
    }
    private void ResetWork()
    {
        assignmentProgress.GetHomework(
                    CurrentSchoolYear.MinWorkRequired,
                    CurrentSchoolYear.MaxWorkRequired);

        countdown.ResetCountdown(CurrentSchoolYearTimeAlloted);
    }

    private void GameEvents_OnExamPassed()
    {
        if (NextSchoolYearExists)
        {
            player.currentSchoolYear = 
                schoolYears[NextSchoolYear];
        }

        ResetWork();
    }
    private void GameEvents_OnExamFailed()
    {
        _workCompleted--;
        ResetWork();
    }

    private void GameEvents_OnHomeworkCompleted()
    {
        _workCompleted++;

        if (PlayerHasCompletedAllWork) 
        {
            TakeExam();
            return;
        }
        ResetWork();
    }
    private void GameEvents_OnHomeworkFailed()
    {
        ResetWork();
    }
}