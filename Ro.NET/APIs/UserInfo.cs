using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ro.NET
{
    public class RobloxUser : IDisposable
    {
        WebClient webClient;

        public string Username;
        public ulong Id;
        public bool IsOnline;

        public string Headshot;
        public string Avatar;
        public string Bust;

        private List<ulong> Groups = new List<ulong>();

        public RobloxUser(ulong UserId)
        {
            webClient = new WebClient();
            string RAW_JSON;
            try
            {
                RAW_JSON = webClient.DownloadString($"http://api.roblox.com/users/{UserId}");
            }
            catch
            {
                RAW_JSON = @"Bad Request";
            }
            if (RAW_JSON == "Bad Request")
            {
                Username = "Not Found";
                Id = 0;
                IsOnline = false;
                return;
            }
            dynamic JSON = JObject.Parse(RAW_JSON);

            Username = JSON.Username;
            Id = JSON.Id;
            IsOnline = JSON.IsOnline;

            Headshot = $"https://www.roblox.com/headshot-thumbnail/image?userId={Id}&width=420&height=420&format=png";
            Avatar = $"https://www.roblox.com/avatar-thumbnail/image?userId={Id}&width=420&height=420&format=png";
            Bust = $"https://www.roblox.com/bust-thumbnail/image?userId={Id}&width=420&height=420&format=png%20true";
        }
        public RobloxUser(string username)
        {
            webClient = new WebClient();
            string RAW_JSON;
            try
            {
                RAW_JSON = webClient.DownloadString($"http://api.roblox.com/users/get-by-username?username={username}");
            }
            catch
            {
                RAW_JSON = @"User not found";
            }
            if (RAW_JSON.Contains("User not found"))
            {
                Username = "Not Found";
                Id = 0;
                IsOnline = false;
                return;
            }
            dynamic JSON = JObject.Parse(RAW_JSON);
            
            Username = JSON.Username;
            Id = JSON.Id;
            IsOnline = JSON.IsOnline;

            Headshot = $"https://www.roblox.com/headshot-thumbnail/image?userId={Id}&width=420&height=420&format=png";
            Avatar = $"https://www.roblox.com/avatar-thumbnail/image?userId={Id}&width=420&height=420&format=png";
            Bust = $"https://www.roblox.com/bust-thumbnail/image?userId={Id}&width=420&height=420&format=png%20true";
        }

        public List<ulong> getUserGroups(ulong UserID)
        {
            webClient = new WebClient();
            string RAW_JSON;
            try
            {
                RAW_JSON = webClient.DownloadString($"http://api.roblox.com/users/{UserID}/groups");
            }
            catch
            {
                RAW_JSON = @"NotFound";
            }
            if (RAW_JSON.Contains("NotFound"))
            {

            }
            dynamic JSON = JsonConvert.DeserializeObject(RAW_JSON);
            
            foreach(var Group in JSON)
            {
                ulong groupId = Group.Id;
                Groups.Add(groupId);
            }

            return Groups;
        }
        public void Dispose()
        {
            webClient.Dispose();
        }
    }
}
