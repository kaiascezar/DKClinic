using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKClinic.Data
{
    public class Dao
    {
        public static CustomerDao Customer { get; } = new CustomerDao();
        public static DepartmentDao Department { get; } = new DepartmentDao();
        public static EmployeeDao Employee { get; } = new EmployeeDao();
        public static GenderDao Gender { get; } = new GenderDao();
        public static PositionDao Position { get; } = new PositionDao();
        public static QuestionDao Question { get; } = new QuestionDao();
        public static QuestionnareDao Questionnare { get; } = new QuestionnareDao();
        public static ResponseDao Response { get; } = new ResponseDao();
    }
}
