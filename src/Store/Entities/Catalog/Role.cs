﻿using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Common.EntityAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Store.Entities;

public sealed class Role: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}