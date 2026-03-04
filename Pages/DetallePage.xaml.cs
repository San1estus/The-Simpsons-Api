using TheSimpsons.Services;

namespace TheSimpsons.Pages;

[QueryProperty(nameof(PersonajeId), "id")]
public partial class DetallePage : ContentPage
{
    private readonly IPersonajes personajes;

    public DetallePage(IPersonajes personajes)
	{

		InitializeComponent();
        this.personajes = personajes;
    }

    public int PersonajeId { get; set; }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CargarPersonaje(PersonajeId);
    }

    private async void CargarPersonaje(int id)
    {
        var personaje = await personajes.GetPersonajeAsync(id);
        lblPersonaje.Text = personaje.Name;
        lblEdad.Text = personaje.Age.ToString();
    }
}