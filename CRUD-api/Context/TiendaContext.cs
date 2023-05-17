﻿using System;
using System.Collections.Generic;
using CRUD_api.Models.Local;
using Microsoft.EntityFrameworkCore;

namespace CRUD_api.Context;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DFERNAFA;Initial catalog=tienda;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cantidad");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Producto1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("producto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
