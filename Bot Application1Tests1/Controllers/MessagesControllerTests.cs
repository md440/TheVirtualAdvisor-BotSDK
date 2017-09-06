using System.Net;
using System.Threading.Tasks;
using Bot_Application1.Dialogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bot_Application1.Tests
{
    [TestClass()]
    public class MessagesControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            async Task<HttpResponseMessage> Post([FromBody]Activity activity)
            {
                if (activity.Type == ActivityTypes.Message)
                {
                    //await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                    await Conversation.SendAsync(activity, () => new BasicLuisDialog());
                }
                else
                {
                    HandleSystemMessage(activity);
                }
                var response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            Assert.Fail();
        }
    }
}