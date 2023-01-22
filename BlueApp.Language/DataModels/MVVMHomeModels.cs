using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BlueApp.Language.DataModels
{
    public class MVVMHomeModels : INotifyPropertyChanged
    {
        private string DeletObject
        {
            set
            {
                //Run Commands
            }
        }
        public MVVMHomeModels()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private string volConnectButton;

        public string VolConnectButton { get => ""; set => DeletObject = value; }
        public string ValNewProject { set => DeletObject = value; get => "New Project"; }
        public string ValSetting { set => DeletObject = value; get => "Setting"; }
        public string ValDeletExRemotely { set => DeletObject = value; get => "Delete existing remotes"; }
        public string VolControlPanels1 { set => DeletObject = value; get => "Control Panels"; }
        public string VolTitlePage { set => DeletObject = value; get => "Magical Stick (IR)"; }
        public string VolExit { set => DeletObject = value; get => "Exit"; }

        //protected bool Text<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        //{
        //    if (!Equals(field, newValue))
        //    {
        //        field = newValue;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //        return true;
        //    }
        //
        //    return false;
        //}
        //
        //private string volTitlePage;
        //
        //public string VolTitlePage { get => volTitlePage; set => SetProperty(ref volTitlePage, value); }
   
        //public event PropertyChangedEventHandler PropertyChanged;//{ get; private set; }
        //
        //private string volControlPanels1 = "Control Panels";
        //public string VolControlPanels1 { get => volControlPanels1; set => SetProperty(ref volControlPanels1, value); }
        //
        //
        //private string valNewProject;
        //public string ValNewProject { get => valNewProject; set => SetProperty(ref valNewProject, value); }
        //
        //
        //private string valSetting;
        //public string ValSetting { get => valSetting; set => SetProperty(ref valSetting, value); }
        //
        //
        //
        //private string valDeletExRemotely;
        //public string ValDeletExRemotely { get => valDeletExRemotely; set => SetProperty(ref valDeletExRemotely, value); }
        //
        //
        //private string volexit;
        //public string VolExit { get => volexit; set => SetProperty(ref volexit, value); }
        //

    }

}

//Titla Lbl
//Control panels
//new project
//setting
//Delete existing remotes
//Exit