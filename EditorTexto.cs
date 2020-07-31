using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;

namespace JackyEditor {
    public partial class EditorTexto : Form {
        StringReader Leitor = null;
        public EditorTexto() {
            InitializeComponent();
        }


        //NOVO
        private void novoToolStripMenuItem_Click(object sender, EventArgs e) {
            ChamaSalvarArquivo();
            CaixaTexto.Focus();
        }
        private void toolStripNovo_Click(object sender, EventArgs e) {
            ChamaSalvarArquivo();
            CaixaTexto.Focus();
        }

        private void ChamaSalvarArquivo() {
            if (!string.IsNullOrEmpty(CaixaTexto.Text)) {
                var result = MessageBox.Show("Deseja Salvar o arquivo?", "Salvando Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (System.Windows.Forms.DialogResult.Yes == result) {
                    SalvarArquivo();
                    CaixaTexto.Clear();
                }
            }
        }

        private void SalvarArquivo() {
            try {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    FileStream FileSt = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter M_streamWriter = new StreamWriter(FileSt);
                    M_streamWriter.Flush();
                    M_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    M_streamWriter.Write(this.CaixaTexto.Text);
                    M_streamWriter.Flush();
                    M_streamWriter.Close();
                }
            } catch (Exception Ex) {
                MessageBox.Show("Erro: " + Ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        //ABRIR
        private void toolStripAbrir_Click(object sender, EventArgs e) {
            AbrirArquivo();
        }
        private void abrirTextoToolStripMenuItem_Click(object sender, EventArgs e) {
            AbrirArquivo();
        }

        private void AbrirArquivo() {
            //Abre o FileDialog
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Selecionar Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Dados\";
            //filtra para somente texto
            openFileDialog1.Filter = "Images (*.TXT)|*.TXT|" + "All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK) {
                try {
                    FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader M_StreamReader = new StreamReader(fileStream);
                    //Leitura do arquivo
                    M_StreamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    //Lê e faz o parse até a ultima linha 
                    this.CaixaTexto.Text = "";
                    string strLine = M_StreamReader.ReadLine();
                    while (strLine != null) {
                        this.CaixaTexto.Text += strLine + "\n";
                        strLine = M_StreamReader.ReadLine();
                    }
                    //Fechando
                    M_StreamReader.Close();
                } catch (Exception ex) {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        //SALVAR
        private void toolStripSalvar_Click(object sender, EventArgs e) {
            ChamaSalvarArquivo();
        }

        private void salvarTextoToolStripMenuItem_Click(object sender, EventArgs e) {
            ChamaSalvarArquivo();
        }






        //COPIAR
        private void toolStripCopiar_Click(object sender, EventArgs e) {
            Copiar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e) {
            Copiar();
        }

        private void Copiar() {
            if (CaixaTexto.SelectionLength > 0) {
                CaixaTexto.Copy();
            }
        }






        //COLAR
        private void colarToolStripMenuItem_Click(object sender, EventArgs e) {
            Colar();
        }

        private void toolStripColar_Click(object sender, EventArgs e) {
            Colar();
        }
        private void Colar() {
            CaixaTexto.Paste();
        }




        //NEGRITO
        private void toolStripNegrito_Click(object sender, EventArgs e) {
            Negrito();
        }
        private void negritoToolStripMenuItem_Click(object sender, EventArgs e) {
            Negrito();
        }
        private void Negrito() {
            string nomeFonte = null;
            float tamanhoFonte = 0;
            bool negrito = false;
            nomeFonte = CaixaTexto.Font.Name;
            tamanhoFonte = CaixaTexto.Font.Size;
            negrito = CaixaTexto.Font.Bold;

            if (negrito == false) {
                CaixaTexto.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold);
            }
        }





        //ITÁLICO
        private void toolStripItalico_Click(object sender, EventArgs e) {
            Italico();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e) {
            Italico();
        }

        private void Italico() {
            string nomeFonte = null;
            float tamanhoFonte = 0;
            bool italico = false;
            nomeFonte = CaixaTexto.Font.Name;
            tamanhoFonte = CaixaTexto.Font.Size;
            italico = CaixaTexto.Font.Italic;

            if (italico == false) {
                CaixaTexto.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Italic);
            }
        }





        //SUBLINHADO
        private void toolStripSublinhado_Click(object sender, EventArgs e) {
            Sublinhar();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e) {
            Sublinhar();
        }

        private void Sublinhar() {
            string nomeFonte = null;
            float tamanhoFonte = 0;
            bool sublinhado = false;
            nomeFonte = CaixaTexto.Font.Name;
            tamanhoFonte = CaixaTexto.Font.Size;
            sublinhado = CaixaTexto.Font.Underline;

            if (sublinhado == false) {
                CaixaTexto.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Underline);
            }
        }




        //REGULAR
        private void toolStripRegular_Click(object sender, EventArgs e) {
            Regular();
        }
        private void padrãoToolStripMenuItem_Click(object sender, EventArgs e) {
            Regular();
        }
        private void Regular() {
            string nomeFonte = null;
            float tamanhoFonte = 0;
            nomeFonte = CaixaTexto.Font.Name;
            tamanhoFonte = CaixaTexto.Font.Size;
            CaixaTexto.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);
        }




