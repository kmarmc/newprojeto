namespace previsao;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		TestaClima();
		PreencherTela();
	}
	results bar=new results();
	void TestaClima()
	{
		bar.temp=20;
	}
void PreencherTela()
{
	labeltemp.Text=bar.temp.ToString();
	labelcity.Text=bar.city;
}

}

