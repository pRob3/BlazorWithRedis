using BlazorWithRedis.Data;
using BlazorWithRedis.Helpers;
using BlazorWithRedis.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWithRedis.Pages
{
    partial class FetchNamesSlow
    {
        [Inject] DatabaseContext Context { get; set; }
        [Inject] IDistributedCache Cache { get; set; }

        private List<User> slowData;
        private string loadLocation = string.Empty;
        private string isCacheData = string.Empty;

        private async Task LoadData()
        {
            string recordKey = "SlowData";
            slowData = null;
            loadLocation = null;

            slowData = await Cache.GetRecordAsync<List<User>>(recordKey);

            if (slowData is null)
            {
                SlowDataService slowDataService = new SlowDataService(Context);
                slowData = slowDataService.GetUsers();
                loadLocation = $"Loaded from db at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}";
                isCacheData = "";

                await Cache.SetRecordAsync(recordKey, slowData, TimeSpan.FromSeconds(10));
            }
            else
            {
                loadLocation = $"Loaded from Cache at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}";
                isCacheData = "text-danger";
            }
        }

    }
}

