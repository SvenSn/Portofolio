using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CadeaubonProject.Presentatielaag.Gui
{
    public class NavigatieButton : ButtonBase
    {
        static NavigatieButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigatieButton), new FrameworkPropertyMetadata(typeof(NavigatieButton)));
        }

        public static readonly DependencyProperty AfbeeldingSourceProperty =
            DependencyProperty.Register("AfbeeldingSource", typeof(ImageSource), typeof(NavigatieButton), new PropertyMetadata(null));

        public static readonly DependencyProperty TekstProperty =
           DependencyProperty.Register("Tekst", typeof(string), typeof(NavigatieButton), new PropertyMetadata(null));

        public static readonly DependencyProperty NavUriProperty =
           DependencyProperty.Register("NavUri", typeof(Uri), typeof(NavigatieButton), new PropertyMetadata(null));

        public ImageSource AfbeeldingSource
        {
            get { return (ImageSource)GetValue(AfbeeldingSourceProperty); }
            set { SetValue(AfbeeldingSourceProperty, value); }
        }


        public string Tekst
        {
            get { return (string)GetValue(TekstProperty); }
            set { SetValue(TekstProperty, value); }
        }


        public Uri NavUri
        {
            get { return (Uri)GetValue(NavUriProperty); }
            set { SetValue(NavUriProperty, value); }
        }


        public event EventHandler<Uri> NavigationRequested;

        protected override void OnClick()
        {
            base.OnClick();
            NavigationRequested?.Invoke(this, NavUri);
        }

    }
}
