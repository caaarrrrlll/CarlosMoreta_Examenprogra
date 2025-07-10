using CarlosMoreta_Examenprogra.ViewModels;

namespace CarlosMoreta_Examenprogra.Views;

public partial class LogsPage : ContentPage
{
    private LogsViewModel vm;

    public LogsPage()
    {
        InitializeComponent();
        vm = BindingContext as LogsViewModel;
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        vm.CargarLogs();
    }
}