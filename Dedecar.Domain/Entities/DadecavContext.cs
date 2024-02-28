//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace Dadecar.Domain.Entities;

//public partial class DadecavContext : DbContext
//{
//    public DadecavContext()
//    {
//    }

//    public DadecavContext(DbContextOptions<DadecavContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Flight> Flights { get; set; }

//    public virtual DbSet<Route> Routes { get; set; }

//    public virtual DbSet<Subscription> Subscriptions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=127.0.0.1;database=dadecav;user=root;password=Aa@123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder
//            .UseCollation("utf8mb4_0900_ai_ci")
//            .HasCharSet("utf8mb4");

//        modelBuilder.Entity<Flight>(entity =>
//        {
//            entity.HasKey(e => e.flight_id).HasName("PRIMARY");

//            entity.ToTable("flights");

//            entity.HasIndex(e => e.route_id, "fk_route_id");

//            entity.Property(e => e.flight_id)
//                .ValueGeneratedNever()
//                .HasColumnName("flight_id");
//            entity.Property(e => e.airline_id).HasColumnName("airline_id");
//            entity.Property(e => e.arrival_time)
//                .HasColumnType("datetime")
//                .HasColumnName("arrival_time");
//            entity.Property(e => e.departure_time)
//                .HasColumnType("datetime")
//                .HasColumnName("departure_time");
//            entity.Property(e => e.route_id).HasColumnName("route_id");

//            entity.HasOne(d => d.Route).WithMany(p => p.Flights)
//                .HasForeignKey(d => d.route_id)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("fk_route_id");
//        });

//        modelBuilder.Entity<Route>(entity =>
//        {
//            entity.HasKey(e => e.route_id).HasName("PRIMARY");

//            entity.ToTable("routes");

//            entity.Property(e => e.route_id)
//                .ValueGeneratedNever()
//                .HasColumnName("route_id");
//            entity.Property(e => e.departure_date).HasColumnName("departure_date");
//            entity.Property(e => e.destination_city_id).HasColumnName("destination_city_id");
//            entity.Property(e => e.originCity_id).HasColumnName("origin_city_id");
//        });

//        modelBuilder.Entity<Subscription>(entity =>
//        {
//            entity.HasKey(e => e.subscription_id).HasName("PRIMARY");

//            entity.ToTable("subscriptions");

//            entity.Property(e => e.subscription_id).HasColumnName("subscription_id");
//            entity.Property(e => e.agency_id).HasColumnName("agency_id");
//            entity.Property(e => e.origin_city_id).HasColumnName("destination_city_id");
//            entity.Property(e => e.destination_city_id).HasColumnName("origin_city_id");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