        //ALTERAR FONTE

        private void alterarFonteToolStripMenuItem_Click(object sender, EventArgs e) {
            AlterarFonte();
        }

        private void toolStripFonte_Click(object sender, EventArgs e) {
            AlterarFonte();
        }

        private void AlterarFonte() {
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK && CaixaTexto.SelectionFont != null) {
                CaixaTexto.SelectionFont = fontDialog1.Font;
            }
        }





        //ALINHAR TEXTO

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e) {
            CaixaTexto.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e) {
            CaixaTexto.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void centroToolStripMenuItem_Click(object sender, EventArgs e) {
            CaixaTexto.SelectionAlignment = HorizontalAlignment.Center;
        }





        //CONFIGURAÇÕES IMPRESSÃO




        private void toolStripConfigurarImpressora_Click(object sender, EventArgs e) {
            Configurar();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            Configurar();
        }
        private void Configurar() {
            try {
                this.printDialog1.Document = this.printDocument1;
                printDialog1.ShowDialog();
            } catch (Exception Ex) {
                MessageBox.Show("Erro:" + Ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        //VISUALIZAR IMPRESSÃO

        private void toolStripVisualizarImpressao_Click(object sender, EventArgs e) {
            VisualizarImpressao();
        }

        private void visualizarImpressãoToolStripMenuItem_Click(object sender, EventArgs e) {
            VisualizarImpressao();
        }

        private void VisualizarImpressao() {
            try {
                string strTexto = this.CaixaTexto.Text;
                Leitor = new StringReader(strTexto);
                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                var LDialogo = printPreviewDialog1;
                LDialogo.Document = this.printDocument1;
                LDialogo.Text = "JackyEditor - Visualizando a impressão";
                LDialogo.WindowState = FormWindowState.Maximized;
                LDialogo.PrintPreviewControl.Zoom = 1;
                LDialogo.FormBorderStyle = FormBorderStyle.Fixed3D;
                LDialogo.ShowDialog();
            } catch (Exception Ex) {
                MessageBox.Show("Erro: " + Ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        //IMPRIMIR

        private void toolStripImprimir_Click(object sender, EventArgs e) {
            Imprimir();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e) {
            Imprimir();
        }
        private void Imprimir() {
            printDialog1.Document = printDocument1;

            string strTexto = this.CaixaTexto.Text;
            Leitor = new StringReader(strTexto);

            if (printDialog1.ShowDialog() == DialogResult.OK) {
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            float linhaPorPagina = 0;
            float posicaoY = 0;
            int contador = 0;

            //Margens max e min
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Right - 50;

            if (margemEsquerda < 5) {
                margemEsquerda = 20;
            }
            if (margemSuperior < 5) {
                margemSuperior = 20;
            }

            //fonte
            string linha = null;
            Font FonteDeImpressao = this.CaixaTexto.Font;
            SolidBrush MeuPincel = new SolidBrush(Color.Black);

            //calcula numero de linhas
            linhaPorPagina = e.MarginBounds.Height / FonteDeImpressao.GetHeight(e.Graphics);

            //Imprimir cada linha
            linha = Leitor.ReadLine();

            while (contador < linhaPorPagina) {

                //Calcula aposição da linha baseado na altura da fonte de acordo com o dispositivo
                posicaoY = (margemSuperior + (contador * FonteDeImpressao.GetHeight(e.Graphics)));

                //Desenha a prox linha no controle do richbox
                e.Graphics.DrawString(linha, FonteDeImpressao, MeuPincel, margemEsquerda, posicaoY, new StringFormat());

                //conta linha por linha e incrementa
                contador += 1;
                linha = Leitor.ReadLine();
            }

            //Se existir mais linhas, cria outra pagina
            if (linha != null) {
                e.HasMorePages = true;
            } else {
                e.HasMorePages = false;
            }
            MeuPincel.Dispose();
        }





        //AJUDA

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {
            Ajuda();
        }

        private void toolStripAjuda_Click(object sender, EventArgs e) {
            Ajuda();
        }

        private void Ajuda() {
            MessageBox.Show("Se deseja esclarecer dúvidas, dar sugestões ou até mesmo obter mais informações sobre o projeto, " +
            "basta entrar em contato com o dono  Discord: Philipe R.#1926 / Email: PhilipeRochad.js@gmail.com", "Sobre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        //SAIR

        private void toolStripSair_Click(object sender, EventArgs e) {
            Sair();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e) {
            Sair();
        }

        private void Sair() {
            ChamaSalvarArquivo();
            var result = MessageBox.Show("Deseja mesmo sair do JackyEditor?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes) {
                Application.Exit();
            }
        }









        //REDO
        private void refazerToolStripMenuItem_Click(object sender, EventArgs e) {
            Refazer();
        }

        private void toolStripRefazer_Click(object sender, EventArgs e) {
            Refazer();
        }

        private void Refazer() {
            CaixaTexto.Redo();
        }








        //UNDO
        private void toolStripDesfazer_Click(object sender, EventArgs e) {
            Desfazer();
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e) {
            Desfazer();
        }

        private void Desfazer() {
            CaixaTexto.Undo();
        }
    }    
}