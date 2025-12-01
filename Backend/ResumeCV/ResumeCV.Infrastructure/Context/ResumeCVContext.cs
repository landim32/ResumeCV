using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ResumeCV.Infra.Context;

public partial class ResumeCVContext : DbContext
{
    public ResumeCVContext()
    {
    }

    public ResumeCVContext(DbContextOptions<ResumeCVContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<ResumeCourse> ResumeCourses { get; set; }

    public virtual DbSet<ResumeCourseSkill> ResumeCourseSkills { get; set; }

    public virtual DbSet<ResumeInfo> ResumeInfos { get; set; }

    public virtual DbSet<ResumeInfoSkill> ResumeInfoSkills { get; set; }

    public virtual DbSet<ResumeJob> ResumeJobs { get; set; }

    public virtual DbSet<ResumeJobSkill> ResumeJobSkills { get; set; }

    public virtual DbSet<ResumeLanguage> ResumeLanguages { get; set; }

    public virtual DbSet<ResumeSkill> ResumeSkills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.ResumeId).HasName("resume_pkey");

            entity.ToTable("resume");

            entity.Property(e => e.ResumeId).HasColumnName("resume_id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(180)
                .HasColumnName("email");
            entity.Property(e => e.JobDescription)
                .HasMaxLength(300)
                .HasColumnName("job_description");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(520)
                .HasColumnName("photo_url");
            entity.Property(e => e.Resume1)
                .HasMaxLength(3000)
                .HasColumnName("resume");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<ResumeCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("resume_courses_pkey");

            entity.ToTable("resume_courses");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseType).HasColumnName("course_type");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.Institute)
                .HasMaxLength(300)
                .HasColumnName("institute");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
            entity.Property(e => e.Resume)
                .HasMaxLength(3000)
                .HasColumnName("resume");
            entity.Property(e => e.ResumeId).HasColumnName("resume_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(560)
                .HasColumnName("title");
            entity.Property(e => e.Workload)
                .HasDefaultValue(0)
                .HasColumnName("workload");

            entity.HasOne(d => d.ResumeNavigation).WithMany(p => p.ResumeCourses)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_courses_resume_id_fkey");
        });

        modelBuilder.Entity<ResumeCourseSkill>(entity =>
        {
            entity.HasKey(e => e.CourseSkillId).HasName("resume_course_skills_pkey");

            entity.ToTable("resume_course_skills");

            entity.Property(e => e.CourseSkillId).HasColumnName("course_skill_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.Course).WithMany(p => p.ResumeCourseSkills)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_course_skills_course_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.ResumeCourseSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_course_skills_skill_id_fkey");
        });

        modelBuilder.Entity<ResumeInfo>(entity =>
        {
            entity.HasKey(e => e.InfoId).HasName("resume_infos_pkey");

            entity.ToTable("resume_infos");

            entity.Property(e => e.InfoId).HasColumnName("info_id");
            entity.Property(e => e.InfoType)
                .HasDefaultValue(1)
                .HasColumnName("info_type");
            entity.Property(e => e.Resume)
                .HasMaxLength(3000)
                .HasColumnName("resume");
            entity.Property(e => e.ResumeId).HasColumnName("resume_id");
            entity.Property(e => e.Title)
                .HasMaxLength(300)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(520)
                .HasColumnName("url");

            entity.HasOne(d => d.ResumeNavigation).WithMany(p => p.ResumeInfos)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_infos_resume_id_fkey");
        });

        modelBuilder.Entity<ResumeInfoSkill>(entity =>
        {
            entity.HasKey(e => e.InfoSkillId).HasName("resume_info_skills_pkey");

            entity.ToTable("resume_info_skills");

            entity.Property(e => e.InfoSkillId).HasColumnName("info_skill_id");
            entity.Property(e => e.InfoId).HasColumnName("info_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.Info).WithMany(p => p.ResumeInfoSkills)
                .HasForeignKey(d => d.InfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_info_skills_info_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.ResumeInfoSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_info_skills_skill_id_fkey");
        });

        modelBuilder.Entity<ResumeJob>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("resume_jobs_pkey");

            entity.ToTable("resume_jobs");

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.Business1)
                .HasMaxLength(120)
                .HasColumnName("business1");
            entity.Property(e => e.Business2)
                .HasMaxLength(120)
                .HasColumnName("business2");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.Location)
                .HasMaxLength(120)
                .HasColumnName("location");
            entity.Property(e => e.Position)
                .HasMaxLength(120)
                .HasColumnName("position");
            entity.Property(e => e.Resume)
                .HasMaxLength(3000)
                .HasColumnName("resume");
            entity.Property(e => e.ResumeId).HasColumnName("resume_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");

            entity.HasOne(d => d.ResumeNavigation).WithMany(p => p.ResumeJobs)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_jobs_resume_id_fkey");
        });

        modelBuilder.Entity<ResumeJobSkill>(entity =>
        {
            entity.HasKey(e => e.JobSkillId).HasName("resume_job_skills_pkey");

            entity.ToTable("resume_job_skills");

            entity.Property(e => e.JobSkillId).HasColumnName("job_skill_id");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.Job).WithMany(p => p.ResumeJobSkills)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_job_skills_job_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.ResumeJobSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_job_skills_skill_id_fkey");
        });

        modelBuilder.Entity<ResumeLanguage>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("resume_languages_pkey");

            entity.ToTable("resume_languages");

            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Language)
                .HasMaxLength(180)
                .HasColumnName("language");
            entity.Property(e => e.Level)
                .HasDefaultValue(1)
                .HasColumnName("level");
            entity.Property(e => e.ResumeId).HasColumnName("resume_id");

            entity.HasOne(d => d.Resume).WithMany(p => p.ResumeLanguages)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resume_languages_resume_id_fkey");
        });

        modelBuilder.Entity<ResumeSkill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("resume_skills_pkey");

            entity.ToTable("resume_skills");

            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("name");
            entity.Property(e => e.SkillType).HasColumnName("skill_type");
            entity.Property(e => e.Slug)
                .HasMaxLength(120)
                .HasColumnName("slug");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
