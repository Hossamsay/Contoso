using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        //make constructor to start database first and make inhertance from Dbcontext constructors by using base word
        public SchoolContext() : base("SchoolContext")
        { }
        //make prop for every base class but make type Dbset to create tables and make table name (studets or Enrollments like this) collection name
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        //we make this to remove the way of naming tables in database to make it single instead of collection to make it like base classes 
        //this method come from Dbcontext and make it override 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //create pure join table in runtime not in database which has foregin keys only and will be compiste primary key 
            modelBuilder.Entity<Course>().HasMany(c => c.Instructors).WithMany(i => i.Courses).Map(t => t.MapLeftKey("CourseID")
            .MapRightKey("InstructorID").ToTable("CourseInstructor"));
        }
    }
}