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

        //[SerializeField] AudioClip Voice;
        //[SerializeField] float VoicePitch;

        #endregion

        public Person()
        {
            annoyment = 0;
            QuestionAsked.Add(Question.Test1, false);
            QuestionAsked.Add(Question.Test2, false);
            QuestionAsked.Add(Question.Test3, false);
            QuestionAsked.Add(Question.Test4, false);
            QuestionAsked.Add(Question.Test5, false);
        }

        private bool WasQuestionAsked(Question question)
        {
            return QuestionAsked[question];
        }

        public string AskQuestion(Question question)
        {
            if (WasQuestionAsked(question))
            {
                return QuestionAlreadyAsked();
            }
            QuestionAsked[question] = true;
            return AnswerQuestion(question);
        }

        private string AnswerQuestion(Question question)
        {
            switch (question)
            {
                case Question.Test1:
                    return "Answer to Test1";
                case Question.Test2:
                    return "Answer to Test2";
                case Question.Test3:
                    return "Answer to Test3";
                case Question.Test4:
                    return "Answer to Test4";
                case Question.Test5:
                    return "Answer to Test5";
                default:
                    return "Default Answer";
            }
        }

        public string RanOutOfTime()
        {
            switch(annoyment++)
            {
                default:
                case 0:
                    return "... Is everything alright?";
                case 1:
                    return "Hello?";
                case 2:
                    return "Are we done, or...?";
                case 3:
                    LeaveInterview();
                    return "Ok, I guess we're done then. Goodbye.";
            }
        }

        private string QuestionAlreadyAsked()
        {
            switch(annoyment++)
            {
                default:
                case 0:
                    return "I think you already asked me that...";
                case 1:
                    return "You already asked that.";
                case 2:
                    return "Are you listening to me? I already answered that.";
                case 3:
                    LeaveInterview();
                    return "That's it, I'm leaving.";
            }
        }

        private void LeaveInterview()
        {
            //Leave Interview
        }
    }
}
