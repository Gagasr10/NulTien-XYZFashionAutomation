// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Reporter;
// using System;
// using System.IO;

// namespace NulTien_XYZFashionAutomation.Utilities
// {
//     public static class ExtentManager
//     {
//         private static ExtentReports? extent;
//         private static ExtentHtmlReporter? htmlReporter;
//         private static string? reportPath;

//         public static ExtentReports GetInstance()
//         {
//             if (extent == null)
//             {
//                 string reportsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Reports");
//                 Directory.CreateDirectory(reportsDir);

//                 reportPath = Path.Combine(reportsDir, "TestReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
//                 htmlReporter = new ExtentHtmlReporter(reportPath);

//                 extent = new ExtentReports();
//                 extent.AttachReporter(htmlReporter);

//                 extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
//                 extent.AddSystemInfo("Tester", "Dragan Stojilkovic");
//                 extent.AddSystemInfo("Browser", ConfigReader.Browser);
//             }

//             return extent;
//         }

//         public static void FlushReport()
//         {
//             extent?.Flush();
//         }
//     }
// }
