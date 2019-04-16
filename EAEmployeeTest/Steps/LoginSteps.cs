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
    public class LoginSteps : BaseStep
    {
        [When(@"I enter UserName and Password and click login")]
        public void WhenIEnterUserNameAndPasswordAndClickLogin(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage.As<LoginPage>().Login(data.UserName, data.Password);
        }

        [Then(@"I should see the username with hello")]
        public void ThenIShouldSeeTheUsernameWithHello()
        {
            if (CurrentPage.As<HomePage>().GetLoggedInUser().Contains("admin"))
                Console.WriteLine("Success Login");
            else
                Console.WriteLine("Unsuccessful Login");
            
        }


    }
}
