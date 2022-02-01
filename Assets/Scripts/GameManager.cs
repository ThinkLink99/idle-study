using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ClickerTextPrefab;
    [SerializeField] private Transform clickerTextBounds;

    [SerializeField] private TMPro.TextMeshProUGUI _schoolYearText;
    [SerializeField] private TMPro.TextMeshProUGUI _schoolYearWorkDone;

    private SchoolYearManager schoolYearManager;

    private void Start()
    {
        GameEvents.OnClick += GameEvents_OnClick;

        schoolYearManager = GetComponent<SchoolYearManager>();
    }

    private void GameEvents_OnClick(int amount)
    {
        var obj = Instantiate(ClickerTextPrefab);
        obj.GetComponent<RectTransform>().SetParent(clickerTextBounds, false);
        obj.GetComponent<TextMeshProUGUI>().text = $"+{amount}";
    }

    private void Update()
    {
        if (schoolYearManager.IsTakingExam)
        {
            _schoolYearText.text = "EXAM TIME";
            _schoolYearWorkDone.text = "";
        }
        else
        {
            _schoolYearText.text = schoolYearManager.CurrentSchoolYear.YearName;
            _schoolYearWorkDone.text = $"{schoolYearManager.WorkCompleted} / {schoolYearManager.CurrentSchoolYear.AssignmentsToNextYear}";
        }
    }
}
