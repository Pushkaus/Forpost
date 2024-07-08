using System.Collections;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class StorageRepository: Repository<Storage>, IStorageRepository
{
    public StorageRepository(ForpostContextPostgres db) : base(db)
    {
    }
}