using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKClinic.Data
{
    public partial class Question : ICloneable
    {
        public string DepartmentName { get; set; }
        public string TypeName { get; set; }

        public object Clone()
        {
            Question question = new Question();
            question.QuestionID = QuestionID;
            question.DepartmentID = DepartmentID;
            question.Index = Index;
            question.Type = Type;
            question.Item = Item;
            question.ChoiceCount = ChoiceCount;
            question.Choices = Choices;
            question.Version = Version;
            return question;
        }
    }
}
