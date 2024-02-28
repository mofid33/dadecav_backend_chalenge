using System;
using Dadecar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dadecar.Persistence.Contexts
{
    public partial class ApplicationDbContext : DbContext
    {
       
            public ApplicationDbContext
                (DbContextOptions<ApplicationDbContext> options)
                : base(options)
            { }
            public DbSet<Flight> Flights { get; set; } = null!;
            public DbSet<Route> Routes { get; set; } = null!;
            public DbSet<Subscription> Subscriptions { get; set; } = null!;


     
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .UseCollation("utf8mb4_0900_ai_ci")
        //        .HasCharSet("utf8mb4");

        //    modelBuilder.Entity<Flight>(entity =>
        //    {
        //        entity.HasKey(e => e.flight_id).HasName("PRIMARY");

        //        entity.ToTable("flights");

        //        entity.HasIndex(e => e.route_id, "fk_route_id");

        //        entity.Property(e => e.flight_id)
        //            .ValueGeneratedNever()
        //            .HasColumnName("flight_id");
        //        entity.Property(e => e.airline_id).HasColumnName("airline_id");
        //        entity.Property(e => e.arrival_time)
        //            .HasColumnType("datetime")
        //            .HasColumnName("arrival_time");
        //        entity.Property(e => e.departure_time)
        //            .HasColumnType("datetime")
        //            .HasColumnName("departure_time");
        //        entity.Property(e => e.route_id).HasColumnName("route_id");

        //        entity.HasOne(d => d.Route).WithMany(p => p.Flights)
        //            .HasForeignKey(d => d.route_id)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_route_id");
        //    });

        //    modelBuilder.Entity<Route>(entity =>
        //    {
        //        entity.HasKey(e => e.route_id).HasName("PRIMARY");

        //        entity.ToTable("routes");

        //        entity.Property(e => e.route_id)
        //            .ValueGeneratedNever()
        //            .HasColumnName("route_id");
        //        entity.Property(e => e.departure_date).HasColumnName("departure_date");
        //        entity.Property(e => e.destination_city_id).HasColumnName("destination_city_id");
        //        entity.Property(e => e.originCity_id).HasColumnName("origin_city_id");
        //    });

        //    modelBuilder.Entity<Subscription>(entity =>
        //    {
        //        entity.HasKey(e => e.subscription_id).HasName("PRIMARY");

        //        entity.ToTable("subscriptions");

        //        entity.Property(e => e.subscription_id).HasColumnName("subscription_id");
        //        entity.Property(e => e.agency_id).HasColumnName("agency_id");
        //        entity.Property(e => e.origin_city_id).HasColumnName("destination_city_id");
        //        entity.Property(e => e.destination_city_id).HasColumnName("origin_city_id");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

