using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] Person Interviewee;
    [SerializeField] TextMeshProUGUI RecruiterDialog;
    [SerializeField] TextMeshProUGUI IntervieweeDialog;
    [SerializeField] Slider DialogTimer;
    [SerializeField] List<Button> BtnQuestions;

    #endregion

    void OnStart()
    {
        NextDialog();
    }

    public void NewPersonArrived(Person newPerson)
    {
        Interviewee = newPerson;
    }

    public void AskQuestion(int question)
    {
        StopAllCoroutines();
        ToggleDialog(false);
        StartCoroutine(ShowRecruiterDialog((Question)question));
    }

    private void ToggleDialog(bool active)
    {
        foreach (var btn in BtnQuestions)
        {
            btn.gameObject.SetActive(active);
            DialogTimer.gameObject.SetActive(active);
        }
    }

    private IEnumerator ShowRecruiterDialog(Question question)
    {
        string message;
        switch (question)
        {
            case Question.Test1:
                message = "Question: Test 1";
                break;
            case Question.Test2:
                message = "Question: Test 2";
                break;
            case Question.Test3:
                message = "Question: Test 3";
                break;
            case Question.Test4:
                message = "Question: Test 4";
                break;
            case Question.Test5:
                message = "Question: Test 5";
                break;
            default:
                message = "Default message";
                break;
        }
        IntervieweeDialog.text = "";
        RecruiterDialog.text = "";
        foreach (var c in message.ToCharArray())
        {
            RecruiterDialog.text += c;
            yield return new WaitForSeconds(0.07f);
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(ShowIntervieweeDialog(Interviewee.AskQuestion(question)));
    }

    private IEnumerator ShowIntervieweeDialog(string message)
    {
        RecruiterDialog.text = "";
        IntervieweeDialog.text = "";
        foreach (var c in message.ToCharArray())
        {
            IntervieweeDialog.text += c;
            yield return new WaitForSeconds(0.07f);
        }
        yield return new WaitForSeconds(2f);
        NextDialog();
    }

    private void NextDialog()
    {
        ToggleDialog(true);
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        float time = 20f;
        while (time > 0)
        {
            yield return new WaitForSeconds(0.5f);
            time -= 0.5f;
            var value = time / 20f;
            Debug.Log(value);
            DialogTimer.value = value;
        }
        ToggleDialog(false);
        StartCoroutine(ShowIntervieweeDialog(Interviewee.RanOutOfTime()));
    }
}
