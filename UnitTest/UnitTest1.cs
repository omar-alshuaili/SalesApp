using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using csY2S2_cs_project;
using csY2S2_cs_project.Views.mangerScreenViews;
using System.Windows;
using System.Windows.Controls;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public static void MyClassInitialize(TestContext testContext)
        {
            //Create the application for resources.
            
        }

        [TestMethod]
        public void TestMethod1()
        {
            if (Application.Current == null)
            {
                App application = new App();

                #region Add Static Resources from the App.xaml

                Style s1 = new Style(typeof(Border));
                Style s2 = new Style(typeof(Border));
                

                Style s3 = new Style(typeof(TextBox));
                Style s4 = new Style(typeof(ComboBox));
                Style s5 = new Style(typeof(Button));

                application.Resources.Add("cards", s1);
                application.Resources.Add("borderInputs", s2);
                application.Resources.Add("inputs", s3);
                application.Resources.Add("theComboBox", s4);
                application.Resources.Add("panelButton", s5);

                



                #endregion
            }


            //Arrange
            addNewProduct newProduct = new addNewProduct();
            decimal exepected = 42;

            //Act
            var testingResult = newProduct.CalculateSellingPrice("30","40");

            //Assert
            Assert.AreEqual(exepected, testingResult);

        }
    }
}
