using System;
using System.Collections.Generic;
using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Store;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DumpNpa> DumpNpas { get; set; }

    public virtual DbSet<OrderBlock> OrderBlocks { get; set; }

    public virtual DbSet<SettingsBlock> SettingsBlocks { get; set; }

    public virtual DbSet<SettingsBlocksAndHistory> SettingsBlocksAndHistories { get; set; }

    public virtual DbSet<SettingsBlocksHistory> SettingsBlocksHistories { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffRole> StaffRoles { get; set; }

    public virtual DbSet<StaffRoleStaffView> StaffRoleStaffViews { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskStorage> TaskStorages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=8521;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<DumpNpa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dump_npa");
        });

        modelBuilder.Entity<OrderBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_blocks_pkey");

            entity.ToTable("order_blocks");

            entity.HasIndex(e => new { e.Klient, e.Account, e.Block }, "unique_blocks_in_work").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account).HasColumnName("account");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Block).HasColumnName("block");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.EndProgon).HasColumnName("end_progon");
            entity.Property(e => e.EndSetting).HasColumnName("end_setting");
            entity.Property(e => e.EndTask).HasColumnName("end_task");
            entity.Property(e => e.Klient).HasColumnName("klient");
            entity.Property(e => e.SettingOption).HasColumnName("setting_option");
            entity.Property(e => e.SheetName).HasColumnName("sheet_name");
            entity.Property(e => e.StartProgon).HasColumnName("start_progon");
            entity.Property(e => e.StartSetting).HasColumnName("start_setting");
            entity.Property(e => e.StartTask).HasColumnName("start_task");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<SettingsBlock>(entity =>
        {
            entity.HasKey(e => e.SerialNumber).HasName("settings_blocks_pkey1");

            entity.ToTable("settings_blocks");

            entity.Property(e => e.SerialNumber)
                .ValueGeneratedNever()
                .HasColumnName("serial_number");
            entity.Property(e => e.Block).HasColumnName("block");
            entity.Property(e => e.DateSetting).HasColumnName("date_setting");
            entity.Property(e => e.IdOrderBlocksInSetup).HasColumnName("id_order_blocks_in_setup");
            entity.Property(e => e.IdOrderProgon).HasColumnName("id_order_progon");
            entity.Property(e => e.LastDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_date");
            entity.Property(e => e.LastUser)
                .HasColumnType("character varying")
                .HasColumnName("last_user");
            entity.Property(e => e.Memory).HasColumnName("memory");
            entity.Property(e => e.MessageJob).HasColumnName("message_job");
            entity.Property(e => e.MessageRmOs).HasColumnName("message_rm_os");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.NumberInOrder).HasColumnName("number_in_order");
            entity.Property(e => e.NumberNs).HasColumnName("number_ns");
            entity.Property(e => e.NumberRm).HasColumnName("number_rm");
            entity.Property(e => e.SettingFlag).HasColumnName("setting_flag");
            entity.Property(e => e.SettingOption).HasColumnName("setting_option");
            entity.Property(e => e.Store).HasColumnName("store");
        });

        modelBuilder.Entity<SettingsBlocksAndHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("settings_blocks_and_history");

            entity.Property(e => e.Block).HasColumnName("block");
            entity.Property(e => e.DateSetting).HasColumnName("date_setting");
            entity.Property(e => e.HistoryDate).HasColumnName("history_date");
            entity.Property(e => e.IdOrderBlocksInSetup).HasColumnName("id_order_blocks_in_setup");
            entity.Property(e => e.IdOrderProgon).HasColumnName("id_order_progon");
            entity.Property(e => e.LastDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_date");
            entity.Property(e => e.LastUser)
                .HasColumnType("character varying")
                .HasColumnName("last_user");
            entity.Property(e => e.Memory).HasColumnName("memory");
            entity.Property(e => e.MessageJob).HasColumnName("message_job");
            entity.Property(e => e.MessageRmOs).HasColumnName("message_rm_os");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.NumberInOrder).HasColumnName("number_in_order");
            entity.Property(e => e.NumberNs).HasColumnName("number_ns");
            entity.Property(e => e.NumberRm).HasColumnName("number_rm");
            entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            entity.Property(e => e.SettingOption).HasColumnName("setting_option");
        });

        modelBuilder.Entity<SettingsBlocksHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("settings_blocks_history");

            entity.Property(e => e.Block).HasColumnName("block");
            entity.Property(e => e.DateSetting).HasColumnName("date_setting");
            entity.Property(e => e.HistoryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("history_date");
            entity.Property(e => e.HistoryOp)
                .HasColumnType("character varying")
                .HasColumnName("history_op");
            entity.Property(e => e.IdOrderBlocksInSetup).HasColumnName("id_order_blocks_in_setup");
            entity.Property(e => e.IdOrderProgon).HasColumnName("id_order_progon");
            entity.Property(e => e.Idh)
                .ValueGeneratedOnAdd()
                .HasColumnName("idh");
            entity.Property(e => e.LastDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_date");
            entity.Property(e => e.LastUser)
                .HasColumnType("character varying")
                .HasColumnName("last_user");
            entity.Property(e => e.Memory).HasColumnName("memory");
            entity.Property(e => e.MessageJob).HasColumnName("message_job");
            entity.Property(e => e.MessageRmOs).HasColumnName("message_rm_os");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.NumberInOrder).HasColumnName("number_in_order");
            entity.Property(e => e.NumberNs).HasColumnName("number_ns");
            entity.Property(e => e.NumberRm).HasColumnName("number_rm");
            entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            entity.Property(e => e.SettingFlag).HasColumnName("setting_flag");
            entity.Property(e => e.SettingOption).HasColumnName("setting_option");
            entity.Property(e => e.Store).HasColumnName("store");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("specification");

            entity.HasIndex(e => new { e.Name, e.Description, e.NameElement }, "unique_specification").IsUnique();

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Designator).HasColumnName("designator");
            entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NameElement).HasColumnName("name_element");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("staff_pkey");

            entity.ToTable("staff");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LastDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_date");
            entity.Property(e => e.LastUser)
                .HasColumnType("character varying")
                .HasColumnName("last_user");
            entity.Property(e => e.Manager)
                .HasColumnType("character varying")
                .HasColumnName("manager");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("ФИО сотрудника")
                .HasColumnName("name");
            entity.Property(e => e.NumberCabinet).HasColumnName("number_cabinet");
            entity.Property(e => e.NumberPrint).HasColumnName("number_print");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .HasColumnName("post");
        });

        modelBuilder.Entity<StaffRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("staff_role");

            entity.Property(e => e.Manager)
                .HasColumnType("character varying")
                .HasColumnName("manager");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .HasColumnName("post");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Tel)
                .HasMaxLength(50)
                .HasColumnName("tel");
        });

        modelBuilder.Entity<StaffRoleStaffView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("staff_role_staff_view");

            entity.Property(e => e.SotrManager)
                .HasColumnType("character varying")
                .HasColumnName("sotr_manager");
            entity.Property(e => e.SotrName)
                .HasMaxLength(50)
                .HasColumnName("sotr_name");
            entity.Property(e => e.SotrPrint)
                .HasMaxLength(50)
                .HasColumnName("sotr_print");
            entity.Property(e => e.SotrRole)
                .HasMaxLength(50)
                .HasColumnName("sotr_role");
            entity.Property(e => e.SotrTel)
                .HasMaxLength(50)
                .HasColumnName("sotr_tel");
            entity.Property(e => e.TelegaCabinet).HasColumnName("telega_cabinet");
            entity.Property(e => e.TelegaId).HasColumnName("telega_id");
            entity.Property(e => e.TelegaLastDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("telega_last_date");
            entity.Property(e => e.TelegaManager)
                .HasColumnType("character varying")
                .HasColumnName("telega_manager");
            entity.Property(e => e.TelegaName)
                .HasMaxLength(50)
                .HasColumnName("telega_name");
            entity.Property(e => e.TelegaPost)
                .HasMaxLength(50)
                .HasColumnName("telega_post");
            entity.Property(e => e.TelegaPrint).HasColumnName("telega_print");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_pkey");

            entity.ToTable("task");

            entity.HasIndex(e => new { e.Name, e.Klient, e.Account, e.TaskName, e.Amount, e.DateStart }, "unique_task").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account).HasColumnName("account");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.IdName).HasColumnName("id_name");
            entity.Property(e => e.IdOrderBlocks).HasColumnName("id_order_blocks");
            entity.Property(e => e.Klient).HasColumnName("klient");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NumberPrint).HasColumnName("number_print");
            entity.Property(e => e.SheetName).HasColumnName("sheet_name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StorageFlag).HasColumnName("storage_flag");
            entity.Property(e => e.TaskName).HasColumnName("task_name");
        });

        modelBuilder.Entity<TaskStorage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_storage_pkey");

            entity.ToTable("task_storage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateInsert).HasColumnName("date_insert");
            entity.Property(e => e.IdOrderBlocksInSetup).HasColumnName("id_order_blocks_in_setup");
            entity.Property(e => e.IdOrderBlocksInTask).HasColumnName("id_order_blocks_in_task");
            entity.Property(e => e.NumberRm).HasColumnName("number_rm");
            entity.Property(e => e.TaskName).HasColumnName("task_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
