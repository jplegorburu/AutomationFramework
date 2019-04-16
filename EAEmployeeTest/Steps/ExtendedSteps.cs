using EAAutoFramework.Base;
using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EAEmployeeTest.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NavigateSite();
            CurrentPage = GetInstance<HomePage>();
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            CurrentPage.As<HomePage>().CheckIfLoginExists();
        }

        [Then(@"I click (.*) link")]
        public void ThenIClickLink(string linkName)
        {
            if (linkName == "login")
                CurrentPage = CurrentPage.As<HomePage>().ClickLoginLink();
            else if (linkName == "employeeList")
                CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();

        }

        [Then(@"I click (.*) button")]
        public void ThenIClickButton(string buttonName)
        {
            if (buttonName == "login")
                CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
            else if (buttonName == "createNew")
                CurrentPage = CurrentPage.As<EmployeeListPage>().ClickCreateNew();
            else if (buttonName == "create")
                CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
        }

        [Given(@"I Delete employee '(.*)' before i start running test")]
        public void GivenIDeleteEmployeeBeforeIStartRunningTest(string employeeName)
        {
            LogHelpers.Write("DELETING form DB");
            //string query = "delete from Employee where Name= '" + employeeName + "'";
            //Settings.ApplicationCon.ExecuteQuery(query);
        }

    }
}
