using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lumemeem
{
    public partial class MainPage : ContentPage
    {
        private bool isMelted = false;
        public MainPage()
        {
            InitializeComponent();


        }
        private void Hide_Button_Clicked(object sender, EventArgs e)
        {
            Hat.IsVisible = false;
            Head.IsVisible = false;
            Body1.IsVisible = false;
            Body2.IsVisible = false;
            Label.Text = "Снеговик спрятан";
        }

        private void Show_Button_Clicked(object sender, EventArgs e)
        {
            Hat.IsVisible = true;
            Head.IsVisible = true;
            Body1.IsVisible = true;
            Body2.IsVisible = true;
            Label.Text = "Снеговик отображен";


        }

        private void Random_Button_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            Color color = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            Head.BackgroundColor = color;
            Body1.BackgroundColor = color;
            Body2.BackgroundColor = color;
            Label.Text = "Снеговик покрашен в случайный цвет";
        }

        private async void Melt_Button_Clicked(object sender, EventArgs e)
        {
            if (!isMelted)
            {
                Head.Opacity = 0.75;
                Body1.Opacity = 0.75;
                Body2.Opacity = 0.75;
                await Task.Run(() => Task.Delay(800));
                Head.Opacity = 0.50;
                Body1.Opacity = 0.50;
                Body2.Opacity = 0.50;
                await Task.Run(() => Task.Delay(800));
                Head.Opacity = 0.25;
                Body1.Opacity = 0.25;
                Body2.Opacity = 0.25;
                await Task.Run(() => Task.Delay(800));
                Head.Opacity = 0;
                Body1.Opacity = 0;
                Body2.Opacity = 0;

                Label.Text = "Таем снеговика";
            }
            else
            {
                Head.Opacity = 1.0;
                Body1.Opacity = 1.0;
                Body2.Opacity = 1.0;

                Label.Text = "Возвращаем снеговика к прежнему состоянию";
            }

            isMelted = !isMelted;
        }

        private async void Jump_Button_Clicked(object sender, EventArgs e)
        {
            await Head.TranslateTo(0, -10, 50, Easing.SinOut);
            await Head.TranslateTo(0, 0, 50, Easing.SinIn);

            await Body1.TranslateTo(0, -10, 50, Easing.SinOut);
            await Body1.TranslateTo(0, 0, 50, Easing.SinIn);

            await Body2.TranslateTo(0, -10, 50, Easing.SinOut);
            await Body2.TranslateTo(0, 0, 50, Easing.SinIn);

            Label.Text = "Снеговик прыгает";
        }
        private void RemoveHat_Button_Clicked(object sender, EventArgs e)
        {
            if (Hat.TranslationY == 0)
            {

                Hat.TranslationY = -Head.Height / 2;
                Label.Text = "Шляпа снята";
            }
            else
            {

                Hat.TranslationY = 0;
                Label.Text = "Шляпа одета";
            }

        }


    }


}
