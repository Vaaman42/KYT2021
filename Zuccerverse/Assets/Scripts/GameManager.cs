using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Properties

    int Index = 0;
    List<Person> Recruited = new List<Person>();
    [NonSerialized] public bool isInterviewInProgress = false;
    Vector2 BasePosition;

    #endregion

    #region Serialized Fields

    [SerializeField] DialogManager DialogManager;
    [SerializeField] SoundManager SoundManager;
    [SerializeField] List<Person> Interviewees;
    [SerializeField] List<GameObject> Posts;
    [SerializeField] GameObject Chair;
    [SerializeField] RectTransform Content;
    [SerializeField] GameObject Tutorial;
    [SerializeField] GameObject EndScreen;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySoft();
        Tutorial.SetActive(true);
        BasePosition = Content.anchoredPosition;
    }

    public void OnDoorClick()
    {
        if (isInterviewInProgress)
        {
            StopInterview();
            SoundManager.PlaySoft();
            //Show Feedback
        }
        else if (Index == Interviewees.Count)
        {
            SoundManager.PlayTension2();
            EndGame();
        }
        else
        {
            Tutorial.SetActive(false);
            var person = Instantiate(Interviewees[Index].gameObject);
            person.transform.SetParent(Chair.transform, false);
            Posts[Index].SetActive(true);
            DialogManager.NewPersonArrived(Interviewees[Index]);
            isInterviewInProgress = true;
            Content.anchoredPosition = BasePosition;
            SoundManager.PlayStress();
        }
    }

    private void EndGame()
    {
        EndScreen.SetActive(true);
        foreach(var pers in Recruited)
        {
            EndScreen.transform.GetChild(pers.id).gameObject.SetActive(true);
        }
    }

    private void StopInterview()
    {
        DialogManager.IntervieweeLeaving();
        Chair.transform.DetachChildren();
        Posts[Index].SetActive(false);
        isInterviewInProgress = false;
        SoundManager.StopRecruiterVoice();
        SoundManager.StopIntervieweeVoice();
        Tutorial.SetActive(true);
        Index++;
    }

    public void RecruitInterviewee()
    {
        if (isInterviewInProgress)
        {
            Recruited.Add(Interviewees[Index]);
            StopInterview();
        }
    }
}
