using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonExamFunction
{
    public class FChoiceImage : IFChoiceImage
    { 
        private IDChoiceImage _iDChoiceImage;

        public FChoiceImage(IDChoiceImage iDChoiceImage)
        {
            _iDChoiceImage = iDChoiceImage;
        }

        #region CREATE
        public ChoiceImage Create(ChoiceImage choiceImage)
        {
            EChoiceImage eChoiceImage = EChoice(choiceImage);
            eChoiceImage = _iDChoiceImage.Create(eChoiceImage);
            return Choice(eChoiceImage);
        }
        #endregion

        #region READ
        public List<ChoiceImage> Read(int choiceId)
        {
            List<EChoiceImage> eChoices = _iDChoiceImage.List<EChoiceImage>(a => a.ChoiceId == choiceId);
            return Choices(eChoices);
        }

        public List<ChoiceImage> ReadForTakeExam(int choiceId)
        {
            List<EChoiceImage> eChoices = _iDChoiceImage.List<EChoiceImage>(a => a.ChoiceId == choiceId);
            return Choices(eChoices);
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        public void Delete(ChoiceImage choiceImage)
        {
            _iDChoiceImage.Delete(EChoice(choiceImage));
        }
        #endregion

        #region OTHER FUNCTION
        private List<ChoiceImage> Choices(List<EChoiceImage> eChoiceImages)
        {
            var returnChoices = eChoiceImages.Select(a => new ChoiceImage
            {
                ChoiceId = a.ChoiceId,
                ChoiceImageId = a.ChoiceImageId,

                Url = a.Url
            });

            return returnChoices.ToList();
        }

        private EChoiceImage EChoice(ChoiceImage choiceImage)
        {
            EChoiceImage returnEChoiceImage = new EChoiceImage
            {
                ChoiceId = choiceImage.ChoiceId,
                ChoiceImageId = choiceImage.ChoiceImageId,

                Url = choiceImage.Url
            };
            return returnEChoiceImage;
        }

        private ChoiceImage Choice(EChoiceImage eChoiceImage)
        {
            ChoiceImage returnChoiceImage = new ChoiceImage
            {
                ChoiceId = eChoiceImage.ChoiceId,
                ChoiceImageId = eChoiceImage.ChoiceImageId,

                Url = eChoiceImage.Url
            };
            return returnChoiceImage;
        }
        #endregion
    }
}
