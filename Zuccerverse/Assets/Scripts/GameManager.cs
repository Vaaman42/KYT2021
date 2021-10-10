using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Properties

    int Index = 0;
    bool isInterviewInProgress = false;

    #endregion

    #region Serialized Fields

    [SerializeField] DialogManager DialogManager;
    [SerializeField] SoundManager SoundManager;
    [SerializeField] List<Person> Interviewees;
    [SerializeField] List<GameObject> Posts;
    [SerializeField] GameObject Chair;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySoft();
    }

    public void OnDoorClick()
    {
        if (isInterviewInProgress)
        {
            DialogManager.IntervieweeLeaving();
            Chair.transform.DetachChildren();
            Posts[Index].SetActive(false);
            isInterviewInProgress = false;
            Index++;
            //Show Feedback
        }
        else if (Index == Interviewees.Count)
        {
            Debug.Log("Fin de la démo");
        }
        else
        {
            var person = Instantiate(Interviewees[Index].gameObject);
            person.transform.SetParent(Chair.transform, false);
            Posts[Index].SetActive(true);
            DialogManager.NewPersonArrived(Interviewees[Index]);
            isInterviewInProgress = true;
        }
    }
}
