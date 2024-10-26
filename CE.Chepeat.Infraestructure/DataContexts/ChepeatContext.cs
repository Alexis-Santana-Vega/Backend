using CE.Chepeat.Domain.DTOs.Product;
using CE.Chepeat.Domain.DTOs.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;


namespace CE.Chepeat.Infraestructure.DataContexts;
public class ChepeatContext : DbContext
{
    public ChepeatContext(DbContextOptions<ChepeatContext> options) : base(options)
    {
    }
    #region Generic Dtos DB
    public DbSet<RespuestaDB> respuestaDB { get; set; }
    public DbSet<UserDto> userDto { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(""); // Parte original
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var wktReader = new WKTReader(); // WKT = Well-Known Text

        // Definir un ValueConverter que convierta el punto a texto y viceversa
        var pointConverter = new ValueConverter<Point, string>(
            v => v == null ? null : v.AsText(),
            v => v == null ? null : (Point)wktReader.Read(v)
        );


        /*
         modelBuilder.Entity<Seller>()
            .Property(s => s.Location)
            .HasConversion(pointConverter)
            .HasColumnType("GEOGRAPHY");
         */

    }
}