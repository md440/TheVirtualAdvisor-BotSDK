using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot_Application1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Bot_Application1.Dialogs;
//using System.EnterpriseServices;

namespace Bot_Application1.Tests
{
    [TestClass()]
    public class MessagesControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            void Post(Activity activity)
            {
                await Conversation.SendAsync(activity, () => new BasicLuisDialog());
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void PostTest1()
        {
            Assert.Fail();
        }
    }
}