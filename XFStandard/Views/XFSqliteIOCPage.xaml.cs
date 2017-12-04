using XForms.ViewModels;

namespace XForms.Views
{
    public partial class XFSqliteIOCPage : BasePage
    {
        public StudentsViewModel ViewModel { get; private set; }
        public XFSqliteIOCPage()
        {
            //ViewModel = App.Container.Resolve<StudentsViewModel>();
            InitializeComponent();
            BindingContext = ViewModel = App.Container.Resolve(typeof(StudentsViewModel),"StudentsViewModel") as StudentsViewModel;//.Resolve<StudentsViewModel>();
        }
    }
}
