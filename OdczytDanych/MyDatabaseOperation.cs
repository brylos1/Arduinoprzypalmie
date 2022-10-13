using System;
using OdczytDanych.entities;

namespace OdczytDanych
{
    public class MyDatabaseOperation
    {
        private PgsqlDbContext _dbcontext;
        public MyDatabaseOperation(PgsqlDbContext myDb)
        {
            _dbcontext = myDb;
        }
        public void zapiszdobazy(Temperatury temp)
        {
            _dbcontext.Add(temp);
            _dbcontext.SaveChanges();
        }
    }
}
        
         
