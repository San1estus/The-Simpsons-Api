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
        await CargarPersonaje(PersonajeId);
    }

    private async Task CargarPersonaje(int id)
    {
        var personaje = await personajes.GetPersonajeAsync(id);

        if (personaje != null)
        {
            lblPersonaje.Text = personaje.Name ?? "Desconocido";
            lblEdad.Text = personaje.Age?.ToString() ?? "No especificada";
            lblOcupacion.Text = personaje.Occupation ?? "Desconocida";
            lblEstado.Text = personaje.Status ?? "Desconocido";
            lblDescripcion.Text = personaje.Description ?? "Sin descripción disponible.";

            if (!string.IsNullOrEmpty(personaje.PortraitPath))
            {
                imgPersonaje.Source = $"https://cdn.thesimpsonsapi.com/200{personaje.PortraitPath}";
            }
        }
    }
}