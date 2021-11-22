using AutoMapper;
using Notes.Entities;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Note, NoteVM>();
            CreateMap<NoteVM, Note>();
        }
        }
}
