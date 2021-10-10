using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    #region Properties

    private Person Interviewee;

    #endregion

    #region Serialized Fields

    [SerializeField] TextMeshProUGUI RecruiterDialog;
    [SerializeField] TextMeshProUGUI IntervieweeDialog;
    [SerializeField] Slider DialogTimer;
    [SerializeField] List<Button> BtnQuestions;

    #endregion

    private void Start()
    {
        ToggleDialog(false);
    }

    public void IntervieweeLeaving()
    {
        Interviewee = null;
        ToggleDialog(false);
        StopAllCoroutines();
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
        string message = "";
        switch (question)
        {
            case Question.Presentation:
                message = "Pouvez-vous vous présenter en quelques phrases?";
                break;
            case Question.WantedPost:
                message = "Pour quel job postulez-vous?";
                break;
            case Question.Experience:
                message = "Quelle est votre expérience dans ce secteur?";
                break;
            case Question.Motivation:
                message = "Pourquoi voulez-vous rejoindre notre entreprise?";
                break;
            case Question.Qualities:
                message = "Quelle est votre meilleure qualité?";
                break;
            case Question.Defaults:
                message = "Quel est votre plus gros défaut?";
                break;
            case Question.Serious:
                message = "Êtes-vous quelqu'un de sérieux?";
                break;
            case Question.Hobby:
                message = "Avez-vous un hobby?";
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
            yield return new WaitForSeconds(0.01f);
            time -= 0.01f;
            var value = time / 20f;
            DialogTimer.value = value;
        }
        ToggleDialog(false);
        StartCoroutine(ShowIntervieweeDialog(Interviewee.RanOutOfTime()));
    }
}
