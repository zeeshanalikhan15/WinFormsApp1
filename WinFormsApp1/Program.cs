using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Runtime;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp1
{
    internal static class Program
    {
        private static readonly Settings settings = new Settings();
        private static readonly DataManager dataManager = new DataManager(settings);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // Add sample data
            await dataManager.AddTestDataAsync(new TestDataEntity { Name = "Test 1", Description = "This is a test" });
            await dataManager.AddTestDataAsync(new TestDataEntity { Name = "Test 2", Description = "This is another test" });

            // Get all test data
            var testData = await dataManager.GetAllTestDataAsync();

            // Print the test data
            foreach (var data in testData)
            {
                Console.WriteLine($"Id: {data.Id}, Name: {data.Name}, Description: {data.Description}");
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}