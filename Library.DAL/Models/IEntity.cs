using System;

namespace Library.DAL.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}