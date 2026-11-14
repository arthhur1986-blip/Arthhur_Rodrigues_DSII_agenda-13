using System.Globalization;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("pt-BR");
    private readonly Suite[] suites =
    [
        new("Standard", 180m),
        new("Conforto", 260m),
        new("Premium", 390m)
    ];

    public ContratacaoHospedagem()
    {
        InitializeComponent();
        Quarto.ItemsSource = suites.Select(suite =>
            $"{suite.Nome} · {suite.Diaria.ToString("C", Cultura)} por noite").ToList();

        CheckIn.MinimumDate = DateTime.Today;
        CheckIn.MaximumDate = CheckOut.MaximumDate.AddDays(-1);
        CheckIn.Date = DateTime.Today;
        CheckOut.MinimumDate = CheckIn.Date.AddDays(1);
        CheckOut.Date = CheckOut.MinimumDate;
    }

    private void AoMudarCheckIn(object sender, DateChangedEventArgs e)
    {
        if (CheckOut is null)
            return;

        CheckOut.MinimumDate = e.NewDate.AddDays(1);
    }

    private async void AoAvancar(object sender, EventArgs e)
    {
        if (Adultos.Value < 1 || Quarto.SelectedIndex < 0 || CheckOut.Date <= CheckIn.Date)
        {
            await DisplayAlert("Revise a estadia",
                "Informe pelo menos um adulto, selecione uma suíte e escolha uma saída posterior à entrada.",
                "OK");
            return;
        }

        Suite suite = suites[Quarto.SelectedIndex];
        await Navigation.PushAsync(new HospedagemContratada(
            suite.Nome, suite.Diaria, (int)Adultos.Value, (int)Criancas.Value, CheckIn.Date, CheckOut.Date));
    }

    private async void AoAbrirSobre(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }

    private sealed record Suite(string Nome, decimal Diaria);
}
