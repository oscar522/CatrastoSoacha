﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.AccountViewModels
{
    public class RegisterViewModel
    {        
        [EmailAddress(ErrorMessage = "El email es invalido.")]
        [Required(ErrorMessage = "Email es requerido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contraseña es requerido.")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmacion Contraseña es requerido.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmacion Contraseña")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "La contraseña y su confirmacion no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Documento es requerido.")]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Tipo Documento es requerido.")]
        [Display(Name = "Tipo Documento")]
        public int  TipoDocumento { get; set; }

        [Required(ErrorMessage = "Nombres es requerido.")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido.")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Rol es requerido.")]
        [Display(Name = "Rol")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "Telefono es requerido.")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        public SelectList Roles { get; set; }

        public SelectList TiposDocumento { get; set; }

    }
}