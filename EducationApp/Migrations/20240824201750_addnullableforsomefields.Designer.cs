﻿// <auto-generated />
using System;
using EducationApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EducationApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240824201750_addnullableforsomefields")]
    partial class addnullableforsomefields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EducationApp.Domain.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DifficultyLevel")
                        .HasColumnType("text");

                    b.Property<string>("Duration")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Syllabus")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.CourseEnrollment", b =>
                {
                    b.Property<int>("CourseEnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseEnrollmentId"));

                    b.Property<string>("CertificateUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EnrolledAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("CourseEnrollmentId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseEnrollments");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LessonId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("LessonId");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("UserSubscriptionId")
                        .HasColumnType("integer");

                    b.HasKey("PaymentId");

                    b.HasIndex("UserSubscriptionId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuizId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("integer");

                    b.HasKey("QuizId");

                    b.HasIndex("LessonId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.QuizQuestion", b =>
                {
                    b.Property<int>("QuizQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuizQuestionId"));

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Options")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuizId")
                        .HasColumnType("integer");

                    b.HasKey("QuizQuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.QuizResult", b =>
                {
                    b.Property<int>("QuizResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuizResultId"));

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("QuizId")
                        .HasColumnType("integer");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("QuizResultId");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizResults");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.SocialAccount", b =>
                {
                    b.Property<int>("SocialAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SocialAccountId"));

                    b.Property<DateTime>("LinkedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProviderUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("SocialAccountId");

                    b.ToTable("SocialAccounts");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.SubscriptionPlan", b =>
                {
                    b.Property<int>("SubscriptionPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubscriptionPlanId"));

                    b.Property<string>("AccessLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SubscriptionPlanId");

                    b.ToTable("SubscriptionPlans");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.UserRatingReview", b =>
                {
                    b.Property<int>("UserRatingReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserRatingReviewId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserRatingReviewId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserRatingReviews");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.UserSubscription", b =>
                {
                    b.Property<int>("UserSubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserSubscriptionId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SubscriptionPlanId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserSubscriptionId");

                    b.HasIndex("SubscriptionPlanId");

                    b.ToTable("UserSubscriptions");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.CourseEnrollment", b =>
                {
                    b.HasOne("EducationApp.Domain.Models.Course", "Course")
                        .WithMany("CourseEnrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Lesson", b =>
                {
                    b.HasOne("EducationApp.Domain.Models.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Payment", b =>
                {
                    b.HasOne("EducationApp.Domain.Models.UserSubscription", "UserSubscription")
                        .WithMany()
                        .HasForeignKey("UserSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserSubscription");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Quiz", b =>
                {
                    b.HasOne("EducationApp.Domain.Models.Lesson", "Lesson")
                        .WithMany("Quizzes")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.QuizQuestion", b =>
                {
                    b.HasOne("EducationApp.Domain.Models.Quiz", "Quiz")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.QuizResult", b =>
                {
                    b.HasOne("EducationApp.Domain.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.UserRatingReview", b =>
                {
                    b.HasOne("EducationApp.Domain.Models.Course", "Course")
                        .WithMany("UserRatingReviews")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.UserSubscription", b =>
                {
                    b.HasOne("EducationApp.Domain.Models.SubscriptionPlan", "SubscriptionPlan")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("SubscriptionPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionPlan");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Course", b =>
                {
                    b.Navigation("CourseEnrollments");

                    b.Navigation("Lessons");

                    b.Navigation("UserRatingReviews");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Lesson", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.Quiz", b =>
                {
                    b.Navigation("QuizQuestions");
                });

            modelBuilder.Entity("EducationApp.Domain.Models.SubscriptionPlan", b =>
                {
                    b.Navigation("UserSubscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
