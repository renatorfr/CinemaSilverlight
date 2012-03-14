using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using CinemaSL.Models;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace CinemaSL
{
    public partial class MainPage : UserControl
    {
        public ObservableCollection<Filme> Filmes = new ObservableCollection<Filme>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnIncluirFilme_Click(object sender, RoutedEventArgs e)
        {
            Filmes.Add(new Filme(txtFilme.Text, Convert.ToInt32(txtDuracao.Text)));

            cmbFilmes.DataContext = Filmes;
        }

        private void btnIncluirSecao_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Filme> filmesAntes = new ObservableCollection<Filme>(Filmes);

            int cmbSelectedIndex = cmbFilmes.SelectedIndex;

            foreach (Filme filme in filmesAntes)
            {
                if (filme.Nome.Equals((cmbFilmes.SelectedValue as Filme).Nome))
                {
                    int filmeIndex = filmesAntes.IndexOf(filme);

                    filme.AdicionarSecao(Convert.ToDateTime(txtSecao.Text));
                    Filmes[filmeIndex] = filme;
                }
            }

            cmbFilmes.SelectedIndex = cmbSelectedIndex;

            txtSecao.Text = string.Empty;
            txtSecao.Focus();
        }

        private void btnGerarTabela_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Filmes.Count; i++)
            {
                Filme filme = Filmes[i];

                TextBlock txtFilme = new TextBlock();
                txtFilme.Text = filme.Nome;
                Border brdFilme = new Border();
                brdFilme.Background = new SolidColorBrush(Colors.Cyan);
                brdFilme.Margin = new Thickness(5);
                brdFilme.Child = txtFilme;

                TextBlock txtDuracao = new TextBlock();
                txtDuracao.Text = filme.Duracao.ToString();
                Border brdDuracao = new Border();
                brdDuracao.Background = new SolidColorBrush(Colors.Yellow);
                brdDuracao.Margin = new Thickness(5);
                brdDuracao.Child = txtDuracao;

                StackPanel stackPanel = new StackPanel();
                stackPanel.Name = Filmes.IndexOf(filme).ToString();
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Margin = new Thickness(5);
                stackPanel.Children.Add(brdFilme);
                stackPanel.Children.Add(brdDuracao);

                foreach (DateTime secao in filme.Secoes)
                {
                    TextBlock txtSecao = new TextBlock();
                    txtSecao.Text = secao.ToShortTimeString();

                    Border brdSecao = new Border();
                    brdSecao.Background = new SolidColorBrush(Colors.Green);
                    brdSecao.Margin = new Thickness(5);
                    brdSecao.Child = txtSecao;

                    stackPanel.Children.Add(brdSecao);
                }

                ColumnDefinition coluna = new ColumnDefinition();
                coluna.Width = GridLength.Auto;
                coluna.MinWidth = 60;
                grdFilmesSecoes.ColumnDefinitions.Add(coluna);

                Grid.SetColumn(stackPanel, i);

                grdFilmesSecoes.Children.Add(stackPanel);
            }
        }
    }
}