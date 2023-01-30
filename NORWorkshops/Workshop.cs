using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public int GetPostnummer()
        {
            var postnummerStr = Convert.ToString(Postnummer);
            if (postnummerStr.Length == 3)
            {
                postnummerStr = "0" + postnummerStr;
            }
            if (postnummerStr.Length == 2)
            {
                postnummerStr = "00" + postnummerStr;
            }
            return Convert.ToInt32(postnummerStr);
        }
    }
}