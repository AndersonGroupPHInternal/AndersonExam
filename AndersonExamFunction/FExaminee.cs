using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AndersonExamFunction
{
    public class FExaminee : IFExaminee
    {
        private IDExaminee _iDExaminee;

        public FExaminee(IDExaminee iDExaminee)
        {
            _iDExaminee = iDExaminee;
        }

        #region CREATE
        public Examinee Create(Examinee examinee)
        {
            EExaminee eExaminee = EExaminee(examinee);
            eExaminee = _iDExaminee.Create(eExaminee);
            return Examinee(eExaminee);
        }
        #endregion

        #region READ
        public decimal Percentage(int examineeId)
        {
            return _iDExaminee.Percentage(examineeId);
        }

        public List<Examinee> Read()
        {
            List<EExaminee> eExaminees = _iDExaminee.List<EExaminee>(a => true);
            return Examinees(eExaminees);
        }

        public List<Examinee> Read(ExamineeFilter examineeFilter)
        {
            Expression<Func<EExaminee, bool>> predicate =
            a => (a.Firstname.Contains(examineeFilter.Name) || a.Middlename.Contains(examineeFilter.Name)) || a.Lastname.Contains(examineeFilter.Name);

 
             List<EExaminee> eExaminees = _iDExaminee.List(predicate);
             return Examinees(eExaminees);
         }
    #endregion

        #region UPDATE
    public Examinee Update(Examinee examinee)
        {
            var eExaminee = _iDExaminee.Update(EExaminee(examinee));
            return (Examinee(eExaminee));
        }
        #endregion

        #region DELETE
        public void Delete(int examineeId)
        {
            _iDExaminee.Delete<EExaminee>(a => a.ExamineeId == examineeId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<Examinee> Examinees(List<EExaminee> eExaminees)
        {
            var returnExaminees = eExaminees.Select(a => new Examinee
            {
                ExamineeId = a.ExamineeId,
                PositionId = a.PositionId,

                ReferenceCode = a.ReferenceCode,
                Lastname = a.Lastname,
                Firstname = a.Firstname,
                Middlename = a.Middlename
            });

            return returnExaminees.ToList();
        }

        private EExaminee EExaminee(Examinee examinee)
        {
            EExaminee returnEExaminee = new EExaminee
            {
                ExamineeId = examinee.ExamineeId,
                PositionId = examinee.PositionId,

                ReferenceCode = examinee.ReferenceCode,
                Lastname = examinee.Lastname,
                Firstname = examinee.Firstname,
                Middlename = examinee.Middlename
            };
            return returnEExaminee;
        }

        private Examinee Examinee(EExaminee eExaminee)
        {
            Examinee returnExaminee = new Examinee
            {
                ExamineeId = eExaminee.ExamineeId,
                PositionId = eExaminee.PositionId,

                ReferenceCode = eExaminee.ReferenceCode,
                Lastname = eExaminee.Lastname,
                Firstname = eExaminee.Firstname,
                Middlename = eExaminee.Middlename
            };
            return returnExaminee;
        }

        public List<Examinee> Read(int examineeId, string sortBy)
        {
            throw new NotImplementedException();
        }

        public List<Examinee> ReadAndersonPhEmployees()
        {
            throw new NotImplementedException();
        }

        public List<Examinee> ReadAssetHistory(int assetId, string sortBy)
        {
            throw new NotImplementedException();
        }

        public object Read(object examineeFilter)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
