using BlazorWithRedis.Data;
using BlazorWithRedis.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
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

        private List<User> slowData;
        private string loadLoacation = string.Empty;
        private string isCacheData = string.Empty;

        private async Task LoadData()
        {
            slowData = null;
            SlowDataService slowDataService = new SlowDataService(Context);
            slowData = await Task.Run(() => slowDataService.GetUsers());

            loadLoacation = $"Loaded from db at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}";
            isCacheData = "";
        }
    }
}
