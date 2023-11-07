using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmberekLista
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Ember> lista = new List<Ember>();
		public MainWindow()
		{
			InitializeComponent();

			lista.Add(new Ember("Feri", 50));
			lista.Add(new Ember("Gyuri", 47));
			lista.Add(new Ember("Pál", 51));

			emberek.ItemsSource = lista;
		}

		private void addBtn_Click(object sender, RoutedEventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(nevTextBox.Text) && !string.IsNullOrWhiteSpace(korTextBox.Text))
			{
				try
				{
					Convert.ToInt32(korTextBox.Text);
				}
				catch (Exception)
				{
					MessageBox.Show("");
					throw;
				}
				lista.Add(new Ember(nevTextBox.Text, Convert.ToInt32(korTextBox.Text)));
				emberek.ItemsSource = lista;
			}
		}
	}
}
