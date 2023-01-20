using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlueApp1
{
    internal class MVVMHomeModels 
    {
        private PropertyChangedEventHandler Propertychanged { set; get; }
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                Propertychanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private string newProject;

        public string NewProject
        {
            get => newProject;
            set => SetProperty(ref newProject, value);
        }
    }

}

//Titla Lbl
//Control panels
//new project
//setting
//Delete existing remotes
//Exit