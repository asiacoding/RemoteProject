using Models.Base;
using Models.Standard.InterFaceing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp.EventsPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChannelsListPage : ContentPage
    {

        Models.Standard.Get.Channel channelobj = new Models.Standard.Get.Channel();
        public ChannelsListPage()
        {
            InitializeComponent();

            this.Appearing += ChannelsListPage_Appearing;
            ContactsList.ItemSelected += ContactsList_ItemSelected;
            channelobj = new Models.Standard.Get.Channel();
        }

        private void ChannelsListPage_Appearing(object sender, EventArgs e)
        {
            RefItemSource();
        }

        void RefItemSource()
        {
            ContactsList.ItemsSource = channelobj.GetAll();
        }

        private void ContactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Events
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            //if (ContactsList != null)
            //{

            //  //  ListsviewsCell.
            //}
            //    //  ListviewCell1..v.ca.BackgroundColor = Color.Transparent;
            //var viewCell = (ViewCell)sender;
            //if (viewCell.View != null)
            //{
            //    viewCell.View.BackgroundColor = Color.Red;
            //  //  lastCell = viewCell;
            //}
        }

        private void AddChannels(object sender, EventArgs e)
        {
            //ChannelName1

            if (ContactsList.IsVisible)
            {
                ContactsList.IsVisible = false;
                AddNewChannels.IsVisible = true;
                BtnSave.Text = "save channels";
                return;
            }

            if (string.IsNullOrEmpty(ChannelName.Text))
            {
                _ = ChannelName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(ChannelNumber.Text))
            {
                _ = ChannelNumber.Focus();
                return;
            }

            //Checked Name And Number
            var StrogeChannel = channelobj.Find(new ChannelModels() { Codes = ChannelNumber.Text }, TypesFindChaneelsModels.Codes);

            if (StrogeChannel == null)
            {
                this.DisplayErrorAlert();
                return;
            }

            if (StrogeChannel.Count == 0)
            {
                Save(new ChannelModels() { Image = "TVIcon", Name = ChannelName.Text, Class = "", Codes = ChannelNumber.Text, Pin = 0, });
            }
            else
            {
                this.SendAlert("This channel already exists");
            }
        }

        public void Save(ChannelModels channel)
        {
            bool StatisSave = Models.Standard.Set.AddModel<ChannelModels>.Add(channel);
            if (StatisSave)
            {
                RefItemSource(); //Ref Models

                ContactsList.IsVisible = true;
                AddNewChannels.IsVisible = false;
                BtnSave.Text = "Add channels";

            }
            else
            {
                this.DisplayErrorAlert();
            }
        }

      
    }
}