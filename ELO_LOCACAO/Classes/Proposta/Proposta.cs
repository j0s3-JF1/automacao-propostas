using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace ELO_LOCACAO.Classes.Proposta
{
    internal class Proposta
    {
        /*
            Calculo de Proposta
         */

        //Verifica o valor de potência
        public int VerificaPotencia(
                string valor1
            )
        {
            //Valor de Referência para Potência
            double potencia = double.Parse(valor1);
            //Valor de retorno
            int retorno = 0;

            //Condicional
            if (potencia >= 1.1 && potencia <= 7.5)
            {
                retorno = 23040;
                return retorno;
            }
            else if (potencia >= 7.6 && potencia <= 18.5)
            {
                retorno = 41040;
                return retorno;
            }
            else if (potencia >= 18.6 && potencia <= 37)
            {
                retorno = 67320;
                return retorno;
            }
            else if (potencia >= 38 && potencia <= 75)
            {
                retorno = 117720;
                return retorno;
            }
            else if (potencia >= 76 && potencia <= 132)
            {
                retorno = 190080;
                return retorno;
            }
            else if (potencia >= 133 && potencia <= 200)
            {
                retorno = 287640;
                return retorno;
            }
            else if (potencia >= 201 && potencia <= 315)
            {
                retorno = 403560;
                return retorno;
            }
            else if (potencia >= 316 && potencia <= 450)
            {
                retorno = 548280;
                return retorno;
            }
            else if (potencia >= 451)
            {
                retorno = 843120;
                return retorno;
            }

            return retorno;

        }

        public double[] Calculo(
                string potencia,
                string count1,
                string count2,
                string count3
            )
        {
            double[] preco = new double[5];

            //Verificação de Potência
            int retorno = VerificaPotencia(potencia);
            int add = 0;

            int[] count = new int[3];

            count[0] = int.Parse(count1);
            count[1] = int.Parse(count2);
            count[2] = int.Parse(count3);

            preco[0] = 0;

            if (retorno == 0)
            {
                preco[0] = 0;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (count[i] == 1)
                    {
                        add++;
                    }
                }

                if (add != 0)
                {
                    if (add == 1)
                    {
                        //Placa Adicional %
                        double adicional = 0.05;
                        double inicial = (((retorno / 12) / 30) * 1) * 1;

                        double diaria = (inicial * adicional) + inicial;
                        double semana = ((((retorno / 12) / 30) * 7) - diaria) * 1;
                        double quinzena = ((((retorno / 12) / 30) * 14) - diaria * 2) * 1;
                        double vinte = ((((retorno / 12) / 30) * 21) - diaria * 3) * 1;
                        double mensal = ((((retorno / 12) / 30) * 30) - diaria * 4) * 1;

                        preco[0] = diaria;
                        preco[1] = semana;
                        preco[2] = quinzena;
                        preco[3] = vinte;
                        preco[4] = mensal;

                        return preco;
                    }
                    else if (add == 2)
                    {
                        //Placa Adicional %
                        double adicional = 0.1;
                        double inicial = (((retorno / 12) / 30) * 1) * 1;

                        double diaria = (inicial * adicional) + inicial;
                        double semana = ((((retorno / 12) / 30) * 7) - diaria) * 1;
                        double quinzena = ((((retorno / 12) / 30) * 14) - diaria * 2) * 1;
                        double vinte = ((((retorno / 12) / 30) * 21) - diaria * 3) * 1;
                        double mensal = ((((retorno / 12) / 30) * 30) - diaria * 4) * 1;

                        preco[0] = diaria;
                        preco[1] = semana;
                        preco[2] = quinzena;
                        preco[3] = vinte;
                        preco[4] = mensal;

                        return preco;
                    }
                    else if (add == 3)
                    {
                        //Placa Adicional %
                        double adicional = 0.15;
                        double inicial = (((retorno / 12) / 30) * 1) * 1;

                        double diaria = (inicial * adicional) + inicial;
                        double semana = ((((retorno / 12) / 30) * 7) - diaria) * 1;
                        double quinzena = ((((retorno / 12) / 30) * 14) - diaria * 2) * 1;
                        double vinte = ((((retorno / 12) / 30) * 21) - diaria * 3) * 1;
                        double mensal = ((((retorno / 12) / 30) * 30) - diaria * 4) * 1;

                        preco[0] = diaria;
                        preco[1] = semana;
                        preco[2] = quinzena;
                        preco[3] = vinte;
                        preco[4] = mensal;

                        return preco;
                    }
                }
                else
                {
                    double diaria = (((retorno / 12) / 30) * 1) * 1;
                    double semana = ((((retorno / 12) / 30) * 7) - diaria) * 1;
                    double quinzena = ((((retorno / 12) / 30) * 14) - diaria * 2) * 1;
                    double vinte = ((((retorno / 12) / 30) * 21) - diaria * 3) * 1;
                    double mensal = ((((retorno / 12) / 30) * 30) - diaria * 4) * 1;

                    preco[0] = diaria;
                    preco[1] = semana;
                    preco[2] = quinzena;
                    preco[3] = vinte;
                    preco[4] = mensal;

                    return preco;
                }
            }
            return preco;

        }

        public double VerificaDia(
                string valor1,
                string valor2,
                string count1,
                string count2,
                string count3
            )
        {
            //Calculo
            double[] calculo = Calculo(valor2, count1, count2, count3);
            int retorno = VerificaPotencia(valor2);
            double diaria = 0;

            int dia = int.Parse(valor1);

            //Retorno
            double resultado = 0;

            if (calculo[0] == 0)
            {
                resultado = 0;
            }
            else
            {
                diaria = calculo[0];

                if (dia < 7)
                {
                    resultado = ((((retorno / 12) / 30) * dia) * 1);
                    return resultado;
                }
                else if (dia == 7)
                {
                    resultado = (((((retorno / 12) / 30) * dia) - diaria) * 1);
                    return resultado;
                }
                else if (dia > 7 && dia < 14)
                {
                    resultado = (((((retorno / 12) / 30) * dia) - diaria) * 1);
                    return resultado;
                }
                else if (dia == 14)
                {
                    resultado = (((((retorno / 12) / 30) * dia) - diaria * 2) * 1);
                    return resultado;
                }
                else if (dia > 14 && dia < 21)
                {
                    resultado = (((((retorno / 12) / 30) * dia) - diaria * 2) * 1);
                    return resultado;
                }
                else if (dia == 21)
                {
                    resultado = (((((retorno / 12) / 30) * dia) - diaria * 3) * 1);
                    return resultado;
                }
                else if (dia > 21 && dia < 30)
                {
                    resultado = (((((retorno / 12) / 30) * dia) - diaria * 3) * 1);
                    return resultado;
                }
                else if (dia == 30)
                {
                    resultado = (((((retorno / 12) / 30) * dia) - diaria * 4) * 1);
                    return resultado;
                }
                else if (dia >= 31)
                {
                    resultado = (((((retorno / 12) / 30) * dia) * 0.8) * 1);
                    return resultado;
                }
            }
            return resultado;
        }

        /*
            Objeto do Word(docx)
         */
        public object[] ObjectWord()
        {
            object[] objects = new object[4];

            object ObjMiss = System.Reflection.Missing.Value;
            Word.Application ObjWord = new Word.Application();
            string path = System.Windows.Forms.Application.StartupPath + @"\document.docx";

            object parametro = path;

            objects[0] = ObjMiss;
            objects[1] = ObjWord;
            objects[2] = path;
            objects[3] = parametro;

            //Parametro

            return objects;
        }

        /*
            Parametros a serem preenchidos
         */

        public object[] ParamCliente()
        {
            object[] objects = ObjectWord();

            //Parametro
            object parametro = objects[2];

            //Cliente
            object Cliente1 = "Cliente1";
            object Cliente2 = "Cliente2";
            object CNPJ = "CNPJ";
            object AC = "AC";
            object DeptoCLI = "DeptoCLI";
            object FoneCLI = "FoneCLI";
            object CelCLI = "CelCLI";
            object EmailCLI = "EmailCLI";

            //Array de Cliente
            object[] cliente = new object[8];

            cliente[0] = Cliente1;
            cliente[1] = Cliente2;
            cliente[2] = CNPJ;
            cliente[3] = AC;
            cliente[4] = DeptoCLI;
            cliente[5] = FoneCLI;
            cliente[6] = CelCLI;
            cliente[7] = EmailCLI;

            return cliente;
        }

        public object[] ParamRemetente()
        {
            object[] objects = ObjectWord();

            //Parametro
            object parametro = objects[2];

            //Rementente
            object Remetente = "Rem";
            object DeptoREM = "DeptoRem";
            object FoneREM = "FoneRem";
            object CelREM = "CelRem";
            object EmailREM = "EmailRem";

            //Array Remetente
            object[] remetente = new object[5];

            remetente[0] = Remetente;
            remetente[1] = DeptoREM;
            remetente[2] = FoneREM;
            remetente[3] = CelREM;
            remetente[4] = EmailREM;

            return remetente;
        }

        public object[] ParamEscopo()
        {
            object[] objects = ObjectWord();

            //Parametro
            object parametro = objects[2];

            //Escopo Técnico
            object Quantidade = "Quant";
            object Drive = "Drive";

            //Array Escopo técnico
            object[] escopo = new object[2];

            escopo[0] = Quantidade;
            escopo[1] = Drive;

            return escopo;
        }

        public object[] ParamLocacao()
        {
            object[] objects = ObjectWord();

            //Parametro
            object parametro = objects[2];

            //Diaria Locação
            object Diaria = "Diaria";
            object Semana = "Semana";
            object Quinzena = "Quinzena";
            object VinteDias = "VinteDias";
            object Mes = "Mes";

            //Array Locação
            object[] locacao = new object[5];

            locacao[0] = Diaria;
            locacao[1] = Semana;
            locacao[2] = Quinzena;
            locacao[3] = VinteDias;
            locacao[4] = Mes;

            return locacao;
        }

        public object[] ParamAdcionais()
        {
            object[] objects = ObjectWord();

            //Parametro
            object parametro = objects[2];

            //Adicionais
            object NProp = "Proposta";
            object Referencia = "Referencia";
            object DataInicio = "DataInicio";
            object DataEnvio = "DataEnvio";

            //Array Adicionais
            object[] adicionais = new object[4];

            adicionais[0] = NProp;
            adicionais[1] = Referencia;
            adicionais[2] = DataInicio;
            adicionais[3] = DataEnvio;

            return adicionais;
        }

        public object[] ParamRodape()
        {
            object[] objects = ObjectWord();

            //Parametro
            object parametro = objects[2];

            //Info Elo
            object Elo = "Elo";
            object Elo1 = "Elo1";
            object linha1 = "Linha1";
            object linha2 = "Linha2";

            //Array Elo
            object[] elo = new object[4];

            elo[0] = Elo;
            elo[1] = Elo1;
            elo[2] = linha1;
            elo[3] = linha2;


            //Retorno
            return elo;
        }

        public object[] ParamObs()
        {
            object[] objects = ObjectWord();

            //Parametro
            object parametro = objects[2];

            //Info Elo
            object Obs1 = "obs1";
            object Obs2 = "obs2";
            object Obs3 = "obs3";
            object Obs4 = "obs4";

            //Array Elo
            object[] obs = new object[4];

            obs[0] = Obs1;
            obs[1] = Obs2;
            obs[2] = Obs3;
            obs[3] = Obs4;


            //Retorno
            return obs;
        }

        /*
            Preenchimento de campos
         */

        public bool EnvioCliente(

                string cliente,
                string Cnpj,
                string Ac,
                string DeptoCli,
                string FoneCli,
                string CelCli,
                string EmailCli,

                string Remetente,
                string DeptoRem,
                string FoneRem,
                string CelRem,
                string EmailRem,

                string Quantidade,
                string Potencia,
                string UnidPotencia,
                string UnidTensao,
                string Dias,

                string Proposta,
                string Referencia,
                string DataInicio,
                string DataEnvio,

                string observacao1,
                string observacao2,
                string observacao3,
                string observacao4,

                string count1,
                string count2,
                string count3,

                RadioButton rec,
                RadioButton serv

            )
        {
            object[] objects = ObjectWord();

            //Aplicação Word
            Word.Application ObjWord = new Word.Application();
            //Documento Word
            Word.Document ObjDoc = ObjWord.Documents.Open(objects[3], objects[0]);

            try
            {
                //object[] objects = ObjectWord();

                object[] arrayCliente = ParamCliente();
                object[] arrayRemetente = ParamRemetente();
                object[] arrayEscopo = ParamEscopo();
                object[] arrayLocacao = ParamLocacao();
                object[] arrayAdd = ParamAdcionais();
                object[] array = ParamRodape();
                object[] arrayObs = ParamObs();

                //Calculo
                double resultado = VerificaDia(Dias, Potencia, count1, count2, count3);
                double[] calculo = Calculo(Potencia, count1, count2, count3);

                //Aplicação Word
                //Word.Application ObjWord = new Word.Application();
                //Documento Word
                //Word.Document ObjDoc = ObjWord.Documents.Open(objects[3], objects[0]);

                /*
                    Elo Recuperadora
                 */
                if (rec.Checked)
                {
                    //Envio Cliente
                    Word.Range nom = ObjDoc.Bookmarks.get_Item(ref arrayCliente[0]).Range;
                    nom.Text = cliente;
                    Word.Range nom2 = ObjDoc.Bookmarks.get_Item(ref arrayCliente[1]).Range;
                    nom2.Text = cliente;
                    Word.Range cnpj = ObjDoc.Bookmarks.get_Item(ref arrayCliente[2]).Range;
                    cnpj.Text = Cnpj;
                    Word.Range ac = ObjDoc.Bookmarks.get_Item(ref arrayCliente[3]).Range;
                    ac.Text = Ac;
                    Word.Range deptocli = ObjDoc.Bookmarks.get_Item(ref arrayCliente[4]).Range;
                    deptocli.Text = DeptoCli;
                    Word.Range fonecli = ObjDoc.Bookmarks.get_Item(ref arrayCliente[5]).Range;
                    fonecli.Text = FoneCli;
                    Word.Range celcli = ObjDoc.Bookmarks.get_Item(ref arrayCliente[6]).Range;
                    celcli.Text = CelCli;
                    Word.Range emailcli = ObjDoc.Bookmarks.get_Item(ref arrayCliente[7]).Range;
                    emailcli.Text = EmailCli;

                    //Envio Remetente
                    Word.Range remetente = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[0]).Range;
                    remetente.Text = Remetente;
                    Word.Range deptorem = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[1]).Range;
                    deptorem.Text = DeptoRem;
                    Word.Range fonerem = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[2]).Range;
                    fonerem.Text = FoneRem;
                    Word.Range celrem = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[3]).Range;
                    celrem.Text = CelRem;
                    Word.Range emailrem = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[4]).Range;
                    emailrem.Text = EmailRem;

                    //Envio Escopo Técnico
                    Word.Range quant = ObjDoc.Bookmarks.get_Item(ref arrayEscopo[0]).Range;
                    quant.Text = Quantidade;
                    Word.Range drive = ObjDoc.Bookmarks.get_Item(ref arrayEscopo[1]).Range;
                    drive.Text = $"Inversor de frequência para motor até {Potencia} {UnidPotencia} / {UnidTensao}";

                    //Envio Locacao
                    Word.Range diaria = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[0]).Range;
                    diaria.Text = $"{calculo[0].ToString("C")}";
                    Word.Range sem = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[1]).Range;
                    sem.Text = $"{calculo[1].ToString("C")}";
                    Word.Range quin = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[2]).Range;
                    quin.Text = $"{calculo[2].ToString("C")}";
                    Word.Range vin = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[3]).Range;
                    vin.Text = $"{calculo[3].ToString("C")}";
                    Word.Range mes = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[4]).Range;
                    mes.Text = $"{calculo[4].ToString("C")}";

                    //Envio Adicional
                    Word.Range nprop = ObjDoc.Bookmarks.get_Item(ref arrayAdd[0]).Range;
                    nprop.Text = Proposta;
                    Word.Range referencia = ObjDoc.Bookmarks.get_Item(ref arrayAdd[1]).Range;
                    referencia.Text = Referencia;
                    Word.Range datainicio = ObjDoc.Bookmarks.get_Item(ref arrayAdd[2]).Range;
                    datainicio.Text = DataInicio;
                    Word.Range dataenvio = ObjDoc.Bookmarks.get_Item(ref arrayAdd[3]).Range;
                    dataenvio.Text = DataEnvio;

                    //Envio Observações
                    Word.Range obs1 = ObjDoc.Bookmarks.get_Item(ref arrayObs[0]).Range;
                    obs1.Text = $"{observacao1} \n";
                    Word.Range obs2 = ObjDoc.Bookmarks.get_Item(ref arrayObs[1]).Range;
                    obs2.Text = $"{observacao2} \n";
                    Word.Range obs3 = ObjDoc.Bookmarks.get_Item(ref arrayObs[2]).Range;
                    obs3.Text = $"{observacao3} \n";
                    Word.Range obs4 = ObjDoc.Bookmarks.get_Item(ref arrayObs[3]).Range;
                    obs4.Text = $"{observacao4} \n";


                    //Rodape 1
                    Word.Range elo = ObjDoc.Bookmarks.get_Item(ref array[0]).Range;
                    elo.Text = "Elo Recuperadora - Serviços de Equipamentos Eletroeletrônicos Ltda.";
                    Word.Range elo1 = ObjDoc.Bookmarks.get_Item(ref array[1]).Range;
                    elo1.Text = "Elo Recuperadora - Serviços de Equipamentos Eletroeletrônicos Ltda.";
                    Word.Range line1 = ObjDoc.Bookmarks.get_Item(ref array[2]).Range;
                    line1.Text = "Rua Iguaçu, nº 38 – Galpão 2 – Vila São Silvestre – Barueri, SP | CEP: 06417-140 | Fone: (11) 4154-4414\r\nCNPJ: 03.097.356/0001-83 | Inscrição Estadual: 206.619.101.118 | Inscrição Municipal: 5.87545-9\r\nPlantão Técnico ELO 24hs: (11) 98208 2914 | (11) 98208 2915";
                    Word.Range line2 = ObjDoc.Bookmarks.get_Item(ref array[3]).Range;
                    line2.Text = "Rua Iguaçu, nº 38 – Galpão 2 – Vila São Silvestre – Barueri, SP | CEP: 06417-140 | Fone: (11) 4154-4414\r\nCNPJ: 03.097.356/0001-83 | Inscrição Estadual: 206.619.101.118 | Inscrição Municipal: 5.87545-9\r\nPlantão Técnico ELO 24hs: (11) 98208 2914 | (11) 98208 2915";

                    //Range Cliente
                    object range0 = nom2;
                    object range1 = nom;
                    object range2 = cnpj;
                    object range3 = ac;
                    object range4 = deptocli;
                    object range5 = fonecli;
                    object range6 = celcli;
                    object range7 = emailcli;
                    //Range Remetente
                    object range8 = remetente;
                    object range9 = deptorem;
                    object range10 = fonerem;
                    object range11 = celrem;
                    object range12 = emailrem;

                    //Range Escopo Técnico
                    object range13 = quant;
                    object range14 = drive;
                    object range15 = diaria;

                    //Range Locação
                    object range19 = sem;
                    object range20 = quin;
                    object range21 = vin;
                    object range22 = mes;

                    //Range Adicionais
                    object range25 = nprop;
                    object range26 = referencia;
                    object range27 = datainicio;
                    object range28 = dataenvio;

                    //Range Info Elo 1
                    object range29 = elo;
                    object range30 = elo1;
                    object range31 = line1;
                    object range32 = line2;

                    //Range Observações
                    object range33 = obs1;
                    object range34 = obs2;
                    object range35 = obs3;
                    object range36 = obs4;

                    //Doc Cliente
                    ObjDoc.Bookmarks.Add("Cliente2", ref range0);
                    ObjDoc.Bookmarks.Add("Cliente1", ref range1);
                    ObjDoc.Bookmarks.Add("CNPJ", ref range2);
                    ObjDoc.Bookmarks.Add("AC", ref range3);
                    ObjDoc.Bookmarks.Add("DeptoCLI", ref range4);
                    ObjDoc.Bookmarks.Add("FoneCLI", ref range5);
                    ObjDoc.Bookmarks.Add("CelCLI", ref range6);
                    ObjDoc.Bookmarks.Add("EmailCLI", ref range7);
                    //Doc Remetente
                    ObjDoc.Bookmarks.Add("Rem", ref range8);
                    ObjDoc.Bookmarks.Add("DeptoRem", ref range9);
                    ObjDoc.Bookmarks.Add("FoneRem", ref range10);
                    ObjDoc.Bookmarks.Add("CelRem", ref range11);
                    ObjDoc.Bookmarks.Add("EmailRem", ref range12);
                    //Doc Escopo
                    ObjDoc.Bookmarks.Add("Quant", ref range13);
                    ObjDoc.Bookmarks.Add("Drive", ref range14);
                    ObjDoc.Bookmarks.Add("Diaria", ref range15);
                    //Doc locação
                    ObjDoc.Bookmarks.Add("Semana", ref range19);
                    ObjDoc.Bookmarks.Add("Quinzena", ref range20);
                    ObjDoc.Bookmarks.Add("VinteDias", ref range21);
                    ObjDoc.Bookmarks.Add("Mes", ref range22);
                    //Doc Adicional
                    ObjDoc.Bookmarks.Add("Proposta", ref range25);
                    ObjDoc.Bookmarks.Add("Referencia", ref range26);
                    ObjDoc.Bookmarks.Add("DataInicio", ref range27);
                    ObjDoc.Bookmarks.Add("DataEnvio", ref range28);
                    //Doc Rodapé
                    ObjDoc.Bookmarks.Add("Elo", ref range29);
                    ObjDoc.Bookmarks.Add("Elo1", ref range30);
                    ObjDoc.Bookmarks.Add("Linha1", ref range31);
                    ObjDoc.Bookmarks.Add("Linha2", ref range32);
                    //Doc Obs
                    ObjDoc.Bookmarks.Add("obs1", ref range33);
                    ObjDoc.Bookmarks.Add("obs2", ref range34);
                    ObjDoc.Bookmarks.Add("obs3", ref range35);
                    ObjDoc.Bookmarks.Add("obs4", ref range36);

                    //Ano do PC
                    int anoAtual = DateTime.Now.Year;

                    try
                    {
                        //string save = $@"O:\Departamentos\Marketing\Compartilhado\TESTE LOCAÇÃO\2023 Propostas\{Proposta}.docx";
                        //string save = $@"C:\Users\Public\{Proposta}.docx";
                        string save = $@"O:\Departamentos\Vendas\Propostas\{anoAtual} Propostas\{Proposta}.docx";
                        ObjDoc.SaveAs2(save);

                        ObjDoc.Close();
                        Marshal.ReleaseComObject(ObjDoc);

                        ObjWord.Quit();
                        Marshal.ReleaseComObject(ObjWord);

                        MessageBox.Show($"Arquivo Salvo: {save}", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            //string save = $@"O:\Departamentos\Marketing\Compartilhado\TESTE LOCAÇÃO\2023 Propostas\{Proposta}.docx";
                            string save = $@"C:\Users\Public\{Proposta}.docx";
                            //string save = $@"O:\Departamentos\Vendas\Propostas\{anoAtual} Propostas\{Proposta}.docx";
                            ObjDoc.SaveAs2(save);

                            ObjDoc.Close();
                            Marshal.ReleaseComObject(ObjDoc);

                            ObjWord.Quit();
                            Marshal.ReleaseComObject(ObjWord);

                            MessageBox.Show($"Arquivo Salvo: {save}", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        catch(Exception exSecundary)
                        {
                            MessageBox.Show("Erro ao Salvar Proposta no caminho Secundario");
                            MessageBox.Show(exSecundary.Message);
                        }

                        MessageBox.Show("Erro ao Salvar Proposta no caminho Original");
                        MessageBox.Show(ex.Message);

                    }

                }
                /*
                    Elo Serviços
                 */
                if (serv.Checked)
                {
                    //Envio Cliente
                    Word.Range nom = ObjDoc.Bookmarks.get_Item(ref arrayCliente[0]).Range;
                    nom.Text = cliente;
                    Word.Range nom2 = ObjDoc.Bookmarks.get_Item(ref arrayCliente[1]).Range;
                    nom2.Text = cliente;
                    Word.Range cnpj = ObjDoc.Bookmarks.get_Item(ref arrayCliente[2]).Range;
                    cnpj.Text = Cnpj;
                    Word.Range ac = ObjDoc.Bookmarks.get_Item(ref arrayCliente[3]).Range;
                    ac.Text = Ac;
                    Word.Range deptocli = ObjDoc.Bookmarks.get_Item(ref arrayCliente[4]).Range;
                    deptocli.Text = DeptoCli;
                    Word.Range fonecli = ObjDoc.Bookmarks.get_Item(ref arrayCliente[5]).Range;
                    fonecli.Text = FoneCli;
                    Word.Range celcli = ObjDoc.Bookmarks.get_Item(ref arrayCliente[6]).Range;
                    celcli.Text = CelCli;
                    Word.Range emailcli = ObjDoc.Bookmarks.get_Item(ref arrayCliente[7]).Range;
                    emailcli.Text = EmailCli;

                    //Envio Remetente
                    Word.Range remetente = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[0]).Range;
                    remetente.Text = Remetente;
                    Word.Range deptorem = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[1]).Range;
                    deptorem.Text = DeptoRem;
                    Word.Range fonerem = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[2]).Range;
                    fonerem.Text = FoneRem;
                    Word.Range celrem = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[3]).Range;
                    celrem.Text = CelRem;
                    Word.Range emailrem = ObjDoc.Bookmarks.get_Item(ref arrayRemetente[4]).Range;
                    emailrem.Text = EmailRem;

                    //Envio Escopo Técnico
                    Word.Range quant = ObjDoc.Bookmarks.get_Item(ref arrayEscopo[0]).Range;
                    quant.Text = Quantidade;
                    Word.Range drive = ObjDoc.Bookmarks.get_Item(ref arrayEscopo[1]).Range;
                    drive.Text = $"Inversor de frequência para motor até {Potencia} {UnidPotencia} / {UnidTensao}";

                    //Envio Locacao
                    Word.Range diaria = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[0]).Range;
                    diaria.Text = $"{calculo[0].ToString("C")}";
                    Word.Range sem = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[1]).Range;
                    sem.Text = $"{calculo[1].ToString("C")}";
                    Word.Range quin = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[2]).Range;
                    quin.Text = $"{calculo[2].ToString("C")}";
                    Word.Range vin = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[3]).Range;
                    vin.Text = $"{calculo[3].ToString("C")}";
                    Word.Range mes = ObjDoc.Bookmarks.get_Item(ref arrayLocacao[4]).Range;
                    mes.Text = $"{calculo[4].ToString("C")}";

                    //Envio Adicional
                    Word.Range nprop = ObjDoc.Bookmarks.get_Item(ref arrayAdd[0]).Range;
                    nprop.Text = Proposta;
                    Word.Range referencia = ObjDoc.Bookmarks.get_Item(ref arrayAdd[1]).Range;
                    referencia.Text = Referencia;
                    Word.Range datainicio = ObjDoc.Bookmarks.get_Item(ref arrayAdd[2]).Range;
                    datainicio.Text = DataInicio;
                    Word.Range dataenvio = ObjDoc.Bookmarks.get_Item(ref arrayAdd[3]).Range;
                    dataenvio.Text = DataEnvio;

                    //Envio Observações
                    Word.Range obs1 = ObjDoc.Bookmarks.get_Item(ref arrayObs[0]).Range;
                    obs1.Text = $"{observacao1} \n";
                    Word.Range obs2 = ObjDoc.Bookmarks.get_Item(ref arrayObs[1]).Range;
                    obs2.Text = $"{observacao2} \n";
                    Word.Range obs3 = ObjDoc.Bookmarks.get_Item(ref arrayObs[2]).Range;
                    obs3.Text = $"{observacao3} \n";
                    Word.Range obs4 = ObjDoc.Bookmarks.get_Item(ref arrayObs[3]).Range;
                    obs4.Text = $"{observacao4} \n";


                    //Rodapé 2
                    Word.Range elo = ObjDoc.Bookmarks.get_Item(ref array[0]).Range;
                    elo.Text = "Elo Serviços Comércio de Equipamentos Eletroeletrônicos Ltda";
                    Word.Range elo1 = ObjDoc.Bookmarks.get_Item(ref array[1]).Range;
                    elo1.Text = "Elo Serviços Comércio de Equipamentos Eletroeletrônicos Ltda";
                    Word.Range line1 = ObjDoc.Bookmarks.get_Item(ref array[2]).Range;
                    line1.Text = "Rua Iguaçu, nº 38 – Vila São Silvestre – Barueri, SP | CEP: 06417-140 | Fone: (11) 4154-4414\r\nCNPJ: 03.977.120/0001-31 | Inscrição Estadual: 206.272.644.110 | Inscrição Municipal: 5.53733-1\r\nPlantão Técnico ELO 24hs: (11) 98208 2914 | (11) 98208 2915";
                    Word.Range line2 = ObjDoc.Bookmarks.get_Item(ref array[3]).Range;
                    line2.Text = "Rua Iguaçu, nº 38 – Vila São Silvestre – Barueri, SP | CEP: 06417-140 | Fone: (11) 4154-4414\r\nCNPJ: 03.977.120/0001-31 | Inscrição Estadual: 206.272.644.110 | Inscrição Municipal: 5.53733-1\r\nPlantão Técnico ELO 24hs: (11) 98208 2914 | (11) 98208 2915";


                    //Range Cliente
                    object range0 = nom2;
                    object range1 = nom;
                    object range2 = cnpj;
                    object range3 = ac;
                    object range4 = deptocli;
                    object range5 = fonecli;
                    object range6 = celcli;
                    object range7 = emailcli;
                    //Range Remetente
                    object range8 = remetente;
                    object range9 = deptorem;
                    object range10 = fonerem;
                    object range11 = celrem;
                    object range12 = emailrem;

                    //Range Escopo Técnico
                    object range13 = quant;
                    object range14 = drive;
                    object range15 = diaria;

                    //Range Locação
                    object range19 = sem;
                    object range20 = quin;
                    object range21 = vin;
                    object range22 = mes;

                    //Range Adicionais
                    object range25 = nprop;
                    object range26 = referencia;
                    object range27 = datainicio;
                    object range28 = dataenvio;

                    //Range Info Elo 1
                    object range29 = elo;
                    object range30 = elo1;
                    object range31 = line1;
                    object range32 = line2;

                    //Range Observações
                    object range33 = obs1;
                    object range34 = obs2;
                    object range35 = obs3;
                    object range36 = obs4;

                    //Doc Cliente
                    ObjDoc.Bookmarks.Add("Cliente2", ref range0);
                    ObjDoc.Bookmarks.Add("Cliente1", ref range1);
                    ObjDoc.Bookmarks.Add("CNPJ", ref range2);
                    ObjDoc.Bookmarks.Add("AC", ref range3);
                    ObjDoc.Bookmarks.Add("DeptoCLI", ref range4);
                    ObjDoc.Bookmarks.Add("FoneCLI", ref range5);
                    ObjDoc.Bookmarks.Add("CelCLI", ref range6);
                    ObjDoc.Bookmarks.Add("EmailCLI", ref range7);
                    //Doc Remetente
                    ObjDoc.Bookmarks.Add("Rem", ref range8);
                    ObjDoc.Bookmarks.Add("DeptoRem", ref range9);
                    ObjDoc.Bookmarks.Add("FoneRem", ref range10);
                    ObjDoc.Bookmarks.Add("CelRem", ref range11);
                    ObjDoc.Bookmarks.Add("EmailRem", ref range12);
                    //Doc Escopo
                    ObjDoc.Bookmarks.Add("Quant", ref range13);
                    ObjDoc.Bookmarks.Add("Drive", ref range14);
                    ObjDoc.Bookmarks.Add("Diaria", ref range15);
                    //Doc locação
                    ObjDoc.Bookmarks.Add("Semana", ref range19);
                    ObjDoc.Bookmarks.Add("Quinzena", ref range20);
                    ObjDoc.Bookmarks.Add("VinteDias", ref range21);
                    ObjDoc.Bookmarks.Add("Mes", ref range22);
                    //Doc Adicional
                    ObjDoc.Bookmarks.Add("Proposta", ref range25);
                    ObjDoc.Bookmarks.Add("Referencia", ref range26);
                    ObjDoc.Bookmarks.Add("DataInicio", ref range27);
                    ObjDoc.Bookmarks.Add("DataEnvio", ref range28);
                    //Doc Rodapé
                    ObjDoc.Bookmarks.Add("Elo", ref range29);
                    ObjDoc.Bookmarks.Add("Elo1", ref range30);
                    ObjDoc.Bookmarks.Add("Linha1", ref range31);
                    ObjDoc.Bookmarks.Add("Linha2", ref range32);
                    //Doc Obs
                    ObjDoc.Bookmarks.Add("obs1", ref range33);
                    ObjDoc.Bookmarks.Add("obs2", ref range34);
                    ObjDoc.Bookmarks.Add("obs3", ref range35);
                    ObjDoc.Bookmarks.Add("obs4", ref range36);

                    //Ano do PC
                    int anoAtual = DateTime.Now.Year;

                    try
                    {
                        //string save = $@"O:\Departamentos\Marketing\Compartilhado\TESTE LOCAÇÃO\2023 Propostas\{Proposta}.docx";
                        //string save = $@"C:\Users\Public\{Proposta}.docx";
                        string save = $@"O:\Departamentos\Vendas\Propostas\{anoAtual} Propostas\{Proposta}.docx";
                        ObjDoc.SaveAs2(save);

                        ObjDoc.Close();
                        Marshal.ReleaseComObject(ObjDoc);

                        ObjWord.Quit();
                        Marshal.ReleaseComObject(ObjWord);

                        MessageBox.Show($"Arquivo Salvo: {save}", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            //string save = $@"O:\Departamentos\Marketing\Compartilhado\TESTE LOCAÇÃO\2023 Propostas\{Proposta}.docx";
                            string save = $@"C:\Users\Public\{Proposta}.docx";
                            //string save = $@"O:\Departamentos\Vendas\Propostas\{anoAtual} Propostas\{Proposta}.docx";
                            ObjDoc.SaveAs2(save);

                            ObjDoc.Close();
                            Marshal.ReleaseComObject(ObjDoc);

                            ObjWord.Quit();
                            Marshal.ReleaseComObject(ObjWord);

                            MessageBox.Show($"Arquivo Salvo: {save}", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        catch (Exception exSecundary)
                        {
                            MessageBox.Show("Erro ao Salvar Proposta no caminho Secundario");
                            MessageBox.Show(exSecundary.Message);
                        }

                        MessageBox.Show("Erro ao Salvar Proposta no caminho Original");
                        MessageBox.Show(ex.Message);

                    }

                }

                MessageBox.Show("Proposta gerada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar proposta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"{ex}");

                if (ObjDoc != null)
                {
                    ObjDoc.Close();
                    Marshal.ReleaseComObject(ObjDoc);
                }

                if (ObjWord != null)
                {
                    ObjWord.Quit();
                    Marshal.ReleaseComObject(ObjWord);
                }

                return true;
            }
        }
    }
}
