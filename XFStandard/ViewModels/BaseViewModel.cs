using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XForms.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BasePage CurrentPage { get; internal set; }
        public INavigation Navigation { get; internal set; }

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public async virtual Task OnAppearing() { }
        public async virtual Task OnDisappearing() { }


    }
}
