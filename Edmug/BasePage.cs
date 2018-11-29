using System;
using Xamarin.Forms;

namespace Edmug
{
    public class BasePage : ContentPage
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext is IViewModel viewModel) viewModel.LoadData();
        }
    }
}
