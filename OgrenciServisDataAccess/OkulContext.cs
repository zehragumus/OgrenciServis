using Microsoft.EntityFrameworkCore;
using OgrenciServis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.DataAccess
{
    public class OkulContext: DbContext // base class kalıtım aldığın kodlar
    {
        //Constructor
        public OkulContext(DbContextOptions<OkulContext> options) : base(options)
        {

            // postgreSQL DB kullandığımız için zorunlu Tarih formatını C# ile uyumlu hale getirmek için
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet <Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<Sinav> Sinavlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ders>(entity =>
            {
                entity.ToTable("dersler", "public");

                entity.HasKey(e => e.DersId).HasName("dersler_pk");
            });

            modelBuilder.Entity<Ogrenci>(entity =>
            {
                entity.ToTable("ogrenciler", "public");

                entity.HasKey(e => e.OgrenciId).HasName("ogrenciler_pk");
            });
            modelBuilder.Entity<Ogretmen>(entity =>
            {
                entity.ToTable("ogretmenler", "public");

                entity.HasKey(e => e.OgretmenId).HasName("ogretmenler_pk");
            });
            modelBuilder.Entity<Sinav>(entity =>
            {
                entity.ToTable("sinavlar", "public");

                entity.HasKey(e => e.SinavId).HasName("sinavlar_pk");
            });
            modelBuilder.Entity<Sinif>(entity =>
            {
                entity.ToTable("siniflar", "public");

                entity.HasKey(e => e.SinifId).HasName("sinifler_pk");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
