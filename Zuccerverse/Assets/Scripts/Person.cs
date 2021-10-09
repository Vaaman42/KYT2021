using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Person : MonoBehaviour
    {
        Dictionary<Question, bool> QuestionAsked = new Dictionary<Question, bool>();
        private int annoyment;

        #region Serialized Fields

        [SerializeField] List<string> Answers;
        [SerializeField] List<string> RanOutOfTimeMessages;
        [SerializeField] List<string> AlreadyAskedMessages;

        #endregion

        public Person()
        {
            annoyment = 0;
            QuestionAsked.Add(Question.Presentation, false);
            QuestionAsked.Add(Question.WantedPost, false);
            QuestionAsked.Add(Question.Experience, false);
            QuestionAsked.Add(Question.Motivation, false);
            QuestionAsked.Add(Question.Qualities, false);
            QuestionAsked.Add(Question.Defaults, false);
            QuestionAsked.Add(Question.Serious, false);
            QuestionAsked.Add(Question.Hobby, false);
        }

        private bool WasQuestionAsked(Question question)
        {
            return QuestionAsked[question];
        }

        public string AskQuestion(Question question)
        {
            if (WasQuestionAsked(question))
            {
                return AlreadyAskedMessages[annoyment >= AlreadyAskedMessages.Count ? annoyment++ : AlreadyAskedMessages.Count - 1];
            }
            QuestionAsked[question] = true;
            return Answers[(int)question];
        }

        public string RanOutOfTime()
        {
            return RanOutOfTimeMessages[annoyment >= RanOutOfTimeMessages.Count ? annoyment++ : RanOutOfTimeMessages.Count-1];
        }

        private void LeaveInterview()
        {
            //Leave Interview
        }
    }
}
