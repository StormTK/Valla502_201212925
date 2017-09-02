using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valla502_201212925
{
    class AnalizadorLexico
    {
        List<Tuple<int, String, int, int, int, String>> Tokens = new List<Tuple<int, String, int, int, int, String>>();
        List<Tuple<int, int, int, String>> Errores = new List<Tuple<int, int, int, String>>();
        List<Tuple<int, int, int>> Pixeles = new List<Tuple<int, int, int>>();

        String NombreEmpresa = "";//Nombre de la Empresa
        String Fondo_X = "";
        String Fondo_Y = "";
        String Pixel_X = "";
        String Pixel_Y = "";
        Char[] Letra; //Almacena cada uno de las letras del texto.

        int contadorPixel = 0;
        int Fondo_Color = 0;
        int tamaño_TextoAnalizar = 0;
        int posicion_InicialToken = 0;
        int posicion_TextoAnalizado = 0;
        int candidadTokens = 0;
        int cantidadErrores = 0;
        int NoFila = 1;
        int NoColumna = 1;

        public void AnalizarTexto(String TextoAnalizar)
        {
            try
            {
                Fondo_Color = 0;
                tamaño_TextoAnalizar = 0;
                posicion_InicialToken = 0;
                posicion_TextoAnalizado = 0;
                candidadTokens = 0;
                cantidadErrores = 0;
                NoFila = 1;
                NoColumna = 1;
                Pixeles.RemoveRange(0, Pixeles.Count);
                Tokens.RemoveRange(0, Tokens.Count);
                Errores.RemoveRange(0, Errores.Count);

                Letra = TextoAnalizar.ToCharArray();
                tamaño_TextoAnalizar = Letra.Length;
                S1(Letra[posicion_TextoAnalizado]);
            }
            catch (Exception)
            {
            }
        }
        public Boolean AgregarTokens(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "'<'", NoFila, NoColumna, opcion, "Signo Menor que"));
                        return true;
                    }
                case 2:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "VALLA", posicion_InicialToken, NoColumna, opcion, "Reservada VALLA"));
                        return true;
                    }
                case 3:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "'>'", posicion_InicialToken, NoColumna, opcion, "Signo Mayor que"));
                        return true;
                    }
                case 4:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "EMPRESA", posicion_InicialToken, NoColumna, opcion, "Reservada EMPRESA"));
                        return true;
                    }
                case 5:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, NombreEmpresa, posicion_InicialToken, NoColumna, opcion, "ID Empresa"));
                        return true;
                    }
                case 6:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "'/'", posicion_InicialToken, NoColumna, opcion, "Cierre Etiqueta"));
                        return true;
                    }
                case 7:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "FONDO", posicion_InicialToken, NoColumna, opcion, "Reservada FONDO"));
                        return true;
                    }
                case 8:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "TAMANIO", posicion_InicialToken, NoColumna, opcion, "Reservada TAMANIO"));
                        return true;
                    }
                case 9:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "HORIZONTAL", posicion_InicialToken, NoColumna, opcion, "Reservada HORIZONTAL"));
                        return true;
                    }
                case 10:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, Fondo_X, posicion_InicialToken, NoColumna, opcion, "Numero - LARGO DEL FONDO"));
                        return true;
                    }
                case 11:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "VERTICAL", posicion_InicialToken, NoColumna, opcion, "Reservada VERTICAL"));
                        return true;
                    }
                case 12:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, Fondo_Y, posicion_InicialToken, NoColumna, opcion, "Numero - ALTO DEL FONDO"));
                        return true;
                    }
                case 13:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "COLOR", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR"));
                        return true;
                    }
                case 14:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "AMARILLO", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR AMARIOLLO"));
                        return true;
                    }
                case 15:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "AZUL", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR AZUL"));
                        return true;
                    }
                case 16:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "ROJO", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR ROJO"));
                        return true;
                    }
                case 17:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "VERDE", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR VERDE"));
                        return true;
                    }
                case 18:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "PIXEL", posicion_InicialToken, NoColumna, opcion, "Reservada PXIEL"));
                        return true;
                    }
                case 19:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "POCISIONX", posicion_InicialToken, NoColumna, opcion, "Reservada POSICIONX"));
                        return true;
                    }
                case 20:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, Pixel_X, posicion_InicialToken, NoColumna, opcion, "Numero - POSICION X DEL PIXEL"));
                        return true;
                    }
                case 21:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "POCISIONY", posicion_InicialToken, NoColumna, opcion, "Reservada POSICIONY"));
                        return true;
                    }
                case 22:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, Pixel_Y, posicion_InicialToken, NoColumna, opcion, "Numero - POSICION Y DEL PIXEL"));
                        return true;
                    }
            }
            return false;
        }
        public Boolean LeerEnterEspacioTab(char letraAnalizada)
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizada == 09)
                {
                    NoFila += 5;
                    posicion_TextoAnalizado++;
                }
                else if (letraAnalizada == 10)
                {
                    NoColumna++;
                    NoFila = 1;
                    posicion_TextoAnalizado++;
                }
                else if (letraAnalizada == 13)
                {
                    posicion_TextoAnalizado++;
                }
                else if (letraAnalizada == 32)
                {
                    NoColumna++;
                    NoFila = 1;
                    posicion_TextoAnalizado++;
                }
                else
                {
                    cantidadErrores++;
                    Errores.Add(new Tuple<int, int, int, string>(cantidadErrores, NoFila, NoColumna, letraAnalizada.ToString()));
                    posicion_TextoAnalizado++;
                    NoFila++;
                }
                return true;
            }
            else
            {
                return true;
            }

        }
        public List<Tuple<int, String, int, int, int, String>> getHTMLToken()
        {
            return Tokens;
        }
        public List<Tuple<int, int, int, String>> getHTMLError()
        {
            return Errores;
        }
        public List<Tuple<int, int, int>> getLista()
        {
            return Pixeles;
        }
        public int getTamañoFondoX()
        {
            int Fondox = Convert.ToInt32(Fondo_X) * 20;
            return Fondox;
        }
        public int getTamañoFondoY()
        {
            int Fondoy = Convert.ToInt32(Fondo_Y) * 20;
            return Fondoy;
        }
        public int getCantidadErrores()
        {
            return cantidadErrores;
        }
        public int getColorFondo()
        {
            return Fondo_Color;
        }
        private void S1(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S2(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S1(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S2(char letraAnalizar)//v
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'v' || letraAnalizar == 'V')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S3(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S2(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S3(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S4(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S3(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S4(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S5(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S4(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S5(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S6(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S5(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S6(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    candidadTokens++;
                    AgregarTokens(2);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S7(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S6(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S7(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S8(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S7(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S8(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S9(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S8(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S9(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S10(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S9(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S10(char letraAnalizar)//m
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'm' || letraAnalizar == 'M')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S11(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S10(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S11(char letraAnalizar)//p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'p')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S12(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S11(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S12(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S13(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S12(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S13(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S14(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S13(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S14(char letraAnalizar)//s
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S15(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S14(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S15(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    candidadTokens++;
                    AgregarTokens(4);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S16(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S15(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S16(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S17(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S16(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S17(char letraAnalizar)//LDS>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar != '<')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    NombreEmpresa = letraAnalizar.ToString();
                    S18(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    AgregarTokens(1);
                    S19(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S18(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S19(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    NombreEmpresa += letraAnalizar.ToString();
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S18(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S19(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S20(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S19(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S20(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S21(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S20(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S21(char letraAnalizar)//m
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'm' || letraAnalizar == 'M')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S22(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S21(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S22(char letraAnalizar)//p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'p')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S23(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S22(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S23(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S24(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S23(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S24(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S25(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S24(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S25(char letraAnalizar)//s
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S26(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S25(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S26(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    candidadTokens++;
                    AgregarTokens(4);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S27(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S26(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S27(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S28(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S27(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S28(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S29(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S28(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S29(char letraAnalizar)//f
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'f' || letraAnalizar == 'F')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S30(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S29(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S30(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S31(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S30(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S31(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S32(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S31(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S32(char letraAnalizar)//d
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'd' || letraAnalizar == 'D')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S33(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S32(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S33(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(7);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S34(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S33(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S34(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S35(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S34(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S35(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S36(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S35(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S36(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S37(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S36(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S37(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S38(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S37(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S38(char letraAnalizar)//m
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'm' || letraAnalizar == 'M')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S39(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S38(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S39(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S40(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S39(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S40(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S41(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S40(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S41(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S42(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S41(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S42(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(8);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S43(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S42(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S43(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S44(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S43(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S44(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S45(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S44(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S45(char letraAnalizar)//h
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'h' || letraAnalizar == 'H')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S46(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S45(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S46(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S47(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S46(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S47(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S48(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S47(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S48(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S49(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S48(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S49(char letraAnalizar)//z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S50(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S49(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S50(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S51(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S50(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S51(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S52(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S51(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S52(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S53(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S52(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S53(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S54(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S53(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S54(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(9);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S55(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S54(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S55(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S56(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S55(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S56(char letraAnalizar)//D
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    Fondo_X = letraAnalizar.ToString();
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S57(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S56(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S57(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(10);
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S58(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    Fondo_X += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S57(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S57(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S58(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S59(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S58(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S59(char letraAnalizar)//h
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'h' || letraAnalizar == 'H')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S60(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S59(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S60(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S61(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S60(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S61(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S62(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S61(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S62(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S62(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S63(char letraAnalizar)//z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S64(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S63(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S64(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S65(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S64(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S65(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S66(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S65(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S66(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S67(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S66(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S67(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S68(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S67(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S68(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(9);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S69(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S68(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S69(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S70(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S69(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S70(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S71(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S70(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S71(char letraAnalizar)//v
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'v' || letraAnalizar == 'V')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S72(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S71(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S72(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S73(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S72(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S73(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S74(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S73(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S74(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S75(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S74(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S75(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S76(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S75(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S76(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S77(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S76(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S77(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S78(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S77(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S78(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(11);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S79(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S78(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S79(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S80(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S79(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S80(char letraAnalizar)//D
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    Fondo_Y = letraAnalizar.ToString();
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S81(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S80(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S81(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(12);
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S82(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    Fondo_Y += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S81(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S81(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S82(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S83(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S82(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S83(char letraAnalizar)//v
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'v' || letraAnalizar == 'V')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S84(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S83(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S84(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'E' || letraAnalizar == 'e')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S85(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S84(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S85(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S86(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S85(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S86(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S87(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S86(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S87(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S88(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S87(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S88(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S89(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S88(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S89(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S90(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S89(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S90(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(11);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S91(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S90(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S91(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S92(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S91(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S92(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S93(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S92(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S93(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S94(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S93(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S94(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S95(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S94(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S95(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S96(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S95(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S96(char letraAnalizar)//m
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'm' || letraAnalizar == 'M')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S97(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S96(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S97(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S98(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S97(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S98(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S99(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S98(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S99(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S100(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S99(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S100(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(8);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S101(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S100(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S101(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S102(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S101(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S102(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S103(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S102(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S103(char letraAnalizar)//c o /
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S104(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S139(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S103(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S104(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S105(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S104(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S105(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S106(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S105(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S106(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S107(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S106(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S107(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(13);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S108(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S107(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S108(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S109(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S108(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S109(char letraAnalizar)//a o r o v
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S110(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S121(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'v' || letraAnalizar == 'V')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S125(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S109(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S110(char letraAnalizar)//m o z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'm' || letraAnalizar == 'M')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S111(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S118(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S110(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S111(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S112(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S111(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S112(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S113(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S112(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S113(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S114(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S113(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S114(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S115(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S114(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S115(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S116(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S115(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S116(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(14);
                    Fondo_Color = 1;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S117(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S116(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S117(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S130(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S117(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S118(char letraAnalizar)//u
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'u' || letraAnalizar == 'U')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S119(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S118(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S119(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(15);
                    Fondo_Color = 2;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S120(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S119(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S120(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S130(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S120(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S121(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S122(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S121(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S122(char letraAnalizar)//j
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'j' || letraAnalizar == 'J')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S123(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S122(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S123(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(16);
                    Fondo_Color = 3;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S124(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S123(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S124(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S130(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S124(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S125(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S126(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S125(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S126(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S127(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S126(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S127(char letraAnalizar)//d
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'd' || letraAnalizar == 'D')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S128(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S127(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S128(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    candidadTokens++;
                    AgregarTokens(17);
                    Fondo_Color = 4;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S129(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S128(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S129(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S130(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S129(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S130(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S131(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S130(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S131(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S132(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S131(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S132(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S133(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S132(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S133(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S134(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S133(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S134(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S135(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S134(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S135(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(13);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S136(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S135(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S136(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S137(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S136(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S137(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S138(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S137(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S138(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S139(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S138(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S139(char letraAnalizar)//f
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'f' || letraAnalizar == 'F')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S140(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S139(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S140(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S141(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S140(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S141(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S142(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S141(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S142(char letraAnalizar)//d
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'd' || letraAnalizar == 'D')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S143(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S142(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S143(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(7);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S144(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S143(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S144(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S145(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S144(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S145(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S146(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S145(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S146(char letraAnalizar)//p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S147(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S146(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S147(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S148(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S147(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S148(char letraAnalizar)//x
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'x' || letraAnalizar == 'X')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S149(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S148(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S149(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S150(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S149(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S150(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(18);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S151(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S150(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S151(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S152(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S151(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S152(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S153(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S152(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S153(char letraAnalizar)//p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S153(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S154(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S155(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S154(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S155(char letraAnalizar)//s
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S156(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S155(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S156(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S157(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S156(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S157(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S158(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S157(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S158(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S159(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S158(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S159(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S160(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S159(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S160(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S161(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S160(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S161(char letraAnalizar)//x
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'x' || letraAnalizar == 'X')
                {
                    candidadTokens++;
                    AgregarTokens(19);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S162(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S161(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S162(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S163(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S162(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S163(char letraAnalizar)//D
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    Pixel_X = letraAnalizar.ToString();
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S164(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S163(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S164(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(20);
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S165(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    Pixel_X += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S164(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S164(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S165(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S166(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S165(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S166(char letraAnalizar)//p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S167(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S166(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S167(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S168(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S167(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S168(char letraAnalizar)//s
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S169(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S168(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S169(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S170(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S169(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S170(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S171(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S170(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S171(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S172(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S171(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S172(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S173(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S172(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S173(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S174(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S173(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S174(char letraAnalizar)//x
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'x' || letraAnalizar == 'X')
                {
                    candidadTokens++;
                    AgregarTokens(19);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S175(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S174(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S175(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S176(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S175(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S176(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S177(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S176(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S177(char letraAnalizar)//p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S178(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S177(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S178(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S179(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S178(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S179(char letraAnalizar)//s
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S180(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S179(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S180(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S181(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S180(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S181(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S182(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S181(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S182(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S183(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S182(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S183(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S184(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S182(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S184(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S185(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S184(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S185(char letraAnalizar)//y
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'y' || letraAnalizar == 'Y')
                {
                    candidadTokens++;
                     AgregarTokens(21);              
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S186(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S185(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S186(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    if (contadorPixel > 100)
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S187(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S186(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S187(char letraAnalizar)//D
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    Pixel_Y = letraAnalizar.ToString();
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S188(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S187(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S188(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(22);
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S189(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    Pixel_Y += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S188(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S188(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S189(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S190(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S189(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S190(char letraAnalizar)//p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S191(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S190(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S191(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S192(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S191(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S192(char letraAnalizar)//s
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S193(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S192(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S193(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S194(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S193(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S194(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S195(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S194(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S195(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S196(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S195(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S196(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S197(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S196(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S197(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S198(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S197(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S198(char letraAnalizar)//y
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'y' || letraAnalizar == 'Y')
                {
                    candidadTokens++;
                   AgregarTokens(22);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S199(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S198(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S199(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S200(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S199(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S200(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S201(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S200(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S201(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S202(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S201(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S202(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S203(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S202(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S203(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S204(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S203(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S204(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S205(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S204(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S205(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(13);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S206(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S205(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S206(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S207(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S206(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S207(char letraAnalizar)//a o r o v
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S208(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S219(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'v' || letraAnalizar == 'V')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S223(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S207(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S208(char letraAnalizar)//m o z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'm' || letraAnalizar == 'M')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S209(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S216(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S208(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S209(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S210(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S209(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S210(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S211(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S210(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S211(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S212(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S211(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S212(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S213(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S212(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S213(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S214(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S213(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S214(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(14);
                    Pixeles.Add(new Tuple<int, int, int>(Convert.ToInt32(Pixel_X), Convert.ToInt32(Pixel_Y), 1));
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S215(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S214(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S215(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S228(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S117(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S216(char letraAnalizar)//u
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'u' || letraAnalizar == 'U')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S217(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S216(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S217(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(15);
                    Pixeles.Add(new Tuple<int, int, int>(Convert.ToInt32(Pixel_X), Convert.ToInt32(Pixel_Y), 2));
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S218(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S217(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S218(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S228(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S218(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S219(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S220(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S219(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S220(char letraAnalizar)//j
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'j' || letraAnalizar == 'J')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S221(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S220(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S221(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(16);
                    Pixeles.Add(new Tuple<int, int, int>(Convert.ToInt32(Pixel_X), Convert.ToInt32(Pixel_Y), 3));
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S222(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S221(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S222(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S228(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S222(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S223(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S224(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S223(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S224(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S225(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S224(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S225(char letraAnalizar)//d
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'd' || letraAnalizar == 'D')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S226(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S225(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S226(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    candidadTokens++;
                    AgregarTokens(17);
                    Pixeles.Add(new Tuple<int, int, int>(Convert.ToInt32(Pixel_X), Convert.ToInt32(Pixel_Y), 4));
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S227(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S226(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S227(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S228(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S227(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S228(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S229(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S228(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S229(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S230(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S229(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S230(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S231(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S230(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S231(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S232(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S231(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S232(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S233(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S232(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S233(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(13);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S234(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S233(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S234(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S235(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S234(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S235(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                   AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S236(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S235(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S236(char letraAnalizar)//slash
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S237(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S236(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S237(char letraAnalizar)//p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S238(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S237(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S238(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S239(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S238(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S239(char letraAnalizar)//x
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'x' || letraAnalizar == 'X')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S240(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S239(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S240(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S241(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S240(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S241(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(18);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S242(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S241(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S242(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S243(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S242(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S243(char letraAnalizar)//<
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '<')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S244(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S243(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S244(char letraAnalizar)//slash o p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '/')
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S245(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    contadorPixel++;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S147(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S244(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S245(char letraAnalizar)//v
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'v' || letraAnalizar == 'V')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S246(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S245(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S246(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S247(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S246(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S247(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S248(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S247(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S248(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S249(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S248(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S249(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    candidadTokens++;
                    AgregarTokens(2);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S250(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S249(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S250(char letraAnalizar)//>
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '>')
                {
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S250(Letra[posicion_TextoAnalizado]);
                }
            }
        }
    }
}
