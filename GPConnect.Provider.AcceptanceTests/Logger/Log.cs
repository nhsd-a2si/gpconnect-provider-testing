﻿using System;
using System.Collections.Generic;
using GPConnect.Provider.AcceptanceTests.Helpers;
using TechTalk.SpecFlow;

namespace GPConnect.Provider.AcceptanceTests.Logger
{
    using Hl7.Fhir.Model;
    using LogBuffer = List<string>;

    [Binding]
    internal static class Log
    {

        public static void WriteLine(string message)
        {
            if (message == null) return;
            if (ScenarioContext.Current == null) return;

            if (!ScenarioContext.Current.ContainsKey(ScenarioLogKey))
                ScenarioContext.Current[ScenarioLogKey] = new LogBuffer();

            var log = (LogBuffer)ScenarioContext.Current[ScenarioLogKey];

            log.Add(message);
        }

        public static void WriteLine(string format, params object[] args)
        {
            if (format == null) return;
            if (ScenarioContext.Current == null) return;
            var message = args != null ? string.Format(format, args) : format;

            if (!ScenarioContext.Current.ContainsKey(ScenarioLogKey))
                ScenarioContext.Current[ScenarioLogKey] = new LogBuffer();

            var log = (LogBuffer)ScenarioContext.Current[ScenarioLogKey];

            log.Add(message);
        }

        internal static void WriteLine(Resource fhirResponseResource)
        {
            throw new NotImplementedException();
        }

        internal static void WriteLine(ResourceType resourceType)
        {
            throw new NotImplementedException();
        }

        internal static void WriteLine(Func<string> toString)
        {
            throw new NotImplementedException();
        }

        internal static void WriteLine(Bundle.EntryComponent entry)
        {
            throw new NotImplementedException();
        }

        [AfterScenario]
        public static void HandleScenarioFailure()
        {
            if (ScenarioContext.Current.TestError != null || AppSettingsHelper.TraceAllScenarios)
                DumpLog();
        }

        private static void DumpLog()
        {
            if (!ScenarioContext.Current.ContainsKey(ScenarioLogKey)) return;
            var log = (LogBuffer)ScenarioContext.Current[ScenarioLogKey];
            foreach (var message in log)
                Console.WriteLine(message);
        }

        private const string ScenarioLogKey = "ScenarioLog";
    }
}
