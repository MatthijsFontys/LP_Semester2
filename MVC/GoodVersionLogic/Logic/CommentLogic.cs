﻿using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Logic {
   public class CommentLogic {
        private CommentRepository commentRepository;
        public CommentLogic(CommentRepository repository) {
            this.commentRepository = repository;
        }

        public void Add(IComment comment) {
            commentRepository.Add(comment);
        }

        public void Delete() {
           throw new NotImplementedException();
        }

        public void Edit() {
           throw new NotImplementedException();
        }

        public IList<IComment> GetAllFromRelease(int releaseId) {
            IList<IComment> toReturn = commentRepository.GetAllFromRelease(releaseId);
            return toReturn;
        }


    }
}
