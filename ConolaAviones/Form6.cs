using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace ConolaAviones
{
    public partial class Form6 : Form
    {
        FlightPlan vuelo1;
        FlightPlan vuelo2;
        public Form6(FlightPlan vuelo1, FlightPlan vuelo2)
        {
            InitializeComponent();
            this.vuelo1 = vuelo1;
            this.vuelo2 = vuelo2;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
                        vuelosGrid.ColumnCount = 4;
            vuelosGrid.RowCount = 2;
            vuelosGrid.Columns[0].HeaderText = "Id";
            vuelosGrid.Columns[1].HeaderText = "Speed (km/h)";
            vuelosGrid.Columns[2].HeaderText = "X";
            vuelosGrid.Columns[3].HeaderText = "Y";
            vuelosGrid.Rows[0].Cells[0].Value = vuelo1.GetId();
            vuelosGrid.Rows[0].Cells[1].Value = vuelo1.GetVelocidad();
            vuelosGrid.Rows[0].Cells[2].Value = vuelo1.GetCurrentPosition().GetX().ToString("F2");
            vuelosGrid.Rows[0].Cells[3].Value = vuelo1.GetCurrentPosition().GetY().ToString("F2");
            vuelosGrid.Rows[1].Cells[0].Value = vuelo2.GetId();
            vuelosGrid.Rows[1].Cells[1].Value = vuelo2.GetVelocidad();
            vuelosGrid.Rows[1].Cells[2].Value = vuelo2.GetCurrentPosition().GetX().ToString("F2");
            vuelosGrid.Rows[1].Cells[3].Value = vuelo2.GetCurrentPosition().GetY().ToString("F2");
            vuelosGrid.ClearSelection();
        }

        private void vuelosGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            double distancia;

            if (e.RowIndex == 0)
            {
                distancia = vuelo1.Distance(vuelo2);
            }
            else
            {
                distancia = vuelo2.Distance(vuelo1);
            }
            Form7 f7 = new Form7(distancia);
            f7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
