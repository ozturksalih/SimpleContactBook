using FinalProjectSalihOzturk.DataAccess;
using FinalProjectSalihOzturk.Helpers;

namespace FinalProjectSalihOzturk.Logic
{
    public class MainView:ObservableObject
    {
        private object _currentView;
        private BookViewLogic _bookViews;

        public MainView()
        {
            var dataAccess = new JsonContactDal();
            BookViewLogic = new BookViewLogic(dataAccess);
            CurrentView = BookViewLogic;
        }

        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        public BookViewLogic BookViewLogic
        {
            get { return _bookViews; }
            set { OnPropertyChanged(ref _bookViews, value); }
        }

    }
}