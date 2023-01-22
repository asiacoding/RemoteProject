using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp.EventsPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpenProjectRemote : ContentPage
    {


        //public PickerList Menu_Top;

        public OpenProjectRemote()
        {
            InitializeComponent();
            init();
            //this.Child
        }

        public OpenProjectRemote(string GuidProject)
        {
            InitializeComponent();
            init(GuidProject);
            //this.Child
        }


        //CodeElment elment;
        internal void init(string Guid = "Null")
        {
            try
            {

                if (Guid == "Null") return;

                //ItemsMagicalCode

                var MyModels = Models.Standard.Get.ProjectModel<object>.GetByProject(Guid);
                ItemsMagicalCode.Children.Clear();
                if (MyModels.Status)
                {
                    var FinelProject = MyModels.Data.FirstOrDefault();
                    if (FinelProject != null)
                    {//FinelProject
                        ProjectName.Text = FinelProject.Name;
                        var MyButton = Models.Standard.Get.RemotesButton.GetByProject(FinelProject.Guid);
                        if (MyButton.Count > 0)
                        {
                            foreach (var item in MyButton.ToList())
                            {
                                Button button = new Button() { Text = item.Name, BackgroundColor = Color.FromHex("#75AE94"), TextColor = Color.White, CornerRadius = 20, };
                                button.Clicked += MagicalButtonSendingCode;
                                ItemsMagicalCode.Children.Add(button);
                            }
                        }
                    }
                }
                else
                {
                    this.CloesPage(new List<Type> { typeof(OpenProjectRemote) });
                }

                //Menu_Top = new PickerList();

                //HidePanel.Children.Add(Menu_Top);

                //Menu_Top.SelectedIndexChanged += Menu_Top_SelectedIndexChanged;
                //elment = CodeElment.NotFound;
                //  Menu_Top.Tital = "Menu";
            }
            catch (Exception ex)
            {
                this.SendAlert(ex.Message);
            }

        }




        //private void Menu_Top_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (elment == CodeElment.NotFound)
        //    {
        //        return;
        //    }

        //    if (elment == CodeElment.MainList)
        //    {
        //        var Index = Menu_Top.SelectedIndex;
        //    }
        //}

        //public enum CodeElment { NotFound = -1, MainList = 0, InRemote = 1 }

        //int Index = 0;

        //public class PickerList : Picker
        //{
        //    public PickerList(Grid dataLayout, string SetTitalStartControl = "")
        //    {
        //        this.IsVisible = false;
        //        this.IsEnabled = false;
        //        dataLayout.Children.Add(this);

        //        if (!string.IsNullOrEmpty(SetTitalStartControl))
        //            this.Tital = SetTitalStartControl;
        //    }

        //    public PickerList(string SetTitalStartControl = "")
        //    {
        //        this.IsVisible = false;
        //        this.IsEnabled = false;

        //        if (!string.IsNullOrEmpty(SetTitalStartControl))
        //            this.Tital = SetTitalStartControl;

        //    }

        //    public void ShowList()
        //    {
        //        this.Focus();
        //    }

        //    public string Tital
        //    {
        //        set => this.Tital = value;
        //        get => this.Tital;
        //    }

        //    public void SetList(string[] list)
        //    {
        //        this.ItemsSource = list;
        //    }



        //}

        private void SelectMenu(object sender, EventArgs e)
        {
            //  SetIndex();
            //   Menu_Top.ShowList();
        }

        //void SetIndex()
        //{
        //    if (Index == 0)
        //    {
        //        Menu_Top.ItemsSource = new[] { "Add", "Move", "Back" };
        //        //                Menu_Top.ItemsSource = new[] { "Add", "Move", "Back" };

        //    }
        //    else
        //    {
        //        Menu_Top.ItemsSource = new[] { "no More Code" };
        //    }
        //}

        private void MagicalButtonSendingCode(object sender, EventArgs e)
        {
            //Send Code
            //   GifAcoine();
            GifAcoine();
        }

        bool IsSendingCodes = false;

        async void GifAcoine()
        {


            try
            {

                if (!IsSendingCodes)
                {
                    IsSendingCodes = true;
                    await DoRunAminusons();
                    IsSendingCodes = false;
                }


            }
            catch (Exception)
            {
                GIFImageMagle.Rotation = 0;
                IsSendingCodes = false;
            }
        }

        private async Task DoRunAminusons()
        {
            await Task.Run(async () =>
            {


                bool Top = false, Bot = false, backtoCenter = false;
                int Speed = 0;

                do
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        GIFImageMagle.Rotation = Speed;
                    });
                    await Task.Delay(1);



                    if (!Top)
                    {
                        if (Speed > 44) { Top = true; }

                        Speed++;
                        continue;

                    }

                    if (!Bot)
                    {
                        if (Speed < -44) { Bot = true; }
                        Speed--;
                        continue;
                    }

                    if (!backtoCenter && Bot & Top)
                    {
                        if (Speed >= 0 && Speed <= 2) { backtoCenter = true; GIFImageMagle.Rotation = 0; }
                        Speed++;
                        continue;
                    }



                } while (!Top || !Bot || !backtoCenter);



            });
        }
    }

}

