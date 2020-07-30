// <copyright file="EnsureExtensionsEventHandlers.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Desktop.Events;
using Bellatrix.Logging;
using ElementNotFulfillingEnsureConditionEventArgs = Bellatrix.Desktop.Ensures.ElementNotFulfillingEnsureConditionEventArgs;

namespace Bellatrix.Desktop
{
    public abstract class EnsureExtensionsEventHandlers
    {
        protected IBellaLogger Logger => ServicesCollection.Current.Resolve<IBellaLogger>();

        public virtual void SubscribeToAll()
        {
            EnsureControlExtensions.EnsuredIsCheckedEvent += EnsuredIsCheckedEventHandler;
            EnsureControlExtensions.EnsuredIsNotCheckedEvent += EnsuredIsNotCheckedEventHandler;
            EnsureControlExtensions.EnsuredDateIsEvent += EnsuredDateIsEventHandler;
            EnsureControlExtensions.EnsuredIsDisabledEvent += EnsuredIsDisabledEventHandler;
            EnsureControlExtensions.EnsuredIsNotDisabledEvent += EnsuredIsNotDisabledEventHandler;
            EnsureControlExtensions.EnsuredInnerTextIsEvent += EnsuredInnerTextIsEventHandler;
            EnsureControlExtensions.EnsuredIsSelectedEvent += EnsuredIsSelectedEventHandler;
            EnsureControlExtensions.EnsuredIsNotSelectedEvent += EnsuredIsNotSelectedEventHandler;
            EnsureControlExtensions.EnsuredTextIsNullEvent += EnsuredTextIsNullEventHandler;
            EnsureControlExtensions.EnsuredTextIsEvent += EnsuredTextIsEventHandler;
            EnsureControlExtensions.EnsuredTimeIsEvent += EnsuredTimeIsEventHandler;
            EnsureControlExtensions.EnsuredIsVisibleEvent += EnsuredIsVisibleEventHandler;
            EnsureControlExtensions.EnsuredIsNotVisibleEvent += EnsuredIsNotVisibleEventHandler;
            EnsureControlExtensions.EnsuredExceptionThrowedEvent += EnsuredExceptionThrowedEventHandler;
        }

        protected virtual void EnsuredExceptionThrowedEventHandler(object sender, ElementNotFulfillingEnsureConditionEventArgs arg)
        {
        }

        protected virtual void EnsuredIsVisibleEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredIsNotVisibleEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredTimeIsEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredTextIsNullEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredTextIsEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredIsSelectedEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredIsNotSelectedEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredInnerTextIsEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredIsDisabledEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredIsNotDisabledEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredDateIsEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredIsCheckedEventHandler(object sender, ElementActionEventArgs arg)
        {
        }

        protected virtual void EnsuredIsNotCheckedEventHandler(object sender, ElementActionEventArgs arg)
        {
        }
    }
}