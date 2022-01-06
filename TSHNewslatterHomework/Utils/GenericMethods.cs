using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSHNewsletterHomework.Utils
{
    static class GenericMethods
    {
        public static string GetAttriibuteValue(IWebElement element, string attribute)
        {
            return element.GetAttribute(attribute); 
        }

        public static string GetTextValue(IWebElement element)
        {
            return element.Text;
        }

        public static bool ElementIsVisible(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch(NoSuchElementException)
            { 
                return false; 
            }
        }

        public static bool ElementIsChecked(IWebElement element)
        {
            try
            {
                return element.Selected;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
