﻿// <copyright file="DesktopSettings.cs" company="Automate The Planet Ltd.">
// Copyright 2021 Automate The Planet Ltd.
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
namespace Bellatrix.Desktop.Configuration
{
    public class DesktopSettings
    {
        public bool ShouldStartLocalService { get; set; } = true;

        public string ServiceUrl { get; set; }

        public string Ip { get; set; }

        public int Port { get; set; }

        public int SleepInterval { get; set; }

        public int ElementToBeVisibleTimeout { get; set; }

        public int ElementToExistTimeout { get; set; }

        public int ElementToNotExistTimeout { get; set; }

        public int ElementToBeClickableTimeout { get; set; }

        public int ElementNotToBeVisibleTimeout { get; set; }

        public int ElementToHaveContentTimeout { get; set; }

        public int CreateSessionTimeout { get; set; }

        public int WaitForAppLaunchTimeout { get; set; }
    }
}
