﻿namespace UI.WebMatricula3C2023.Models.Users
{
    public class User
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Estado { get; set; }
        public string Token { get; set; }
    }
}
