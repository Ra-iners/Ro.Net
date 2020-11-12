using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ro.NET
{
    public class RobloxGroup : IDisposable
    {
        readonly WebClient web;

        public string Name;
        public ulong Id;
        public string OwnerUsername;
        public ulong OwnerId;
        public string EmblemUrl;
        public string Description;
        public Dictionary<int, string> Roles = new Dictionary<int, string>();

        public RobloxGroup(ulong GroupID)
        {
            web = new WebClient();
            string RAW_JSON;
            try
            {
                RAW_JSON = web.DownloadString($"http://api.roblox.com/groups/{GroupID}");
            }
            catch
            {
                RAW_JSON = "Error";
                return;
            }
            if(RAW_JSON == "Error")
            {
                Name = "N/A";
                Id = 0;
                OwnerUsername = "N/A";
                OwnerId = 0;
                EmblemUrl = "N/A";
                Description = "N/A";
                return;
            }
            dynamic JSON = JObject.Parse(RAW_JSON);
            Name = JSON.Name;
            Id = JSON.Id;
            OwnerUsername = JSON.Owner.Name;
            OwnerId = JSON.Owner.Id;
            EmblemUrl = JSON.EmblemUrl;
            Description = JSON.Description;

            foreach(var Role in JSON.Roles)
            {
                string RankName = Role.Name;
                int RankID = Role.Rank;
                if (!Roles.ContainsKey(RankID))
                {
                    Roles.Add(RankID, RankName);
                }
                else
                {
                    Debug.Write($"key already exists {RankID}; skipping...");
                }
            }

        }

        public void Dispose()
        {
            web.Dispose();
        }
    }
}
