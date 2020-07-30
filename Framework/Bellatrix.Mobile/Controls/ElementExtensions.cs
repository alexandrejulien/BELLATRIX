﻿// <copyright file="ElementExtensions.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System.Collections.Generic;
using Bellatrix.Mobile.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;

namespace Bellatrix.Mobile.IOS
{
    public static class ElementExtensions
    {
        public static bool ScrollToVisible<TElement>(this TElement element, string direction = "down")
            where TElement : Element<IOSDriver<IOSElement>, IOSElement>
        {
            int timeOut = 10000;

            while (!element.IsVisible && timeOut > 0)
            {
                MobileScroll(element, direction);
                timeOut -= 30;
            }

            bool isFound = element.IsVisible;

            return isFound;
        }

        private static void MobileScroll<TElement>(TElement element, string direction)
            where TElement : Element<IOSDriver<IOSElement>, IOSElement>
        {
            var js = (IJavaScriptExecutor)element.WrappedDriver;
            var swipeObject = new Dictionary<string, string>();
            if (direction.Equals("d"))
            {
                swipeObject.Add("direction", "down");
            }
            else if (direction.Equals("u"))
            {
                swipeObject.Add("direction", "up");
            }
            else if (direction.Equals("l"))
            {
                swipeObject.Add("direction", "left");
            }
            else if (direction.Equals("r"))
            {
                swipeObject.Add("direction", "right");
            }

            swipeObject.Add("element", element.WrappedElement.Id);
            js.ExecuteScript("mobile:swipe", swipeObject);
        }
    }
}