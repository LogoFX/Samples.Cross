using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Samples.Cross.Forms.Launcher;
using Samples.Cross.Forms.Presentation.Shell.ViewModels;
using Samples.Cross.Shared;
using UnhandledExceptionEventArgs = Windows.UI.Xaml.UnhandledExceptionEventArgs;

namespace Samples.Cross.UWP
{
    public sealed partial class App
    {        
        public App()
        {
            InitializeComponent();           
        }

        protected override void Configure()
        {
            ContainerContext.Registrator.RegisterInstance(ContainerContext.Registrator);
            ContainerContext.Registrator.RegisterSingleton<FormsApp>();
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            RegisterNavigationService(rootFrame);

        }

        private void RegisterNavigationService(Frame rootFrame, bool cacheViewModels = false, bool treatViewAsLoaded = false)
        {
            INavigationService navigationService = cacheViewModels ? new CachingFrameAdapter(rootFrame, treatViewAsLoaded) : new FrameAdapter(rootFrame, treatViewAsLoaded);
            ContainerContext.Registrator.RegisterInstance(navigationService);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;            

            Xamarin.Forms.Forms.Init(args);

            DisplayRootView<MainPage>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return ContainerContext.Adapter.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return ContainerContext.Adapter.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            ContainerContext.Adapter.BuildUp(instance);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return
                new[]
                {                    
                    //TODO: Needed for views to be registered - consider using this manually in the bootstrapper
                    typeof(ShellViewModel).Assembly
                };
        }

        protected override async void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            var dialog = new MessageDialog(e.Message, "An error has occurred");

            await dialog.ShowAsync();
        }
    }    
}
