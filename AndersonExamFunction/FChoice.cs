using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonExamFunction
{
    public class FChoice : IFChoice
    {
        private IDChoice _iDChoice;

        public FChoice(IDChoice iDChoice)
        {
            _iDChoice = iDChoice;
        }

        #region CREATE
        public Choice Create(Choice question)
        {
            EChoice eChoice = EChoice(question);
            eChoice = _iDChoice.Create(eChoice);
            return (Choice(eChoice));
        }
        #endregion

        #region READ
        public List<Choice> Read(int questionId)
        {
            List<EChoice> eChoices = _iDChoice.List<EChoice>(a => a.QuestionId == questionId);
            return Choices(eChoices);
        }

        public List<Choice> ReadForTakeExam(int questionId)
        {
            List<EChoice> eChoices = _iDChoice.List<EChoice>(a => a.QuestionId == questionId);
            return Choices(eChoices);
        }
        #endregion

        #region UPDATE
        public Choice Update(Choice question)
        {
            var eChoice = _iDChoice.Update(EChoice(question));
            return (Choice(eChoice));
        }
        #endregion

        #region DELETE
        public void Delete(Choice Choice)
        {
            _iDChoice.Delete<EChoiceImage>(a => a.ChoiceId == Choice.ChoiceId);
            _iDChoice.Delete(EChoice(Choice));
        }
        #endregion

        #region OTHER FUNCTION
        private List<Choice> Choices(List<EChoice> eChoices)
        {
            var returnChoices = eChoices.Select(a => new Choice
            {
                Correct = a.Correct,

                ChoiceId = a.ChoiceId,
                QuestionId = a.QuestionId,

                Description = a.Description
            });

            return returnChoices.ToList();
        }

        private EChoice EChoice(Choice choice)
        {
            EChoice returnEChoice = new EChoice
            {
                Correct = choice.Correct,

                ChoiceId = choice.ChoiceId,
                QuestionId = choice.QuestionId,

                Description = choice.Description
            };
            return returnEChoice;
        }

        private Choice Choice(EChoice eChoice)
        {
            Choice returnChoice = new Choice
            {
                Correct = eChoice.Correct,

                ChoiceId = eChoice.ChoiceId,
                QuestionId = eChoice.QuestionId,

                Description = eChoice.Description
            };
            return returnChoice;
        }
        #endregion
    }
}
