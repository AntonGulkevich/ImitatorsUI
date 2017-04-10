using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Command;
using ImitatorBrowserUi.Base;

namespace ImitatorBrowserUi.Pages
{
    public class QuickStartViewModel
    {
        public ObservableCollection<ImitatorHeader> QuickStartItems { get; set; }

        public void UpdateQuickStartItems(ImitatorHeader header)
        {
            QuickStartItems.Remove(QuickStartItems.Last());
            QuickStartItems.Insert(0, header);
        }

        public void AddQuickStartItem(uint imitatorId, string imitatorName, string pathInApplication)
        {
            QuickStartItems.Add(new ImitatorHeader { ImitatorId = imitatorId, ImitatorName = imitatorName, ImitatorImageSource = ImitatorHeader.LoadBitmapFromResource(pathInApplication) });
        }

        private void FillQuickStartItems()
        {
            AddQuickStartItem(1, "TestImitator", "Images/imitSample2.PNG");
            AddQuickStartItem(2, "TestImitator2", "Images/imitSample.PNG");
            for (int i = QuickStartItems.Count; i < 8; i++)
            {
                QuickStartItems.Add(new ImitatorHeader());
            }
        }
        public QuickStartViewModel()
        {
            QuickStartItems = new ObservableCollection<ImitatorHeader>();
            FillQuickStartItems();
        }
        private RelayCommand _selectionCommand = new RelayCommand(() => MessageBox.Show("ZZZ"));

        public RelayCommand SelectionCommand
        {
            get { return _selectionCommand; }
        }
    }



}
