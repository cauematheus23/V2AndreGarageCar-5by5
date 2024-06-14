using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dependant: Person
    {
        public static string INSERT = "INSERT INTO Dependant(Document, Name, BirthDate, AdressId, Phone, Email, ClientDocument) VALUES " +
            "(@Document, @Name, @BirthDate, @AdressId, @Phone, @Email, @ClientDocument)";
        public Client Client { get; set; }
    }
}
