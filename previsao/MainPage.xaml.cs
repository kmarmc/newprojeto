using System.Text.Json;

namespace previsao;

public partial class MainPage : ContentPage
{
	const string url="https://api.hgbrasil.com/weather7a18584f";
	Resposta resposta;
	public MainPage()
	{
		InitializeComponent();
		TestaClima();
	}
	async void AtualizaTempo()
	{
		try
		{
			var navegador = new HttpClient();
			var response = await navegador.GetAsync(url);
			if (response.IsSucessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(content);
			}	
			PreencherTela();
		}
		catch(Exception e)
		{

		}
	}
	void PreencherTela()
	{
		labelgrau.Text=resposta.results.temp.ToString();
		labelcidade.Text=resposta.results.city;
		labelnuvem.Text=resposta.results.description;
		Labelcondition_code.Text=resposta.results.condition_code;
		Labelcurrently.Text=resposta.results.currently;
		Labelimg_id.Text=resposta.results.img_id;
		labelumidade.Text=resposta.results.humidity.ToString();
		labelchuva.Text=resposta.results.rain.ToString();
		labelamanhecer.Text=resposta.results.sunrise;
		labelanoitecer.Text=resposta.results.sunset;
		labelforça=resposta.results.wind_speedy;
		labeldirecao=resposta.results.wind_direction.ToString();
		Labelwind_cardinal=resposta.results.wind_cardinal;
		labellua=resposta.results.moon_phase;
		Labelcloudiness=resposta.results.cloudiness.ToString();

		
		if (conclusão.currently == "dia")
		{
			if (conclusão.rain>= 8)
			imgfundo.Source ="diachuva.jpg";
			else if (conclusão.cloudiness>=8)
			imgfundo.Source ="nubladodia.jpg";
			else
			imgfundo.Source ="soldia.jpg";
		}
		else
		{
			if (conclusão.rain >= 8)
			imgfundo.Source ="raios.jpg";
			else if (conclusão.cloudiness>=8)
			imgfundo.Source ="nublado.jpg";
			else
			imgfundo.Source ="estrela.jpg";
		}
	}
}

