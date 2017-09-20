using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Chronic.Handlers;
using Bot_Application1;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis

namespace Bot_Application1.Dialogs
{
    [LuisModel("8a210827-4911-4db6-9881-6bf98e97ae95", "a5aa4a436af34dc59aaa6fc0a6ea3578")]
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {

        public BasicLuisDialog(params ILuisService[] services) : base(services)
        {
        }
        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            String test = MessagesController.UserId;
            await context.PostAsync($"You have reached the none intent. You said: {result.Query} : {test}"); //
            context.Wait(MessageReceived);
        }

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "MyIntent" with the name of your newly created intent in the following handler
        [LuisIntent("DatesAndDeadlines")]
        public async Task DatesAndDeadlines(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the DatesAndDeadlines intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
        [LuisIntent("MyGPA")]
        public async Task MyGPA(IDialogContext context, LuisResult result)
        {
            //await context.PostAsync()
            await context.PostAsync($"Your GPA is: {GetGPA()}"); //
            context.Wait(MessageReceived);
        }
        [LuisIntent("Interact")]
        public async Task Interact(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the Interact intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
        [LuisIntent("Subjects")]
        public async Task Subjects(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the Subjects intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
        [LuisIntent("Professor")]
        public async Task Professor(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the Professor intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
        [LuisIntent("teaches")]
        public async Task teaches(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the teaches intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
        public double GetGPA()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            double GPA = 0;

            connetionString = ConfigurationManager.ConnectionStrings["SWENG500"].ToString();
            /*     sql = "select CASE when GRADE = 'A+' THEN 4.33 " +
                "WHEN GRADE = 'A' THEN 4.0 " +
                  "WHEN GRADE = 'A-' THEN 3.67 " +
                " ELSE 3.0 END AS GAP_CALC " +
                      " from AcademicHistory where studentID=1";
                      */
            sql = "select currentGPA from V_STUDENT_GPA where studentID=1";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine(ConfigurationManager.ConnectionStrings["SWENG500"].ToString());
                    Console.WriteLine(dataReader.GetValue(0));
                    GPA = Convert.ToDouble(dataReader.GetValue(0));
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
                Console.WriteLine(" ExecuteNonQuery in SqlCommand executed !!");
                return GPA;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
                return GPA;
            }
        }
    }
}