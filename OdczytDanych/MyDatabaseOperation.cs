using System;
using OdczytDanych.entities;

namespace OdczytDanych
{
    public class MyDatabaseOperation
    {
        private MyDbContext _dbcontext;
        public MyDatabaseOperation(MyDbContext myDb)
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
        
         
