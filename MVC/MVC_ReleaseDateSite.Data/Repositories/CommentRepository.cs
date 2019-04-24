using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Data;

namespace MVC_ReleaseDateSite.Data {
    public class CommentRepository {

        private ICommentContext context;

        public CommentRepository(ICommentContext  context) {
            this.context = context;
        }

        public void Add(IComment comment) {
            context.Add(comment);
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
            return context.GetAllFromRelease(releaseId);
        }
    }
}
