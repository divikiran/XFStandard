using System;
using Xamarin.Forms;
using XForms.ViewModels;

namespace XForms
{
    public class BasePage : ContentPage
    {
        public BaseViewModel BaseViewModel
        {
            get;
            set;
        }

        public BasePage()
        {
            Title = string.Empty;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext != null && BindingContext is BaseViewModel)
            {
                BaseViewModel = (BaseViewModel)BindingContext;
                BaseViewModel.CurrentPage = this;
                BaseViewModel.Navigation = this.Navigation;

                SetPageProperties();

                await BaseViewModel?.OnAppearing();
            }
        }

        private void SetPageProperties()
        {
            this.SetBinding(TitleProperty, "Title");
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext != null && BindingContext is BaseViewModel)
            {
                BaseViewModel = (BaseViewModel)BindingContext;
                BaseViewModel.CurrentPage = this;
                BaseViewModel.Navigation = this.Navigation;
                await BaseViewModel?.OnDisappearing();
            }
        }
    }
}
