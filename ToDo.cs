using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList_ToDoAPI.Models
{
    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Title { get; set; }
        public string Note { get; set; }
        public bool IsComplete { get; set; } = false;
        public DateTime DeadlineDateTime { get; set; } = DateTime.Now.AddDays(1.0);
        public DateTime CreatedDate { get; set;} = DateTime.Now;
    }
}