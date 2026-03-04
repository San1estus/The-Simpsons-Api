using TheSimpsons.Pages;
using TheSimpsons.Services;

namespace TheSimpsons
{
    public partial class MainPage : ContentPage
    {
        private readonly IPersonajes personajes;
        private bool isLoaded = false;

        public MainPage(IPersonajes personajes)
        {
            InitializeComponent();
            this.personajes = personajes;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!isLoaded)
            {
                CargarMenu();
                isLoaded = true;
            }
        }

        private async void CargarMenu()
        {
            var resultado = await personajes.GetPersonajesAsync();

            Grid gridMenu = new Grid
            {
                ColumnSpacing = 5,
                RowSpacing = 5,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            for (int i = 0; i < 3; i++)
            {
                gridMenu.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = GridLength.Star
                });
            }

            int index = 0;

            foreach (var personaje in resultado)
            {
                int row = index / 3;
                int column = index % 3;

                if (gridMenu.RowDefinitions.Count <= row)
                {
                    gridMenu.RowDefinitions.Add(new RowDefinition
                    {
                        Height = GridLength.Auto
                    });
                }


                ImageButton imageButton = new ImageButton
                {
                    Source = $"https://cdn.thesimpsonsapi.com/200{personaje.PortraitPath}",
                    HeightRequest = 80,
                    WidthRequest = 80,
                    Aspect = Aspect.AspectFill
                };

                imageButton.Clicked += async (s, e) =>
                {
                    await Shell.Current.GoToAsync($"{nameof(DetallePage)}?id={personaje.Id}");
                };

                Grid.SetRow(imageButton, row);
                Grid.SetColumn(imageButton, column);
                gridMenu.Children.Add(imageButton);

                index++;
            }

            stcMenu.Children.Add(gridMenu);
        }
    }
}