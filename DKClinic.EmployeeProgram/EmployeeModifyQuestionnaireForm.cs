using DKClinic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.EmployeeProgram
{
    public partial class EmployeeCheckResponseDiagnosis : Form
    {
        //public Employee ConnectedEmployee { get; set; }

        public EmployeeCheckResponseDiagnosis(Questionnare CurrentQuestionnare)
        {
            InitializeComponent();
            //판넬에 문진표 작성 내용 출력, 문진표 출력 내용은 CustomerQustionnareControl.cs 참고            

            //진단내용 작성기능 사용 권한 부여
            //if (ConnectedEmployee.PositionID == 3)// DocrotID == Employee.PositionID 간호사는 3, 간호사는 진단내용 작성 불가
            //{
            //    txbDiagnosis.Enabled = false;
            //}
            //else // 관리자(DoctorID = 1) 의사(DoctorID = 2) 는 작성가능
            //    txbDiagnosis.Enabled = true;
            

            //기존 작성된 진단 내용이 있을 시, 진단내용 출력
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);

        //    ConnectedEmployee = ((MainForm)ParentForm).ConnectedEmployee;
            
        //}

        //취소버튼
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"PositionID : {ConnectedEmployee.PositionID}");
            Close();
        }
    }
}
