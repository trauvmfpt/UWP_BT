using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BT.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPage : Page
    {
        public AddPage()
        {
            this.InitializeComponent();
        }

        private async void AddFile(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.GetFileAsync("sample.txt");
        }

        private async void BtnSaveFile_Click(object sender, RoutedEventArgs e)
        {

            var fileName = this.FileName.Text;
            var content = this.Content.Text;

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile readfFile = await folder.GetFileAsync(fileName);
                await FileIO.AppendTextAsync(readfFile, content);

            }
            catch (Exception)
            {
                StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, content);
            }

        }
    }
}
