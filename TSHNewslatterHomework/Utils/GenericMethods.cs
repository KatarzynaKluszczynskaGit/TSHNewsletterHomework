using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSHNewsletterHomework.Utils
{
    static class GenericMethods
    {
        public static string GetAttriibuteValue(IWebElement element)
        {
            return element.GetAttribute("value"); ;
        }
    }
}
