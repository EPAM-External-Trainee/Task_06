﻿using NUnit.Framework;
using ResultsOfTheSession.ExcelWorker;
using ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport;
using ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport;
using ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport;
using ResultsOfTheSession.Reports.Enums;

namespace ResultsOfTheSessionNUnitTest.PreparationOfReportsNUnitTest
{
    public class PreparationOfReportsNUnitTests
    {
        private const string _connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;";

        [Test]
        public void ReportSessionResultForGroup_Test()
        {
            SessionResultForGroup sessionResultForGroup = new SessionResultForGroup(_connectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(2, SessionResultForGroupOrderBy.Assessment, true), @"..\..\..\..\ResultsOfTheSessionNUnitTest\PreparationOfReportsNUnitTest\Resources\SessionResultForGroup.xlsx");
        }

        [Test]
        public void ReportWithGroupMarks_Test()
        {
            SessionResultWithGroupMarks reportWithGroupMarks = new SessionResultWithGroupMarks(_connectionString);
            MyExcelWorker.WriteToExcel(reportWithGroupMarks.GetReportData(p => p.MaxAssessment, true), @"..\..\..\..\ResultsOfTheSessionNUnitTest\PreparationOfReportsNUnitTest\Resources\SessionResultWithGroupMarks.xlsx");
        }

        [Test]
        public void ReportExpelledStudents_Test()
        {
            ExpelledStudents expelledStudents = new ExpelledStudents(_connectionString);
            MyExcelWorker.WriteToExcel(expelledStudents.GetReportData(1), @"..\..\..\..\ResultsOfTheSessionNUnitTest\PreparationOfReportsNUnitTest\Resources\ExpelledStudents.xlsx");
        }
    }
}