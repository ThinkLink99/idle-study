using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scores
{
    public float PopQuizScore;
    public float HomeworkScore;
    public float FinalScore;
}

public class GradeManager : MonoBehaviour
{
    public List<Scores> scores;

    private void Start()
    {
        GameEvents.OnPopQuizBubblePopped += GameEvents_OnPopQuizBubblePopped;
        GameEvents.OnHomeworkCompleted += GameEvents_OnHomeworkCompleted;
        GameEvents.OnHomeworkFailed += GameEvents_OnHomeworkFailed;

        CreateNewScore();
    }

    private void GameEvents_OnHomeworkFailed()
    {
        ScoreHomework(0);
    }
    private void GameEvents_OnHomeworkCompleted(float time)
    {
        

        ScoreHomework(time);
    }

    private void GameEvents_OnPopQuizBubblePopped(float score)
    {
        var i = scores.Count - 1;
        scores[i].PopQuizScore = score;

        ReturnGrade(score);
    }
    private string ReturnGrade (float score)
    {
        if (score >= 90)
        {
            return "A";
        } 
        else if (score < 90 || score >= 80)
        {
            return "B";
        }
        else if (score < 80 || score >= 70)
        {
            return "C";
        }
        else if (score < 70 || score >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
    private void CreateNewScore()
    {
        scores.Add(new Scores());
    }
    private void GetFinalScore ()
    {
        var i = scores.Count - 1;
        scores[i].FinalScore = (scores[i].HomeworkScore + scores[i].PopQuizScore) / 2;

        GameEvents.AssignmentScored(scores[i].FinalScore);
    }
    private void ScoreHomework (float score)
    {
        var i = scores.Count - 1;
        scores[i].HomeworkScore = score;

        GetFinalScore();

        CreateNewScore();
    }
}
