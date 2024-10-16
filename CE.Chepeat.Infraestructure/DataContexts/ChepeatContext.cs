using CE.Chepeat.Domain.DTOs.Session;
using CE.Chepeat.Domain.DTOs;

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
    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseSqlServer("");
        }
    }
}