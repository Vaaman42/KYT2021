using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        var person = Instantiate(Interviewees[1].gameObject);
        person.transform.SetParent(Chair.transform, false);
        Posts[1].SetActive(true);
        DialogManager.NewPersonArrived(Interviewees[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
