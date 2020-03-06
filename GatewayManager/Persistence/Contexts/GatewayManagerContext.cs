using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GatewayManager.Domain.Models;

namespace GatewayManager.Persistence.Contexts
{
    public class GatewayManagerContext : DbContext
    {
        public GatewayManagerContext(DbContextOptions<GatewayManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Gateway> Gateway { get; set; }
        public DbSet<PeripheralDevice> Peripherals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gateway>().ToTable("Gateways");
            modelBuilder.Entity<Gateway>().Property(g => g.GatewayID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Gateway>().HasIndex(g => g.SerialNumber).IsUnique(true);
            modelBuilder.Entity<Gateway>().HasMany(g => g.Peripherals).WithOne(d => d.Gateway).HasForeignKey(d => d.GatewayID);

            modelBuilder.Entity<PeripheralDevice>().ToTable("PeripheralDevices");
            modelBuilder.Entity<PeripheralDevice>().Property(d => d.PDeviceID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Gateway>().HasData(
                new Gateway { GatewayID = 150, IPAddress = "152.35.4.140", Name = "Gateway1", SerialNumber = "G112345" },
                new Gateway { GatewayID = 151, IPAddress = "120.245.181.13", Name = "Gateway2", SerialNumber = "G212345" }
            );

            modelBuilder.Entity<PeripheralDevice>().HasData(
                new PeripheralDevice { PDeviceID = 101, CreationDate = new DateTime(2020, 02, 29), Status = EDeviceStatus.Offline, Vendor = "Realtek", GatewayID = 150 },
                new PeripheralDevice { PDeviceID = 102, CreationDate = new DateTime(2020, 02, 29), Status = EDeviceStatus.Online, Vendor = "Asus", GatewayID = 150 },
                new PeripheralDevice { PDeviceID = 103, CreationDate = new DateTime(2020, 02, 29), Status = EDeviceStatus.Online, Vendor = "Qalcom", GatewayID = 150 },
                new PeripheralDevice { PDeviceID = 104, CreationDate = new DateTime(2020, 02, 29), Status = EDeviceStatus.Online, Vendor = "NVidia", GatewayID = 150 },
                new PeripheralDevice { PDeviceID = 105, CreationDate = new DateTime(2020, 02, 29), Status = EDeviceStatus.Offline, Vendor = "NVidia", GatewayID = 151 },
                new PeripheralDevice { PDeviceID = 106, CreationDate = new DateTime(2020, 02, 29), Status = EDeviceStatus.Offline, Vendor = "Realtek", GatewayID = 151 },
                new PeripheralDevice { PDeviceID = 107, CreationDate = new DateTime(2020, 02, 29), Status = EDeviceStatus.Online, Vendor = "Realtek", GatewayID = 151 }
            );
        }
    }
}
