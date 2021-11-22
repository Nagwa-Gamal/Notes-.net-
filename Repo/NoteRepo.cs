using AutoMapper;
using Notes.Authentication;
using Notes.Entities;
using Notes.Interfaces;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Repo
{
    public class NoteRepo : INoteRepo
    {
        private readonly DBContext db;
        private readonly IMapper mapper;

        public NoteRepo(DBContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public NoteVM Add(NoteVM ob)
        {

            Note data = mapper.Map<Note>(ob);
            db.Note.Add(data);
            db.SaveChanges();
            return ob;
        }

        public NoteVM Delete(int id)
        {
            try
            {
                Note d = db.Note.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();
                NoteVM data = mapper.Map<NoteVM>(d);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public NoteVM Edit(NoteVM ob)
        {

            try
            {
                var data = mapper.Map<Note>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<NoteVM> GetAll()
        {
            var data = db.Note.Select(n => new NoteVM { Id = n.Id, UserId = n.UserId,Title=n.Title,Text=n.Text });

            return data;
        }

        public NoteVM GetById(int id)
        {
           NoteVM data = db.Note.Where(n => n.Id == id).Select(n => new NoteVM { Id = n.Id, UserId = n.UserId,Title=n.Title, Text=n.Text }).FirstOrDefault();
            return data;
        }

        public IQueryable<NoteVM> Search(string name)
        {
            var data = db.Note.Where(n => n.Title.Contains(name)).Select(n => new NoteVM { Id = n.Id, UserId = n.UserId,Title=n.Title,Text=n.Text });
            return data;
        }
    }
}
