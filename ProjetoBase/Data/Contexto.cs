namespace ProjetoBase.Data
{
    using ProjetoBase.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Contexto : DbContext
    {
        
        public Contexto()
            : base("name=Contexto")
        {
        }

        
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }

   
}