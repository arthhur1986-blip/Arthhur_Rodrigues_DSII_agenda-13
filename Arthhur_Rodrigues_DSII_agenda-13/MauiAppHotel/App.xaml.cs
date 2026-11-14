namespace MauiAppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new Views.ContratacaoHospedagem())
        {
            BarBackgroundColor = Color.FromArgb("#123C42"),
            BarTextColor = Colors.White
        };
    }
}
