using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ImitatorBrowserUi.Base
{
    public class ImitatorHeader : ViewModelBase
    {
        public ImitatorHeader()
        {
            _imitatorName = null;
            _imageSource = null;
            _imitatorId = 0;
        }

        ImitatorHeader(string imitatorName, uint imitatorid, string imitatorImageSource)
        {
            _imitatorName = imitatorName;
            _imitatorId = imitatorid;
            _imageSource = LoadBitmapFromResource(imitatorImageSource);
        }

        ~ImitatorHeader()
        {

        }

        private RelayCommand _myCommand = new RelayCommand(() => MessageBox.Show("ZZZ"));

        public RelayCommand MyCommand
        {
            get { return _myCommand; }
        }

        private string _imitatorName;

        public string ImitatorName
        {
            get { return _imitatorName; }
            set { _imitatorName = value; }
        }
        private uint _imitatorId;

        public uint ImitatorId
        {
            get { return _imitatorId; }
            set { _imitatorId = value; }
        }
        private ImageSource _imageSource;
        public ImageSource ImitatorImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }

        public static BitmapImage LoadBitmapFromResource(string pathInApplication, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }
            return new BitmapImage(new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute));
        }
    }
}
