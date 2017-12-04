using Xamarin.Forms;
using XForms.Data.Entities;
using XForms.ViewModels;

namespace XForms.Views
{
    public partial class StudentPage : BasePage
    {
        private NewStudentViewModel ViewModel;

        public StudentPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = App.Container.Resolve(typeof(NewStudentViewModel),"") as NewStudentViewModel;
        }

        public StudentsEntity CurrentStudent { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (CurrentStudent != null)
            {
                ViewModel.Title = "Edit Student";
                ViewModel.Id = CurrentStudent.Id;
                ViewModel.Name = CurrentStudent.Name;
                ViewModel.Location = CurrentStudent.Location;
                ViewModel.Image = CurrentStudent.Image;
            }
        }
    }
}
