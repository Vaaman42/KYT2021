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
    [SerializeField] GameObject Chair;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        var person = Instantiate(Interviewees[0].gameObject);
        person.transform.SetParent(Chair.transform, false);
        DialogManager.NewPersonArrived(Interviewees[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
