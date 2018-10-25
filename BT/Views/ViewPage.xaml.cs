using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public sealed partial class ViewPage : Page
    {
        public ObservableCollection<String> titleList = new ObservableCollection<String>();

        public ViewPage()
        {
            this.InitializeComponent();
        }
        
        private async void ViewPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            var readfFile = await folder.GetFilesAsync();
            foreach (var titleFile in readfFile)
            {
                titleList.Add(titleFile.Name);
            }
            
        }

        private async void showContent(object sender, SelectionChangedEventArgs e)
        {
            ComboBox bc = (ComboBox)sender;

            Debug.WriteLine(bc.SelectedValue);
            string fileName = bc.SelectedValue.ToString();
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            var readfFile = await folder.GetFileAsync(fileName);
            string a = await FileIO.ReadTextAsync(readfFile);
            content.Text = a;

            Debug.WriteLine(a);
        }
    }
}
