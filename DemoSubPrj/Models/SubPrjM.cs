using Prism.Mvvm;

namespace DemoSubPrj.Models
{
    public class SubPrjM : BindableBase
    {


        public int Emp_id { get; set; }

        public string Emp_name { get; set; }

        public string Emp_pno { get; set; }

        public decimal? Emp_salary { get; set; }

        public string Emp_gender { get; set; }

        public int? Emp_age { get; set; }

        public string Emp_department { get; set; }

        public string Emp_designation { get; set; }
    }
}
