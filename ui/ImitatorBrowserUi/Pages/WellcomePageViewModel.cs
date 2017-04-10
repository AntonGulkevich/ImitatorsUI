using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Dragablz;
using GalaSoft.MvvmLight;
using ImitatorBrowserUi.Base;

namespace ImitatorBrowserUi.Pages
{
    public class WellcomePageViewModel : ViewModelBase
    {
        #region constructors
        public WellcomePageViewModel()
        {
            InterTabClient = new DefaultInterTabClient();
            for (int i = 0; i < 100; i++)
            {
                TestListForSearch.Add($"TestItem {i}");
            }
        }

        #endregion

        #region public fields
        public List<string> TestListForSearch { get; } = new List<string>();
        public QuickStartViewModel MyQuickStartViewModel { get; set; } = new QuickStartViewModel();
        public ObservableCollection<TabContent> TabContents { get; } = new ObservableCollection<TabContent>();
        public IInterTabClient InterTabClient { get; }
        #endregion

        #region private fields
        private static string tabName = "Новая вкладка";
        private int _selectedItem = -1;
        #endregion

        #region public methods
        
        public static WellcomePageViewModel CreateWithSamples()
        {
            var res = new WellcomePageViewModel();
            res.TabContents.Add(new TabContent(tabName, new WellcomePage()));
            return res;
        }

        public static Func<TabContent> NewItemFactory
        {
            get { return () => new TabContent(tabName, new WellcomePage()); }
        }
        public int SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set(ref _selectedItem, value);
                if (_selectedItem > 0)
                {
                    ImitatorHeader hdr = new ImitatorHeader();
                    hdr.ImitatorId = (uint)_selectedItem;
                    hdr.ImitatorImageSource = ImitatorHeader.LoadBitmapFromResource("Images/imitSample2.png");
                    hdr.ImitatorName = TestListForSearch[_selectedItem];
                    MyQuickStartViewModel.UpdateQuickStartItems(hdr);
                }
            }
        }
        #endregion
    }
}
