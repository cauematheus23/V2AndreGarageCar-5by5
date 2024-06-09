﻿using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Person
    {
        public Position Position { get; set; }
        public Decimal ComissionValue { get; set; } // Porcentagem
        public Decimal Comission { get; set; } //
        

        public Employee()
        {

        }
        public Employee(EmployeeDTO employeeDTO)
        {
            this.Document = employeeDTO.Document;
            this.Name = employeeDTO.Name;
            this.BirthDate = employeeDTO.BirthDate;

            this.Phone = employeeDTO.Phone;
            this.Email = employeeDTO.Email;
            Position p = new Position { Id = employeeDTO.PositionId };
            this.Position = p;
            this.ComissionValue = employeeDTO.EmployeeComissionValue;
            this.Comission = employeeDTO.EmployeeComission;
        }
    }
}
