using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }
      
        private void polígonoEstrellado16Y8PuntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmPoligonoEstrellado frm = new frmPoligonoEstrellado();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pentagonoEstrellado5PuntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //figura2
            CerrarFormulariosHijos();
            frmPentagonoEstrellado frm = new frmPentagonoEstrellado();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gemaDe10LadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //figura3
            CerrarFormulariosHijos();
            fmrGema frm = new fmrGema();
            frm.MdiParent = this;
            frm.Show();
        }

        private void estrellaGeométrica8PuntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //figura4
            CerrarFormulariosHijos();
            frmEstrellaGeometrica frm = new frmEstrellaGeometrica();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hexágonoConcéntricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //figura5
            CerrarFormulariosHijos();
            fmrHexagonoConcentrico frm = new fmrHexagonoConcentrico();
            frm.MdiParent = this;
            frm.Show();
        }

        private void florGeométricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //figura6
            CerrarFormulariosHijos();
            frmFlor frm = new frmFlor();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
