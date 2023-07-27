using System;
using System.Collections.Generic;

namespace Ispit.API.Models
{
    public partial class ToDoList
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
