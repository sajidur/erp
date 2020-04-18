using Core.Interface.Validation;
using Core.Interface.Service;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;

namespace Validation.Validation
{
    public class DivisionValidator : IDivisionValidator
    {

        public Division VHasUniqueCode(Division division, IDivisionService _divisionService)
        {
            return division;
        }

        public Division VHasUniqueName(Division division, IDivisionService _divisionService)
        {
            //if (String.IsNullOrEmpty(division.Name) || division.Name.Trim() == "")
            //{
            //    division.Errors.Add("Name", "Tidak boleh kosong");
            //}
            //else if (_divisionService.IsNameDuplicated(division))
            //{
            //    division.Errors.Add("Name", "Tidak boleh ada duplikasi");
            //}
            return division;
        }

        public Division VDontHaveEmployees(Division division, EmployeeService _employeeService)
        {
            //IList<Employee> employees = _employeeService.GetObjectsByDivisionId(division.Id);
            //if (employees.Any())
            //{
            //    division.Errors.Add("Generic", "Tidak boleh masih memiliki Employees");
            //}
            return division;
        }



        public bool ValidDeleteObject(Division division, EmployeeService _employeeService)
        {
          //  division.Errors.Clear();
            VDontHaveEmployees(division, _employeeService);
            return isValid(division);
        }

        public bool isValid(Division obj)
        {
         //   bool isValid = !obj.Errors.Any();
            return true;
        }

        public string PrintError(Division obj)
        {
            string erroroutput = "";
            //KeyValuePair<string, string> first = obj.Errors.ElementAt(0);
            //erroroutput += first.Key + "," + first.Value;
            //foreach (KeyValuePair<string, string> pair in obj.Errors.Skip(1))
            //{
            //    erroroutput += Environment.NewLine;
            //    erroroutput += pair.Key + "," + pair.Value;
            //}
            return erroroutput;
        }

    }
}
