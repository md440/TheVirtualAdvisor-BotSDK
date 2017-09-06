using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Chronic.Handlers;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis

namespace Bot_Application1.Dialogs
{
    [LuisModel("8a210827-4911-4db6-9881-6bf98e97ae95", "8afcebfa35a54a668d0f7550b4e300dd")]
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog(params ILuisService[] services) : base(services)
        {
        }

        /*   [LuisIntent("None")]
           public async Task NoneIntent(IDialogContext context, LuisResult result)
           {
               await context.PostAsync($"You have reached the none intent. You said: {result.Query}"); //
               context.Wait(MessageReceived);
           }*/

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "MyIntent" with the name of your newly created intent in the following handler
        [LuisIntent("MyIntent")]
        public async Task MyIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the MyIntent intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
        [LuisIntent("MyGPA")]
        public async Task MyGPA(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the myGPA intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
        [LuisIntent("Interact")]
        public async Task Interact(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the Interact intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
    }
}