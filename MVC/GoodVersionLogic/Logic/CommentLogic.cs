using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Logic {
   public class CommentLogic {
        private CommentRepository repository;
        public CommentLogic(CommentRepository repository) {
            this.repository = repository;
        }

        public void Add(IComment comment) {
            repository.Add(comment);
        }

        public void AddReply() {
            throw new NotImplementedException();
           
        }

        public void Delete() {
           throw new NotImplementedException();
        }

        public void Edit() {
           throw new NotImplementedException();
        }

        public IList<IComment> GetAllFromRelease(int releaseId) {
            IList<IComment> toReturn = repository.GetAllFromRelease(releaseId);
            return toReturn;
        }


    }
}
