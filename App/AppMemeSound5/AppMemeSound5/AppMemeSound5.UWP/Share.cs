using AppMemeSound5.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace AppMemeSound5.UWP
{
    public class Share : IShare
    {
        private string _filePath;
        private string _title;
        private string _message;
        private readonly DataTransferManager _dataTransferManager;

        public Share()
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(ShareTextHandler);
        }

        // MUST BE CALLED FROM THE UI THREAD
        public Task Show(string title, string message, string filePath)
        {
            var localFolder = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            filePath = System.IO.Path.Combine(localFolder, filePath);


            _title = title ?? string.Empty;
            _filePath = filePath;
            _message = message ?? string.Empty;

            DataTransferManager.ShowShareUI();

            return Task.FromResult(true);
        }

        private async void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;

            // Title is mandatory
            request.Data.Properties.Title = string.IsNullOrEmpty(_title) ? Windows.ApplicationModel.Package.Current.DisplayName : _title;

            DataRequestDeferral deferral = request.GetDeferral();

            try
            {
                if (!string.IsNullOrWhiteSpace(_filePath))
                {
                    StorageFile attachment = await StorageFile.GetFileFromPathAsync(_filePath);
                    List<StorageFile> storageItems = new List<StorageFile>() ;
                    storageItems.Add(attachment);
                    request.Data.SetStorageItems(storageItems);
                }
                request.Data.SetText(_message ?? string.Empty);
            }
            finally
            {
                deferral.Complete();
            }
        }
    }
}
