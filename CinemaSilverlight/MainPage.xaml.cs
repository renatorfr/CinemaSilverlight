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

        }
    }
}