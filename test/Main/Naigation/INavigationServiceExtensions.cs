using System;
using Prism.Common;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Navigation.Builder;

namespace test.Main.Naigation
{
    public interface INavService: INavigationService
    {

    }
    public class MyNavService : PageNavigationService, INavService
    {
        readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        IContainerProvider container;
        IContainerRegistry registry;
        public MyNavService(IContainerProvider container, IApplication application, IEventAggregator eventAggregator, IPageAccessor pageAccessor):
            base(container,application,eventAggregator,pageAccessor)
        {
            
            
        }
        public void RegisterViewMapping<V,VM>(Type viewModel, Type view)
        {
            _map.Add(viewModel, view);
        }
    }

    public static class INavigationServiceExtensions
	{
		public static async void AddTabAsync(this INavService navigationService, string name)
		{

            var currentPage = App.Current.MainPage;
            if (currentPage is TabbedPage tabbedPage)
            {
                ContainerLocator.Container.CreateScope();

                var tab = ContainerLocator.Container.Resolve<MainPage>();
                var vm = ContainerLocator.Container.Resolve<MainPageViewModel>();
                tab.BindingContext = vm;
                var autowire = ViewModelLocator.GetAutowireViewModel(tab);



                await MvvmHelpers.OnInitializedAsync(tab, null);
                tabbedPage.Children.Add(tab);
            }

            
        }
	}
}

