using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LikeButton.Models.Classes
{
    public class Like
    {   
        [Key]
        public int  article_id { get; set; }
        public int article_like { get; set; }
        public DateTime like_date { get; set; }
        public string like_user { get; set; } 

    }
}