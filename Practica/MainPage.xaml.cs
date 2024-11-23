using System;
using Microsoft.Maui.Controls;

namespace Practica
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Evento para actualizar el resumen cuando se selecciona un monto
            JRad_Monto3.CheckedChanged += UpdateSummary;
            JRad_Monto5.CheckedChanged += UpdateSummary;
            JRad_Monto10.CheckedChanged += UpdateSummary;
        }

        private async void JBtn_Recargar_Click(object sender, EventArgs e)
        {
            // Validar datos
            if (string.IsNullOrEmpty(JTex_Numero.Text) || JCbo_Operador.SelectedIndex < 0 ||
                !(JRad_Monto3.IsChecked || JRad_Monto5.IsChecked || JRad_Monto10.IsChecked))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Obtener datos seleccionados
            string numero = JTex_Numero.Text;
            string operador = JCbo_Operador.SelectedItem.ToString();
            int monto = JRad_Monto3.IsChecked ? 3 : JRad_Monto5.IsChecked ? 5 : 10;

            // Confirmar recarga
            bool confirmacion = await DisplayAlert("Confirmación", $"¿Desea recargar {monto} dólares?", "Sí", "No");
            if (!confirmacion) return;

            // Simular tiempo de procesamiento
            await Task.Delay(2000);

            // Mensaje de éxito
            await DisplayAlert("Recarga finalizada", $"Recarga de {monto} dólares exitosa al número {numero} en {operador}.", "OK");
        }

        private void UpdateSummary(object sender, CheckedChangedEventArgs e)
        {
            // Actualizar el resumen cuando se selecciona un monto
            if (e.Value) // Solo si está seleccionado
            {
                int monto = JRad_Monto3.IsChecked ? 3 : JRad_Monto5.IsChecked ? 5 : 10;
                JLbl_Resumen.Text = $"Ha seleccionado una recarga de: {monto} dólares";
                JLbl_Resumen.TextColor = Color.FromArgb("#333333");
            }
        }
    }
}
