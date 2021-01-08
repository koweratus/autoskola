using System;
using System.Collections.Generic;
using System.Text;
using CoksaProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoksaProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    public DbSet<Car> Car { get; set; }
    public DbSet<DrivingSchool> DrivingSchools { get; set; }
    public DbSet<DrivingSchoolCars> DrivingSchoolCarz  { get; set; }
    public DbSet<Candidate> Candidates   { get; set; }
    public DbSet<Tasks> Taskses { get; set; }
    
    public DbSet<Hours> Hourses { get; set; }
    public DbSet<CandidateTasks> CandidateTaskses { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
        
        modelBuilder.Entity<DrivingSchoolCars>()
            .HasKey(bc => new { bc.CarID, bc.DrivingSchoolID });  
        modelBuilder.Entity<DrivingSchoolCars>()
            .HasOne(bc => bc.Car)
            .WithMany(b => b.DrivingSchoolCarz)
            .HasForeignKey(bc => bc.CarID);  
        modelBuilder.Entity<DrivingSchoolCars>()
            .HasOne(bc => bc.DrivingSchool)
            .WithMany(c => c.DrivingSchoolCarz)
            .HasForeignKey(bc => bc.DrivingSchoolID);
        
        modelBuilder.Entity<CandidateTasks>()
            .HasKey(bc => new { bc.CandidateID, bc.TasksID ,bc.HoursID}); 
        
        modelBuilder.Entity<CandidateTasks>()
            .HasOne(bc => bc.Candidate)
            .WithMany(b => b.CandidateTaskses)
            .HasForeignKey(bc => bc.CandidateID);  
        
        modelBuilder.Entity<CandidateTasks>()
            .HasOne(bc => bc.Tasks)
            .WithMany(c => c.CandidateTaskses)
            .HasForeignKey(bc => bc.TasksID);
        
        modelBuilder.Entity<CandidateTasks>()
            .HasOne(bc => bc.Hours)
            .WithMany(c => c.CandidateTaskses)
            .HasForeignKey(bc => bc.HoursID);
        
    
      //     modelBuilder.Entity<ApplicationUser>().HasKey(u => u.Id);
    }
    }

}
