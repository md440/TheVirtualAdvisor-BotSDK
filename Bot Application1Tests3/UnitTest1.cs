using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Bot_Application1.Dialogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bot_Application1Tests3
{
    [TestClass]
    public class UnitTest1 : System.Web.Http.ApiController
    {
        [TestMethod]
        public void TestMethod1Async()
        {
            //Activity activity = new Activity();
            Activity activity = new Activity
            {
               // From = new ChannelAccount(),
                Text = "Hello",
                Type = ActivityTypes.Message
            };
            //activity.Type = ActivityTypes.Message;


            //Api
            async Task<HttpResponseMessage> testc()
            {
               await Conversation.SendAsync(activity, () => new BasicLuisDialog());
                System.Console.Write(activity.Text);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            //await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            var test1 =testc();
            System.Console.Write(test1);
               // return response;
            
        }
    }
}
