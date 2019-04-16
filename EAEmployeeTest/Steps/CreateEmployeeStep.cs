using EAAutoFramework.Base;
using EAEmployeeTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EAEmployeeTest.Steps
{
    [Binding]
    class CreateEmployeeStep : BaseStep
    {
        [Then(@"I enter following details")]
        public void ThenIEnterFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage.As<CreateEmployeePage>().CreateEmployee(data.Name,
                data.Salary.ToString(), data.DurationWorked.ToString(), data.Grade.ToString(), data.Email);
        }

    }
}
