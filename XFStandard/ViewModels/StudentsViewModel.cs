using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XForms.Data.Entities;
using XForms.Data.Interfaces;
using XForms.Views;

namespace XForms.ViewModels
{
    public class StudentsViewModel : BaseViewModel
    {
        ObservableCollection<StudentsEntity> students;

        public ObservableCollection<StudentsEntity> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                RaisePropertyChanged();
            }
        }

        public IStudentsRepository StudentsRepo { get; private set; }

        public StudentsViewModel(IStudentsRepository studentRepo)
        {
            Title = "Students";
            StudentsRepo = studentRepo;
            NavigateToNewStudentPageCommand = new Command(async (obj) => await SelectedStudentAction(obj));
            SelectedStudentCommand = new Command(async (obj) => { await SelectedStudentAction(obj); });
        }

        private async Task SelectedStudentAction(object obj)
        {
            var student = obj as StudentsEntity;
            await Navigation.PushAsync(new StudentPage() { CurrentStudent = student });
        }

        private async Task NavigateToNewStudentPageAction(object obj)
        {
            await Navigation.PushAsync(new StudentPage());
        }

        public async override Task OnAppearing()
        {
            var studentsCollection = await StudentsRepo.GetAllAsync();
            Students = new ObservableCollection<StudentsEntity>(studentsCollection);
        }

        public Command NavigateToNewStudentPageCommand { get; set; }
        public Command SelectedStudentCommand { get; set; }
    }
}