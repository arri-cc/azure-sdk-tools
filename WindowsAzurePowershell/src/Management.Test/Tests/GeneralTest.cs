﻿// ----------------------------------------------------------------------------------
//
// Copyright 2011 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.Test.Tests.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using Management.Cmdlets;
    using Management.Extensions;
    using Management.Services;
    using Management.Utilities;
    using Stubs;
    using TestData;
    using VisualStudio.TestTools.UnitTesting;
    using XmlSchema;
    using Microsoft.WindowsAzure.Management.Properties;

    [TestClass]
    public class GeneralTests
    {
        private const string _publishSettingsUrl = "http://manage.windowsazure.com/";
        private const string _azureHostNameSuffix = "the suffix";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // Set test environment variables
            Environment.SetEnvironmentVariable(Resources.PublishSettingsUrlEnv, _publishSettingsUrl);
            Environment.SetEnvironmentVariable(Resources.AzureHostNameSuffixEnv, _azureHostNameSuffix);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Delete test environment variables
            Environment.SetEnvironmentVariable(Resources.AzureHostNameSuffixEnv, null);
            Environment.SetEnvironmentVariable(Resources.PublishSettingsUrlEnv, null);
        }

        [TestMethod]
        public void TestPublishSettingsUrl()
        {
            string expected = _publishSettingsUrl;
            string actual = General.PublishSettingsUrl;

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void TestAzurePortalUrl()
        {
            string expected = Resources.AzurePortalUrl;
            string actual = General.AzurePortalUrl;

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void TestAzureWebsiteHostNameSuffix()
        {
            string expected = _azureHostNameSuffix;
            string actual = General.AzureWebsiteHostNameSuffix;

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void TestPublishSettingsUrlWithRealm()
        {
            string realm = "a realm";
            string expected = _publishSettingsUrl + "&whr=" + realm;
            string actual = General.PublishSettingsUrlWithRealm(realm);

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void TestBlobEndpointUri()
        {
            string accountName = "azure awesome account";
            string expected = string.Format(Resources.BlobEndpointUri, accountName);
            string actual = General.BlobEndpointUri(accountName);

            Assert.AreEqual<string>(expected, actual);
        }
    }
}