﻿using TruthORDrink.MVVM.Views;

namespace TruthORDrink
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            Services = serviceProvider;

            MainPage = new NavigationPage(new HomePage());
        }
    }
}