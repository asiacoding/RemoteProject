using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Models.Base;
using BlueApp1.Control;

namespace BlueApp1.UIRemote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupScreenRemotely : ContentPage
    {
        string FillAllButton = "There are incomplete buttons. Please fill in all the buttons";
        string successfullyProject = "A new project has been created successfully";

        internal RemoteProjectModels _ProjectModels { get; set; } = new RemoteProjectModels();
        internal static IBlueServices blueServices { set; get; }
        public static IBlueServices BlueServices => blueServices ?? (blueServices = DependencyService.Get<IBlueServices>());

        public SetupScreenRemotely()
        {
            InitializeComponent();
            InitializePage();
        }

        public SetupScreenRemotely(RemoteProjectModels ProjectModels)
        {
            InitializeComponent();
            this._ProjectModels = ProjectModels;
            InitializePage();
        }

        void InitializePage()
        {
            
        }





        private async void PlusCodeInRemote(object sender, EventArgs e)
        {
            try
            {
                if (_ProjectModels == null)
                {
                    this.DisplayErrorAlert();
                    return;
                }

                //add here New Buttons 
                var Str = await DisplayPromptAsync("", "Create New Button", accept: "Create", placeholder: "Type The Name Button Layout ..", maxLength: 40, keyboard: Keyboard.Text);

                if (!string.IsNullOrEmpty(Str))
                {
                    AddNewModels(Str);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                this.SendAlert(ex.Message);//DisplayErrorAlert();
            }
        }

        void AddNewModels(string name)
        {
            ButtonsUI buttonsUI = new ButtonsUI(_ProjectModels.Guid, name);
            ControlButtons.Children.Add(buttonsUI);
        }

        private void btnSave(object sender, EventArgs e)
        {
            try
            {
                bool CheckButtonRemotes = true;
                int CountsButtons = 0;
                List<RemoteButtonModels> models = new List<RemoteButtonModels>();
                ControlButtons.Children.ToList().ForEach(item =>
                {
                    if (item is ButtonsUI GetTime)
                    {
                        if (GetTime.StutsMode)
                        {
                            CountsButtons++;
                            models.Add(GetTime.RemoteModels);
                        }
                        else
                        {
                            CheckButtonRemotes = false;
                            return;
                        }
                    }
                });

                if (CheckButtonRemotes && CountsButtons > 0)
                {
                    /* Save Code */

                    var MyBUtton = Models.Standard.Set.AddModel<RemoteProjectModels>.Add(_ProjectModels);
                    if (MyBUtton)
                    {
                        Models.Standard.Set.AddModel<RemoteButtonModels>.Add(models);
                        this.SendAlert(successfullyProject);
                        this.CloesPage(new List<Type>()
                        {
                            GetType(), //Delet this Page
                            typeof(AddingNewProject) // and Deleted AddingNewProject
                        });
                    }
                    else
                    {
                        this.DisplayErrorAlert();
                    }
                }
                else
                {
                    this.SendAlert(FillAllButton);
                }
            }
            catch (Exception ex)
            {
                this.SendAlert(ex.Message);
            }

        }


    }
}