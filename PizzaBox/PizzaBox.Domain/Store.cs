using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain
{
    public class Store
    {
        public string location { get; set; }
        public string storeName { get; set; }

        private ArrayList comments;
        public Store()
        {
            comments = new ArrayList();
        }


        public ArrayList getComments()
        {
            return comments;
        }
        public void setNewComment(string comment)
        {
            comments.Add(comment);
        }


    }
}
