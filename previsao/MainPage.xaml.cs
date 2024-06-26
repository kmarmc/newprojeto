﻿using System.Text.Json;

namespace previsao;

public partial class MainPage : ContentPage
{
	const string url="https://api.hgbrasil.com/weather?woeid=455927&key=7a18584f";
	Resposta resposta;
	public MainPage()
	{
		InitializeComponent();
		TestaClima();
	}
	async void TestaClima()
	{
		try
		{
			var navegador = new HttpClient();
			var response = await navegador.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(content);
			}	
			PreencherTela();
		}
		catch(Exception e)
		{
          System.Diagnostics.Debug.WriteLine(e);
		}
	}
	void PreencherTela()
	{
		listaForecast.ItemsSource=resposta.results.forecast;
		labelgrau.Text=resposta.results.temp.ToString();
		labelCidade.Text=resposta.results.city;
		labelnuvem.Text=resposta.results.description;
		labelumidade.Text=resposta.results.humidity.ToString();
		labelchuva.Text=resposta.results.rain.ToString();
		labelamanhecer.Text=resposta.results.sunrise;
		labelanoitecer.Text=resposta.results.sunset;
		labelforça.Text=resposta.results.wind_speedy;
		labeldirecao.Text=resposta.results.wind_direction.ToString();
		labellua.Text=resposta.results.moon_phase;
		
		if (resposta.results.currently == "dia")
		{
			if (resposta.results.rain>= 8)
			imgfundo.Source ="diachuva.jpg";
			else if (resposta.results.cloudiness>=8)
			imgfundo.Source ="nubladodia.jpg";
			else
			imgfundo.Source ="soldia.jpg";
		}
		else
		{
			if (resposta.results.rain >= 8)
			imgfundo.Source ="raios.jpg";
			else if (resposta.results.cloudiness>=8)
			imgfundo.Source ="nublado.jpg";
			else
			imgfundo.Source ="estrela.jpg";
		}
		if (resposta.results.moon_phase=="new")
		    labellua.Text="Nova";
		else if (resposta.results.moon_phase=="full")
		    labellua.Text="Cheia";
		else if (resposta.results.moon_phase=="waning_gibbous")
		    labellua.Text="Gibosa minguante";
		else if (resposta.results.moon_phase=="waxing_crescent")
		    labellua.Text="Lua crescente";	
		else if (resposta.results.moon_phase=="first_quarter")
		    labellua.Text="Quarta crescente";
		else if (resposta.results.moon_phase=="waxing_gibbous")
		    labellua.Text="Gibosa crescente";
		else if (resposta.results.moon_phase=="last_quarter")
		    labellua.Text="Quarto minguante";
		else if (resposta.results.moon_phase=="waning_crescent")
		    labellua.Text="Lua minguante";								
	}
}

