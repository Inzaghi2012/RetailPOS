﻿using System;
using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Order;

namespace RetailPOS.CommonLayer.DataTransferObjects.User
{
    public class StaffDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Designation_Id { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime Hire_Date { get; set; }
        public int Status_Id { get; set; }
        public string Image_Path { get; set; }
        public int Department_Id { get; set; }
        public long Address_Id { get; set; }
        public string OpenId_Id { get; set; }
        public int OpenId_Server_Id { get; set; }
        public string Password { get; set; }
        public int Security_Group_Id { get; set; }      
    }
}