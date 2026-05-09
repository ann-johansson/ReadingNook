using Mapster;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

public class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Book, BookDto>();
        config.NewConfig<ReadingSession, SessionDto>();
    }
}
