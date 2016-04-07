using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace FragSwapperV2.Migrations
{
    public partial class Update_20160407135705 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_AdvertisementHistory_Advertisement_AdvertisementID", table: "AdvertisementHistory");
            migrationBuilder.DropForeignKey(name: "FK_Event_Host_HostID", table: "Event");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_ApplicationUser_ApplicationUserId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "SourceID", table: "Image");
            migrationBuilder.AddColumn<int>(
                name: "AdvertisementID",
                table: "Image",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Image",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Image",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "HostID",
                table: "Image",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementHistory_Advertisement_AdvertisementID",
                table: "AdvertisementHistory",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Event_Host_HostID",
                table: "Event",
                column: "HostID",
                principalTable: "Host",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Image_Advertisement_AdvertisementID",
                table: "Image",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Image_ApplicationUser_ApplicationUserId",
                table: "Image",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Image_Event_EventID",
                table: "Image",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Image_Host_HostID",
                table: "Image",
                column: "HostID",
                principalTable: "Host",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_ApplicationUser_ApplicationUserId",
                table: "Ticket",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_AdvertisementHistory_Advertisement_AdvertisementID", table: "AdvertisementHistory");
            migrationBuilder.DropForeignKey(name: "FK_Event_Host_HostID", table: "Event");
            migrationBuilder.DropForeignKey(name: "FK_Image_Advertisement_AdvertisementID", table: "Image");
            migrationBuilder.DropForeignKey(name: "FK_Image_ApplicationUser_ApplicationUserId", table: "Image");
            migrationBuilder.DropForeignKey(name: "FK_Image_Event_EventID", table: "Image");
            migrationBuilder.DropForeignKey(name: "FK_Image_Host_HostID", table: "Image");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_ApplicationUser_ApplicationUserId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "AdvertisementID", table: "Image");
            migrationBuilder.DropColumn(name: "ApplicationUserId", table: "Image");
            migrationBuilder.DropColumn(name: "EventID", table: "Image");
            migrationBuilder.DropColumn(name: "HostID", table: "Image");
            migrationBuilder.AddColumn<int>(
                name: "SourceID",
                table: "Image",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementHistory_Advertisement_AdvertisementID",
                table: "AdvertisementHistory",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Event_Host_HostID",
                table: "Event",
                column: "HostID",
                principalTable: "Host",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_ApplicationUser_ApplicationUserId",
                table: "Ticket",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
