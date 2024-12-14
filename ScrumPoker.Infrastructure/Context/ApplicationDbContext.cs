using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScrumPoker.Domain;
using ScrumPoker.Domain.Entities;

namespace Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    {
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<UserRoom> UserRooms { get; set; }
    public DbSet<TemporaryUser> TemporaryUsers { get; set; }
}
