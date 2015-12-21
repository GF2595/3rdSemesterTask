using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GamepadClientNamespace;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=391641

namespace GamepadSemester
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class GamepadPage : Page
    {
        public GamepadPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
            int buttonsAmount = (int)e.Parameter;
            ChangeButtonsAmount(buttonsAmount);
            }
            catch (InvalidCastException)
            { }
        }

        private void TurnPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage), ButtonsPanel.Children.Count);
        }

        private void ButtonPressed(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;

            int buttonNumber = 0;
            int.TryParse(pressedButton.Content.ToString(), out buttonNumber);

            if (pressedButton.Name == "AdditionalButton")
            {
                buttonNumber += 8;
            }

            ErrorBlock.Text = Mediator.Send(buttonNumber);
        }

        public void ChangeButtonsAmount(int amount)
        {
            ButtonsPanel.Children.Clear();

            for (int i = 0; i < amount; i++)
            {
                TextBlock tempTextBlock = new TextBlock();
                Button tempButton = new Button();
                StackPanel tempPanel = new StackPanel();
                tempTextBlock.Text = (i + 1).ToString();
                tempButton.Name = "AdditionalButton";
                tempButton.Template = ButtonTemplate;
                tempButton.Content = i + 1;
                tempButton.Click += ButtonPressed;
                tempPanel.Children.Add(tempTextBlock);
                tempPanel.Children.Add(tempButton);
                tempPanel.Width = tempButton.Width;
                tempTextBlock.Width = tempButton.Width;
                ButtonsPanel.Children.Add(tempPanel);
                ButtonsPanel.Width += tempButton.Width;
            }
        }
    }
}
