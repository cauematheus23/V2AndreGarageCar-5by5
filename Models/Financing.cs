using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Financing
    {
        public static string INSERT = "INSERT INTO Financing (SaleId, FinancingDate, BankCNPJ) VALUES (@SaleId, @FinancingDate, @BankCNPJ)";
        public static string SELECT = "SELECT SaleId,FinancingDate,BankCNPJ from Financing";
        public static string SELECTBYID = "SELECT SaleId,FinancingDate,BankCNPJ from Financing WHERE Id = @Id";
        public int Id { get; set; }
        public Sale Sale { get; set; }
        public DateTime FinancingDate { get; set; }
        public Bank Bank { get; set; }
    }
}
