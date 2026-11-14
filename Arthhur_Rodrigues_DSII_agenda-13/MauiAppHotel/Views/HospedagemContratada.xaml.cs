using System.Globalization;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(string suite, decimal diaria, int adultos, int criancas,
                               DateTime entrada, DateTime saida)
    {
        InitializeComponent();
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        int noites = (saida.Date - entrada.Date).Days;
        Acomodacao.Text = $"Suíte {suite}";
        Hospedes.Text = $"Adultos: {adultos} · Crianças: {criancas}";
        Periodo.Text = $"{entrada.ToString("dd/MM/yyyy", cultura)} a {saida.ToString("dd/MM/yyyy", cultura)} ({noites} {(noites == 1 ? "noite" : "noites")})";
        ValorDiaria.Text = $"Diária: {diaria.ToString("C", cultura)}";
        Total.Text = $"Total: {(diaria * noites).ToString("C", cultura)}";
    }
}
