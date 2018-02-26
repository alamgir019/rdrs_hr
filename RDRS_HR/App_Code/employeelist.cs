using BaseHR.DATA;
using BaseHR.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for employeelist
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class employeelist : System.Web.Services.WebService
{

    public employeelist()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public List<Employee> FetchEmailList(string mail)
    {
        var emp = new Employee();
        var fetchEmail = emp.GetEmployeeList()
        .Where(m => m.Email.ToLower().StartsWith(mail));
        return fetchEmail.ToList();
    }
    [WebMethod]
    public List<EmpInfoDTO> GetEmployee(string empname)
    {
        DEmployee objEmpInfoMgr = new DEmployee();
        var emplist= objEmpInfoMgr.getEmployeeInfo("").Where(ee=>ee.EmpNameWithId.ToLower().Contains(empname)).ToList();
        return emplist;
    }

}

public class Employee
{
    public int ID { get; set; }
    public string Email { get; set; }

    public Employee()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Employee> GetEmployeeList()
    {
        List<Employee> empList = new List<Employee>();
        empList.Add(new Employee() { ID = 1, Email = "Mary@somemail.com" });
        empList.Add(new Employee() { ID = 2, Email = "John@somemail.com" });
        empList.Add(new Employee() { ID = 3, Email = "Amber@somemail.com" });
        empList.Add(new Employee() { ID = 4, Email = "Kathy@somemail.com" });
        empList.Add(new Employee() { ID = 5, Email = "Lena@somemail.com" });
        empList.Add(new Employee() { ID = 6, Email = "Susanne@somemail.com" });
        empList.Add(new Employee() { ID = 7, Email = "Johnjim@somemail.com" });
        empList.Add(new Employee() { ID = 8, Email = "Jonay@somemail.com" });
        empList.Add(new Employee() { ID = 9, Email = "Robert@somemail.com" });
        empList.Add(new Employee() { ID = 10, Email = "Krishna@somemail.com" });

        return empList;
    }

}

