
namespace NORWorkshops
{

    public class Workshop
    {
        public string? Bedriftsnavn { get; set; } 
        public string? Adresse { get; set; }
        public int? Postnummer { get; set; }
        public string? Poststed { get; set; }
        public string? Godkjenningstyper { get; set; }
        public int? Organisasjonsnummer { get; set; }
        public int? Godkjenningsnummer { get; set; }

        public Workshop(
            string bedriftsnavn, 
            string adresse, 
            int postnummer, 
            string poststed, 
            string godkjenningstyper, 
            int organisasjonsnummer, 
            int godkjenningsnummer
            )
        {
            Bedriftsnavn = bedriftsnavn;
            Adresse = adresse;
            Postnummer = postnummer;
            Poststed = poststed;
            Godkjenningstyper = godkjenningstyper;
            Organisasjonsnummer = organisasjonsnummer;
            Godkjenningsnummer = godkjenningsnummer;
        }

        public Workshop(){}

        public void Show()
        {
            Console.WriteLine(Bedriftsnavn);
            Console.WriteLine(Adresse);
            Console.WriteLine(Postnummer);
            Console.WriteLine(Poststed);
            Console.WriteLine(Godkjenningstyper);
            Console.WriteLine(Godkjenningsnummer);
            Console.WriteLine(Organisasjonsnummer);
        }

        public int GetPostnummer()
        {
            if (Postnummer == null) return 0;
            var postnummerStr = Convert.ToString(Postnummer);
            if (postnummerStr!.Length == 3)
            {
                postnummerStr = "0" + postnummerStr;
            }

            if (postnummerStr!.Length == 2)
            {
                postnummerStr = "00" + postnummerStr;
            }

            return Convert.ToInt32(postnummerStr);
        }
    }
}