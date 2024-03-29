using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Arda.Kanban.Models;

namespace Arda.Kanban.Migrations
{
    [DbContext(typeof(KanbanContext))]
    [Migration("20160622142456_kanban-novo")]
    partial class kanbannovo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Arda.Common.Models.Kanban.Activity", b =>
                {
                    b.Property<Guid>("ActivityID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityName")
                        .IsRequired();

                    b.HasKey("ActivityID");

                    b.HasAnnotation("Relational:TableName", "Activities");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.Appointment", b =>
                {
                    b.Property<Guid>("AppointmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppointmentComment");

                    b.Property<DateTime>("AppointmentDate");

                    b.Property<int>("AppointmentHoursDispensed");

                    b.Property<decimal>("AppointmentTE");

                    b.Property<string>("AppointmentUserUniqueName")
                        .IsRequired();

                    b.Property<Guid?>("AppointmentWorkloadWBID")
                        .IsRequired();

                    b.HasKey("AppointmentID");

                    b.HasAnnotation("Relational:TableName", "Appointments");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.File", b =>
                {
                    b.Property<Guid>("FileID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileDescription");

                    b.Property<string>("FileLink")
                        .IsRequired();

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<Guid?>("WorkloadBacklogWBID");

                    b.HasKey("FileID");

                    b.HasAnnotation("Relational:TableName", "Files");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.FiscalYear", b =>
                {
                    b.Property<Guid>("FiscalYearID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FullNumericFiscalYear");

                    b.Property<string>("TextualFiscalYear")
                        .IsRequired();

                    b.HasKey("FiscalYearID");

                    b.HasAnnotation("Relational:TableName", "FiscalYears");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.Metric", b =>
                {
                    b.Property<Guid>("MetricID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<Guid?>("FiscalYearFiscalYearID");

                    b.Property<string>("MetricCategory")
                        .IsRequired();

                    b.Property<string>("MetricName")
                        .IsRequired();

                    b.HasKey("MetricID");

                    b.HasAnnotation("Relational:TableName", "Metrics");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.Technology", b =>
                {
                    b.Property<Guid>("TechnologyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TechnologyName")
                        .IsRequired();

                    b.HasKey("TechnologyID");

                    b.HasAnnotation("Relational:TableName", "Technologies");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.User", b =>
                {
                    b.Property<string>("UniqueName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("UniqueName");

                    b.HasAnnotation("Relational:TableName", "Users");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.WorkloadBacklog", b =>
                {
                    b.Property<Guid>("WBID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("WBActivityActivityID");

                    b.Property<int>("WBComplexity");

                    b.Property<string>("WBCreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("WBCreatedDate");

                    b.Property<string>("WBDescription");

                    b.Property<DateTime>("WBEndDate");

                    b.Property<int>("WBExpertise");

                    b.Property<bool>("WBIsWorkload");

                    b.Property<DateTime>("WBStartDate");

                    b.Property<int>("WBStatus");

                    b.Property<string>("WBTitle")
                        .IsRequired();

                    b.HasKey("WBID");

                    b.HasAnnotation("Relational:TableName", "WorkloadBacklogs");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.WorkloadBacklogMetric", b =>
                {
                    b.Property<Guid>("WBMetricID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MetricMetricID");

                    b.Property<Guid?>("WorkloadBacklogWBID");

                    b.HasKey("WBMetricID");

                    b.HasAnnotation("Relational:TableName", "WorkloadBacklogMetrics");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.WorkloadBacklogTechnology", b =>
                {
                    b.Property<Guid>("WBUTechnologyID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("TechnologyTechnologyID");

                    b.Property<Guid?>("WorkloadBacklogWBID");

                    b.HasKey("WBUTechnologyID");

                    b.HasAnnotation("Relational:TableName", "WorkloadBacklogTechnologies");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.WorkloadBacklogUser", b =>
                {
                    b.Property<Guid>("WBUserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserUniqueName");

                    b.Property<Guid?>("WorkloadBacklogWBID");

                    b.HasKey("WBUserID");

                    b.HasAnnotation("Relational:TableName", "WorkloadBacklogUsers");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.Appointment", b =>
                {
                    b.HasOne("Arda.Common.Models.Kanban.User")
                        .WithMany()
                        .HasForeignKey("AppointmentUserUniqueName");

                    b.HasOne("Arda.Common.Models.Kanban.WorkloadBacklog")
                        .WithMany()
                        .HasForeignKey("AppointmentWorkloadWBID");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.File", b =>
                {
                    b.HasOne("Arda.Common.Models.Kanban.WorkloadBacklog")
                        .WithMany()
                        .HasForeignKey("WorkloadBacklogWBID");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.Metric", b =>
                {
                    b.HasOne("Arda.Common.Models.Kanban.FiscalYear")
                        .WithMany()
                        .HasForeignKey("FiscalYearFiscalYearID");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.WorkloadBacklog", b =>
                {
                    b.HasOne("Arda.Common.Models.Kanban.Activity")
                        .WithMany()
                        .HasForeignKey("WBActivityActivityID");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.WorkloadBacklogMetric", b =>
                {
                    b.HasOne("Arda.Common.Models.Kanban.Metric")
                        .WithMany()
                        .HasForeignKey("MetricMetricID");

                    b.HasOne("Arda.Common.Models.Kanban.WorkloadBacklog")
                        .WithMany()
                        .HasForeignKey("WorkloadBacklogWBID");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.WorkloadBacklogTechnology", b =>
                {
                    b.HasOne("Arda.Common.Models.Kanban.Technology")
                        .WithMany()
                        .HasForeignKey("TechnologyTechnologyID");

                    b.HasOne("Arda.Common.Models.Kanban.WorkloadBacklog")
                        .WithMany()
                        .HasForeignKey("WorkloadBacklogWBID");
                });

            modelBuilder.Entity("Arda.Common.Models.Kanban.WorkloadBacklogUser", b =>
                {
                    b.HasOne("Arda.Common.Models.Kanban.User")
                        .WithMany()
                        .HasForeignKey("UserUniqueName");

                    b.HasOne("Arda.Common.Models.Kanban.WorkloadBacklog")
                        .WithMany()
                        .HasForeignKey("WorkloadBacklogWBID");
                });
        }
    }
}
