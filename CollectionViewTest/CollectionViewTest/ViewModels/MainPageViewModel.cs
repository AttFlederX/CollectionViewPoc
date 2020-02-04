using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;

namespace CollectionViewTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IActiveAware
    {
        private ObservableCollection<string> _imageList;
        private ObservableCollection<string> _storyList;

        private bool _isUpdating;

        public event EventHandler IsActiveChanged;

        public ObservableCollection<string> ImageList
        {
            get => _imageList;
            set => SetProperty(ref _imageList, value);
        }

        public ObservableCollection<string> StoryList
        {
            get => _storyList;
            set => SetProperty(ref _storyList, value);
        }

        public bool IsActive { get; set; }

        public DelegateCommand PullMoreImageCommand => new DelegateCommand(async () =>
        {
            if (IsActive && !_isUpdating)
            {
                Debug.WriteLine($"{DateTime.Now}: In PullMoreImageCommand");
                await AddImages();
            }
        });


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            ImageList = new ObservableCollection<string>();
            StoryList = new ObservableCollection<string>();
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            for (int i = 0; i < 15; i++)
            {
                StoryList.Add("https://placeimg.com/640/480/people");
            }

            await AddImages();
        }

        private async Task AddImages()
        {
            _isUpdating = true;

            var rnd = new Random();
            await Task.Delay(5000);

            for (int i = 0; i < 4; i++)
            {
                ImageList.Add("https://placeimg.com/640/480/any");
                ImageList.Add("https://placeimg.com/640/480/animals");
                ImageList.Add("https://placeimg.com/640/480/arch");
                ImageList.Add("https://placeimg.com/640/480/nature");
                ImageList.Add("https://placeimg.com/640/480/people");
                ImageList.Add("https://placeimg.com/640/480/tech");
            }

            _isUpdating = false;
        }

    }
}
