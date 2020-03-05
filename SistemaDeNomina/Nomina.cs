using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaDeNomina
{
    public partial class Nomina : MetroFramework.Forms.MetroForm
    {
        Double primerNum;
        Double segundoNum;
        Double resultado;
        String operacion;

        //otros variables
        Double prestamo_estud_precio = 5.9;
        Double prestamo_estud;
        Double ponderacion;
        Double salario_basica;
        Double horas_extra;
        Double pagos;
        Double sueldo_bruto;
        Double tasa_impuesto = 17.5;
        Double per=100;
        Double impuesto_sobre_renta;
        Double Impuesto_estatal;
        Double StatePension;
        Double pension;
        Double pension_rate=3.5;
        Double NI_Payment_rate=1.95;
        Double NI_Paid;
        Double NI_Rate;

        //convertidor 
        Double US = 53.70;
        Double HTI = 0.59;
        Double EU = 59.87;
        public Nomina()
        {
            InitializeComponent();
        }

        //Calculadora
        private void Button_Click(object sender, EventArgs e)
        {
            Button numero = (Button)sender;
            if (lblResult1.Text == "0")
                lblResult1.Text = numero.Text;
            else
                lblResult1.Text += numero.Text;
        }
        private void Aritmetico_Funcion(object sender, EventArgs e)
        {
            Button op = (Button)sender;
            primerNum = Convert.ToDouble(lblResult1.Text);
            lblResult1.Text = "";
            operacion = op.Text;
            lblResult2.Text = System.Convert.ToString(primerNum) + " " + operacion;
        }
        private void BtnAtras_Click(object sender, EventArgs e)
        {
            if (lblResult1.Text.Length > 0)
                lblResult1.Text = lblResult1.Text.Remove(lblResult1.Text.Length - 1, 1);
        }
        private void BtnC_Click(object sender, EventArgs e)
        {
            lblResult2.Text = "";
            lblResult1.Text = "0";
        } 
        private void Btnpunto_Click(object sender, EventArgs e)
        {
            Button numero = (Button)sender;
            if (numero.Text == ",")
            {
                if (!lblResult1.Text.Contains(","))
                    lblResult1.Text = (lblResult1.Text + numero.Text);
            }
        }
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            segundoNum = Double.Parse(lblResult1.Text);
            lblResult2.Text = "";

            switch (operacion)
            {
                case "+":
                    resultado = (primerNum + segundoNum);
                    lblResult1.Text = System.Convert.ToString(resultado);
                    break;
                case "-":
                    resultado = (primerNum - segundoNum);
                    lblResult1.Text = System.Convert.ToString(resultado);
                    break;
                case "*":
                    resultado = (primerNum * segundoNum);
                    lblResult1.Text = System.Convert.ToString(resultado);
                    break;
                case "/":
                    resultado = (primerNum / segundoNum);
                    lblResult1.Text = System.Convert.ToString(resultado);
                    break;
                default:
                    break;
            }
        }

        //datos verificado
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            detalle_empleadoBindingSource.AddNew();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnMovePrevious_Click(object sender, EventArgs e)
        {
            detalle_empleadoBindingSource.MovePrevious();
        }
        private void BtnMoveNext_Click(object sender, EventArgs e)
        {
            detalle_empleadoBindingSource.MoveNext();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            detalle_empleadoBindingSource.RemoveCurrent();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.detalle_empleadoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._Uncle_T_TopCodeDataSet);
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.detalle_empleadoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._Uncle_T_TopCodeDataSet);
        }

        private void detalle_empleadoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.detalle_empleadoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._Uncle_T_TopCodeDataSet);
        }

        private void Nomina_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla '_Uncle_T_TopCodeDataSet.detalle_empleado' Puede moverla o quitarla según sea necesario.
            this.detalle_empleadoTableAdapter.Fill(this._Uncle_T_TopCodeDataSet.detalle_empleado);

            cmbPais.Text = "SELECCIONE UNO...";
            cmbPais.Items.Add("ESTADOS UNIDOS US");
            cmbPais.Items.Add("EURO EU");
            cmbPais.Items.Add("HAITI HTI");

            //webBrowser.Navigate("https://www.google.com/finance/converter");
                                                  
        }
        private void pago_ImponibleTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void pago_ImponibleLabel_Click(object sender, EventArgs e)
        {

        }

        private void BtnDetallSalarios_Click(object sender, EventArgs e)
        {
            RTxtRecibopago.Text = "";
            ponderacion = Double.Parse(ponderacion_Ciudad_interiorTextBox.Text);
            salario_basica = Double.Parse(salario_BasicoTextBox.Text);
            horas_extra = Double.Parse(horas_ExtraTextBox.Text);

            //@@@@@@@@@@@@@@@@@@@@@@@Sueldo bruto@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            pagos = ((ponderacion) + (salario_basica) + (horas_extra));
            sueldo_bruto = (pagos);
            pagosTextBox.Text = System.Convert.ToString(sueldo_bruto);
            pagosTextBox.Text = String.Format("{0:C}", Double.Parse(pagosTextBox.Text));

            //@@@@@@@@@@@@@@@@@@@@@@@pago mensual del préstamo estudiantil@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            pagos = ((ponderacion) + (salario_basica) + (horas_extra));
            prestamo_estud = ((pagos) * prestamo_estud_precio) / per;
            prestamo_EstudiantilTextBox.Text = System.Convert.ToString(prestamo_estud);
            prestamo_EstudiantilTextBox.Text = string.Format("{0:C}", Double.Parse(prestamo_EstudiantilTextBox.Text));

            //@@@@@@@@@@@@@@@@@@@@@@@impuesto estatal mensual@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            impuesto_sobre_renta = ((ponderacion) + (salario_basica) + (horas_extra));
            Impuesto_estatal = ((impuesto_sobre_renta) * tasa_impuesto) / per;
            impuestoTextBox.Text = System.Convert.ToString(Impuesto_estatal);
            impuestoTextBox.Text = string.Format("{0:C}", Double.Parse(impuestoTextBox.Text));

            //@@@@@@@@@@@@@@@@@@@@@@@State Pension Per Month@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            StatePension = ((ponderacion) + (salario_basica) + (horas_extra));
            pension = ((StatePension) * pension_rate) / per;
            pensionTextBox.Text = System.Convert.ToString(pension);
            pensionTextBox.Text = string.Format("{0:C}", Double.Parse(pensionTextBox.Text));

            //@@@@@@@@@@@@@@@@@@@@@@@NI repayment@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            NI_Rate = ((ponderacion) + (salario_basica) + (horas_extra));
            NI_Paid = ((NI_Rate) * NI_Payment_rate) / per;
            pago_NITextBox.Text = System.Convert.ToString(NI_Paid);
            pago_NITextBox.Text = string.Format("{0:C}", Double.Parse(pago_NITextBox.Text));

            //@@@@@@@@@@@@@@@@@@@@@@@deducciones@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            Double NI = System.Convert.ToInt32(NI_Paid);
            Double Tax = System.Convert.ToInt32(Impuesto_estatal);
            Double Prestamo_est = System.Convert.ToInt32(prestamo_estud);
            Double Pension_pagada = System.Convert.ToInt32(pension);
            Double deducciones = (NI) + (Tax) + (Prestamo_est) + (Pension_pagada);

            deduccionesTextBox.Text = System.Convert.ToString(deducciones);
            deduccionesTextBox.Text = string.Format("{0:C}", Double.Parse(deduccionesTextBox.Text));

            //@@@@@@@@@@@@@@@@@@@@@@@pago neto@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            Double total_deduccion = System.Convert.ToInt32(deducciones);
            Double pago_bruto = System.Convert.ToInt32(sueldo_bruto);
            Double pago_neto = (pago_bruto) - (total_deduccion);
            salario_NetoTextBox.Text = System.Convert.ToString(pago_neto);
            salario_NetoTextBox.Text = String.Format("{0:C}", Double.Parse(salario_NetoTextBox.Text));

            //@@@@@@@@@@@@@@@@@@@@@@@Descripcion_cash@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            Double Descripcion_cash = System.Convert.ToInt32(impuesto_PeriodoTextBox1.Text);
            Double impuesto_Periodo = System.Convert.ToInt32(Impuesto_estatal * Descripcion_cash);
            Double pensionable = System.Convert.ToInt32(pension_rate * Descripcion_cash);


            pago_ImponibleTextBox.Text = System.Convert.ToString(impuesto_Periodo);
            pago_ImponibleTextBox.Text = string.Format("{0:C}", Double.Parse(pago_ImponibleTextBox.Text));

            pagoPensionableTextBox.Text = System.Convert.ToString(pensionable);
            //pagoPensionableTextBox.Text = string.Format("{0:C}", Double.Parse(pago_ImponibleTextBox.Text));

            ponderacion_Ciudad_interiorTextBox.Text = string.Format("{0:C}", Double.Parse(ponderacion_Ciudad_interiorTextBox.Text));
            salario_BasicoTextBox.Text = string.Format("{0:C}", Double.Parse(salario_BasicoTextBox.Text));

            horas_ExtraTextBox.Text = string.Format("{0:C}", Double.Parse(horas_ExtraTextBox.Text));
        }

        private void BtnpaySlip_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            DateTime fecha_de_hoy = DateTime.Now;
            RTxtRecibopago.Text = "";
            ////Txtsalida_recibopago.AppendText(" " + Environment.NewLine);
            RTxtRecibopago.AppendText("\t\tNEGOCIO DE LA GENTE! RECIBO SALARIO" + Environment.NewLine);
            RTxtRecibopago.AppendText("------------------------------------------------------------------------------------------" + Environment.NewLine);
            RTxtRecibopago.AppendText("\t\t\t     BIENVENIDO" + Environment.NewLine);
            RTxtRecibopago.AppendText("------------------------------------------------------------------------------------------");
            RTxtRecibopago.AppendText(Environment.NewLine);

            RTxtRecibopago.AppendText(" Empleado Nombre: "+"\t"+nombreTextBox.Text+"\t\t\t"+empleadorTextBox.Text+Environment.NewLine);
            RTxtRecibopago.AppendText(" Direccion1: " + "\t" + direccion1TextBox.Text + Environment.NewLine);
            RTxtRecibopago.AppendText(" Codigo Postal: " + "\t" + codigoPostalTextBox.Text + Environment.NewLine);
            RTxtRecibopago.AppendText("\t\t\t\t" + "PRIVADO Y CONFIDENCIAL" + Environment.NewLine);
            RTxtRecibopago.AppendText(" "+Environment.NewLine);
            RTxtRecibopago.AppendText(" Empleador Nombre:  " +  empleadorTextBox.Text + "  "+"Fecha Pago: "+ fecha_PagoDateTimePicker.Text + Environment.NewLine);
            RTxtRecibopago.AppendText(" Empleado Nombre:  " +  nombreTextBox.Text + "\t\t"+"Impuesto Perido: "+ impuesto_PeriodoTextBox1.Text + Environment.NewLine);
            RTxtRecibopago.AppendText(" N° Referencia:  " + referencia_NumeroTextBox.Text + "\t" + "Impuesto Codigo: "+impuesto_CodigoTextBox1.Text + Environment.NewLine);
            RTxtRecibopago.AppendText("\t\t"+ "N.I. Numero:"+ nI_NumeroTextBox1.Text + Environment.NewLine);
            RTxtRecibopago.AppendText("\t\t" + "N.I. Codigo:" +  nI_CodigoTextBox1.Text+ Environment.NewLine);

            RTxtRecibopago.AppendText("------------------------------------------------------------------------------------------");
            RTxtRecibopago.AppendText(Environment.NewLine);
            RTxtRecibopago.AppendText(" Ponderacion de La Ciudad Interior: " + ponderacion_Ciudad_interiorTextBox.Text + "\t" + "Impuesto: " + impuestoTextBox.Text + Environment.NewLine);
            RTxtRecibopago.AppendText(" Salario Basico: "+ salario_BasicoTextBox.Text + "\t\t\t" + "Pension: " + pensionTextBox.Text + Environment.NewLine);
            RTxtRecibopago.AppendText(" H. Extras: " + horas_ExtraTextBox.Text + "  " + "Prest Estudiantil: " + prestamo_EstudiantilTextBox.Text + "  " + "Pago Imponible: " + pago_ImponibleTextBox.Text + Environment.NewLine);

            RTxtRecibopago.AppendText("\t\t" + "N.I. Pago:" +pago_NITextBox.Text +"\t"+"Pago Pensionable: "+pagoPensionableTextBox.Text+ Environment.NewLine);
            RTxtRecibopago.AppendText(" " + Environment.NewLine + Environment.NewLine);
            RTxtRecibopago.AppendText(" Pago: "+"\t"+ pagosTextBox.Text +"\t"+"Deduccion: "+deduccionesTextBox.Text+"\t"+"Pago Neto: "+salario_NetoTextBox.Text+ Environment.NewLine);

            RTxtRecibopago.AppendText("------------------------------------------------------------------------------------------ ");
            RTxtRecibopago.AppendText(" "+Environment.NewLine + Environment.NewLine);
            RTxtRecibopago.AppendText("\t\t\t\t\t\t" +fecha_de_hoy+ Environment.NewLine);

            RTxtRecibopago.AppendText("------------------------------------------------------------------------------------------ \n");
            RTxtRecibopago.AppendText("\t\t\t GRACIAS POR FEFERIRNOS" );

        }

        private void BtnConvertidor_Click(object sender, EventArgs e)
        {
            BtnConvertidor.Visible = false;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            BtnConvertidor.Visible = true;
            TxtDinero.Clear();
            Txtsalida.Text = "";
        }

        private void BtnConvertir_Click(object sender, EventArgs e)
        {
            if(EstaValidado())
              {         
            Double peso_do = Convert.ToDouble(TxtDinero.Text);
            if(cmbPais.Text== "ESTADOS UNIDOS US")
            {
                Txtsalida.Text = System.Convert.ToString(("RD$" + peso_do * US));
            }
            if (cmbPais.Text == "EURO EU")
            {
                Txtsalida.Text = System.Convert.ToString(("RD$" + peso_do * EU));
            }
            if (cmbPais.Text == "HAITI HTI")
            {
                Txtsalida.Text = System.Convert.ToString(("RD$" + peso_do * HTI));
            }
            }
        }
        public bool EstaValidado()
        {
            if (TxtDinero.Text.Trim() == string.Empty)
            {
                MessageBox.Show("CANTIDAD DE DINERO REQUERIDO", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtDinero.Focus();
                return false;
            }
            else
            {
                bool isNumeric = double.TryParse(TxtDinero.Text.Trim(), out _);
                if (!isNumeric)
                {
                    MessageBox.Show("CANTIDAD DE DINERO DEBE SER UN VALOR ENTERO O DECIMAL", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtDinero.Clear();
                    TxtDinero.Focus();
                    return false;
                }
            }
            return true;
        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            RTxtRecibopago.Clear();
        }

        private void cortarToolStripButton_Click(object sender, EventArgs e)
        {
            RTxtRecibopago.Cut();
        }

        private void copiarToolStripButton_Click(object sender, EventArgs e)
        {
            RTxtRecibopago.Copy();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(RTxtRecibopago.Text, new System.Drawing.Font("Arial", 14, FontStyle.Regular), Brushes.Black, 120, 120);
        }

        private void imprimirToolStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfil = new OpenFileDialog();
            openfil.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openfil.ShowDialog() == DialogResult.OK)
                RTxtRecibopago.LoadFile(openfil.FileName, RichTextBoxStreamType.PlainText);
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();

            savefile.FileName = "Notepad Text";
            savefile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(savefile.FileName))
                    sw.WriteLine(RTxtRecibopago.Text);
            }
        }
    }
}