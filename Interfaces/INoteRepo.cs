using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Interfaces
{
   public interface INoteRepo
    {
        IQueryable<NoteVM> GetAll();
        NoteVM Add(NoteVM ob);
        NoteVM Delete(int id);
        NoteVM Edit(NoteVM ob);
        NoteVM GetById(int id);

        IQueryable<NoteVM> Search(string name);
    }
}
