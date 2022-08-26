using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace IKISlanjeMailova
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //definiranje elemenata potrebnih za slanje email-a
            //podaci za prijavu definirani XPathom, sastavljanje emaila definirano css selektorima

            By user = By.XPath("//*[@id=\"identifierId\"]");
            By login = By.XPath("//*[@id=\"identifierNext\"]/div/button/span");
            By pass = By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input");
            By login2 = By.XPath("//*[@id=\"passwordNext\"]/div/button/span");
            By poruka = By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div/div");
            By primatelj = By.CssSelector("input.agP.aFw");
            By predmet = By.CssSelector("input.aoT");
            By sadrzaj = By.CssSelector("div.Am.Al.editable.LW-avf.tS-tW");
            By posalji = By.CssSelector("div.T-I.J-J5-Ji.aoO.v7.T-I-atl.L3");


            IWebDriver wd = new ChromeDriver();


            //test ulazi Gmail i stavlja prozor na full screen

            wd.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&passive=1209600&osid=1&continue=https%3A%2F%2Fmail.google.com%2Fmail%2Fu%2F0%2F&followup=https%3A%2F%2Fmail.google.com%2Fmail%2Fu%2F0%2F&emr=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
            wd.Manage().Window.Maximize();


            //unos email adrese i klik na dalje/sljedeće

            wd.FindElement(user).SendKeys("BogdanovicIKIrazgovor@gmail.com");
            wd.FindElement(login).Click();


            //test čeka 5 sekundi nakon čega unosi lozinku i klika prijavu

            wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            wd.FindElement(pass).SendKeys("IKI12345");
            wd.FindElement(login2).Click();


            //test čeka 5 sekundi dok se stranica učita 

            wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);



            //definira se petlja za slanje 10 mailova

            for(int i = 1; i <= 11; i++){

                //test unosi primatelja, predmet i sadržaj, zatim klika pošalji
                wd.FindElement(poruka).Click();

                wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                wd.FindElement(primatelj).SendKeys("tjakopec@ffos.hr");

                wd.FindElement(predmet).SendKeys("Selenium testiranje IKI razgovor");

                wd.FindElement(sadrzaj).SendKeys("Ovaj je mail generirao Selenium");

                wd.FindElement(posalji).Click();

                wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);





            }

            wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            wd.Quit();



        }
    }
}
