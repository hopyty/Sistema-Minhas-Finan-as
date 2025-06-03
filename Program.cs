namespace Sistema_Minhas_Finanças
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaBemVindo());
        }
        public static class Sessao
        {
            public static int IdUsuarioLogado { get; set; }
            public static string NomeUsuarioLogado { get; set; }
            public static int idcontalancamento { get; set; }
        }

        public static class categoria
        {
            public static int categorialancamento { get; set; }
            public static string tipocategoria { get; set; }


        }
    }

}