using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ApiSample.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync(nameof(SendMessage), message);
        }

        

        public string currentGroup { get; set; }

        public async Task JoinGroup(string groupname)
        {
            currentGroup = groupname;   
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
            
            await SendToGroup(groupname, $"L'utilisateur avec l'id {Context.ConnectionId} has joined");
        }

        public async Task SendToGroup(string groupname, string message)
        {
            await Clients.Group(groupname).SendAsync(nameof(SendToGroup)+"_"+groupname,message);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, currentGroup);
            await SendToGroup(currentGroup, "Quelqu'un nous a quitté... Versons une petite larme");
        }
       
    }

    public class Message()
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public int MyProperty { get; set; }
    }
}
