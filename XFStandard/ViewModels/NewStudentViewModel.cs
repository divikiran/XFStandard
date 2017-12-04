using System;
using Xamarin.Forms;
using XForms.Data.Entities;
using XForms.Data.Interfaces;

namespace XForms.ViewModels
{
    public class NewStudentViewModel : BaseViewModel
    {
        public IStudentsRepository StudentRepo { get; private set; }
        public NewStudentViewModel(IStudentsRepository studentRepo)
        {
            Title = "New Student";
            StudentRepo = studentRepo;
        }
        string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        string _location;
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                RaisePropertyChanged();
            }
        }
        string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                RaisePropertyChanged();
            }
        }

        Command _saveStudentToLocalDb;
        public Command SaveStudentToLocalDb
        {
            get
            {
                return _saveStudentToLocalDb ?? (_saveStudentToLocalDb = new Command(SaveStudentAction));
            }
        }

        public int Id { get; set; }

        private async void SaveStudentAction(object obj)
        {
            if (this.Id == 0)
            {
                await StudentRepo.InsertAsync(new StudentsEntity() { Name = this.Name, Location = this.Location, Image = this.Image });
            }
            else
            {
                var student = await StudentRepo.GetByIdAsync(this.Id) as StudentsEntity;
                student.Name = this.Name;
                student.Location = this.Location;
                student.Image = this.Image;
                await StudentRepo.UpdateAsync(student);
            }
        }
    }
}
