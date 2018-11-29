using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Edmug
{
    public class MainViewModel : BaseViewModel
    {
        private List<Post> _posts;
        public List<Post> Posts 
        { 
            get => _posts; 
            set => SetProperty(ref _posts, value);
        }

        public ICommand LoadCommand => new Command(() => OnLoadCommand());

        public async void OnLoadCommand()
        {
            await RunSafeAsync(async () =>
            {
                await LoadPosts();
                IsRefreshing = false;
            });
        }

        public override async void LoadData()
        {
            await RunSafeAsync(async () =>
            {
                await LoadPosts();
            });
        }

        public async Task LoadPosts()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
                Posts = JsonConvert.DeserializeObject<List<Post>>(result);
            }
        }
    }
}
