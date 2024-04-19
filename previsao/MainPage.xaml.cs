using System.Reflection.Emit;

namespace previsao;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		TestaClima();
		PreencherTela();
	}
	results conclusão=new results();
	void TestaClima()
	{
		conclusão.temp=20;
	}
void PreencherTela()
{
	labelgrau.Text=conclusão.temp.ToString();
	labelcidade.Text=conclusão.city;
	labelnuvem.Text=conclusão.description;
	Labelcondition_code.Text=conclusão.condition_code;
	Labelcurrently.Text=conclusão.currently;
	Labelimg_id.Text=conclusão.img_id;
	labelumidade.Text=conclusão.humidity.ToString();
	labelchuva.Text=conclusão.rain.ToString();
	labelamanhecer.Text=conclusão.sunrise;
	labelanoitecer.Text=conclusão.sunset;
	labelforça=conclusão.wind_speedy;
	labeldirecao=conclusão.wind_direction.ToString();
	Labelwind_cardinal=conclusão.wind_cardinal;
	labellua=conclusão.moon_phase;
	Labelcloudiness=conclusão.cloudiness.ToString();

	
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

