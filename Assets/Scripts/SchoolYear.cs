using UnityEngine;

[CreateAssetMenu(menuName = "Custom/New School Year", fileName = "NewSchoolYear")]
public class SchoolYear : ScriptableObject
{
    [SerializeField] private int _year;
    [SerializeField] private string _yearName;

    [SerializeField] private int _minWorkRequired;
    [SerializeField] private int _maxWorkRequired;

    [SerializeField] private int _timeAlloted;

    [SerializeField] private int _assignmentsToNextYear;

    [SerializeField] private FinalExam _finalExam;

    public int Year { get => _year; }
    public int MinWorkRequired { get => _minWorkRequired; }
    public int MaxWorkRequired { get => _maxWorkRequired; }
    public int TimeAlloted { get => _timeAlloted; }
    public int AssignmentsToNextYear { get => _assignmentsToNextYear; }
    public FinalExam FinalExam { get => _finalExam; }
}

[System.Serializable]
public class FinalExam
{
    [SerializeField] private int _timeAlloted;
    [SerializeField] private int _requiredWork;

    public int RequiredWork { get => _requiredWork; }
    public int TimeAlloted { get => _timeAlloted; }
}