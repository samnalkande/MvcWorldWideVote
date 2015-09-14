//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Anketa_Proekt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    
    public partial class Louse
    {
        public Louse()
        {
            this.Anketas = new HashSet<Anketa>();
            this.Glasas = new HashSet<Glasa>();
            this.Komentar_Za = new HashSet<Komentar_Za>();
            this.Ogranicuvanjas = new HashSet<Ogranicuvanja>();
        }

        [Key]
        public int id_lice { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Name: ")]
        public string ime { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Surname: ")]
        public string prezime { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(30)]
        [Display(Name = "Email: ")]
        public string e_mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(40, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string lozinka { get; set; }

        [Required]
        [StringLength(9)]
        [Display(Name = "Mobile number: ")]
        public string tel_broj { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Street: ")]
        public string ulica { get; set; }

        [Required]
        [Display(Name = "Date of birth: ")]
        public System.DateTime datum_r { get; set; }

        [Required]
        [Display(Name = "City: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<int> id_grad { get; set; }
    
        public virtual ICollection<Anketa> Anketas { get; set; }
        public virtual ICollection<Glasa> Glasas { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual ICollection<Komentar_Za> Komentar_Za { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Premium_Korisnik Premium_Korisnik { get; set; }
        public virtual ICollection<Ogranicuvanja> Ogranicuvanjas { get; set; }

        public bool isValidUser(string email, string pass)
        {
            using (var cn = new SqlConnection(@"Data Source=KAZAKOV\SQLEXPRESS;Initial Catalog=Anketi;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                string sql = @"select [e_mail], [lozinka] from [dbo].[Lice] where [e_mail] = @eMail and [lozinka] = @pass";

                var cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(new SqlParameter("@eMail", SqlDbType.NVarChar)).Value = email;

                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar)).Value = pass;


                cn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }
    }
}
