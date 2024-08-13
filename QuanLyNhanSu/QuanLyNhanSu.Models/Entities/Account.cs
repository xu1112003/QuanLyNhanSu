﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanSu.Models.Entities;

[Table("Account")]
public partial class Account
{
    [Key]
    public int AccountId { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Username { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string ConfirmPassword { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Role { get; set; }

    [InverseProperty("Account")]
    public virtual Employee Employee { get; set; }
}