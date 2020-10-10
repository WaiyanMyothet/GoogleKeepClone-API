using GoogleKeepClone_API.Models;
using GoogleKeepClone_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleKeepClone_API.UnitOfWork
{
    public class UOW
    {
        private IRepository<Labels> _labelRepo;
        private IRepository<Notes> _notesRepo;
        private IRepository<User> _userRepo;
        
        private KeepCloneContext _ctx;
        public UOW(KeepCloneContext ctx)
        {
            _ctx = ctx;
        }
        public IRepository<Labels> itemRepo
        {
            get
            {
                if (_labelRepo == null)
                {
                    _labelRepo = new Repository<Labels>(_ctx);
                }
                return _labelRepo;
            }
        }
        public IRepository<Notes> itemDetailRepo
        {
            get
            {
                if (_notesRepo == null)
                {
                    _notesRepo = new Repository<Notes>(_ctx);
                }
                return _notesRepo;
            }
        }
        public IRepository<User> brandRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new Repository<User>(_ctx);
                }
                return _userRepo;
            }
        }
    
    }
}