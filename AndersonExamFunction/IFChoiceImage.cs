using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFChoiceImage
    {
        #region CREATE
        ChoiceImage Create(ChoiceImage ChoiceImage);
        #endregion

        #region READ
        List<ChoiceImage> Read(int choiceId);
        List<ChoiceImage> ReadForTakeExam(int choiceId);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        void Delete(ChoiceImage ChoiceImage);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
