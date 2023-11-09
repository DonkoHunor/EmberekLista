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
			if(string.IsNullOrWhiteSpace(nevTextBox.Text) || string.IsNullOrWhiteSpace(korTextBox.Text))
			{
				MessageBox.Show("Minden mezőt ki kell tölteni!");
				return;
			}
			else if(!int.TryParse(korTextBox.Text, out int temp))
			{
				MessageBox.Show("A kor csak szám lehet!");
				return;
			}
			else if(temp < 0 || temp > 200)
			{
				MessageBox.Show("A kornak 0 és 200 közöttinek kell lennie!");
				return;
			}
			else
			{
				lista.Add(new Ember(nevTextBox.Text.ToString(), Convert.ToInt32(korTextBox.Text.ToString())));
				emberek.Items.Refresh();
				nevTextBox.Text = "";
				korTextBox.Text = "";
			}
			

		}

		private void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			Ember elem = null;

			for (int i = 0;i < lista.Count;i++) 
			{
				if(lista[i] == emberek.SelectedItem)
				{
					elem = lista[i];
				}
			};

			if(elem != null && MessageBoxResult.Yes == MessageBox.Show("Biztos törli ezt az elemt: " + elem.Nev, "Törlés", MessageBoxButton.YesNo, MessageBoxImage.Stop) && elem != null)
			{
				lista.Remove(elem);
				emberek.Items.Refresh();
			}
			else if(elem == null)
			{
				MessageBox.Show("Nincs kiválasztva elem","Hiba",MessageBoxButton.OK,MessageBoxImage.Error);
			}			
		}
	}
}
