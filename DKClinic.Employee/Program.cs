using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DKClinic.Data;

namespace DKClinic.Employee
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DKClinicEntities.Initialize();
            Application.Run(new TestForm());
            //풀리퀘스트용 주석
        }
    }
}
