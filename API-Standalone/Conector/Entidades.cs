using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Conector
{
    [Table("RAZA")]
    public class raza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        [StringLength(200)]
        public string descripcion { get; set; }
    }

    [Table("MASCOTA")]
    public class mascota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(80)]
        public string nombre { get; set; }
        public int codigo_raza { get; set; }
        [Required]
        [StringLength(20)]
        public string estado { get; set; }
        public DateTime fecha_ingreso { get; set; }
        [StringLength(300)]
        public string descripcion { get; set; }
    }

    [Table("ADOPTANTE")]
    public class adoptante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }
        [Required]
        [StringLength(30)]
        [Index(IsUnique = true)]
        public string documento { get; set; }
        [Required]
        [StringLength(30)]
        public string telefono { get; set; }
        [StringLength(100)]
        public string correo { get; set; }
    }

    [Table("ADOPCION")]
    public class adopcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int id_mascota { get; set; }
        public int id_adoptante { get; set; }
        public DateTime fecha { get; set; }
        [Required]
        [StringLength(20)]
        public string estado { get; set; }
    }

    [Table("USUARIOS")]
    public class usuarios
    {
        [Key]
        [StringLength(30)]
        public string usuario { get; set; }
        [Required]
        [StringLength(30)]
        public string clave { get; set; }
        [Required]
        [StringLength(20)]
        public string rol { get; set; }
    }

    public class ElAmparoEntities : DbContext
    {
        public ElAmparoEntities() : base("name=ElAmparoEntities")
        {
        }

        public DbSet<raza> raza { get; set; }
        public DbSet<mascota> mascota { get; set; }
        public DbSet<adoptante> adoptante { get; set; }
        public DbSet<adopcion> adopcion { get; set; }
        public DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    }
}