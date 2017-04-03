using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appfutebol.Dominio
{
    public class Jogo : DominioBase
    {
        public Jogo()
        {
            this.Clubes = new HashSet<Clube>();
            Jogadores = new List<Jogador>();
            Tecnicos = new List<Tecnico>();
        }
      
        public string Local { get; set; }
        public int GolsFeito{get; set;} 
        public int GolsSofrido { get; set; }
        public bool Vitoria { get; set; }
        public ICollection<Clube> Clubes { get; set; }
        public ICollection<Jogador> Jogadores { get; set; }
        public ICollection<Tecnico> Tecnicos { get; set; } 

    }
}
//public class Student
//{
//    public Student()
//    {
//        this.Courses = new HashSet<Course>();
//    }

//    public int StudentId { get; set; }
//    [Required]
//    public string StudentName { get; set; }

//    public virtual ICollection<Course> Courses { get; set; }
//}

//public class Course
//{
//    public Course()
//    {
//        this.Students = new HashSet<Student>();
//    }

//    public int CourseId { get; set; }
//    public string CourseName { get; set; }

//    public virtual ICollection<Student> Students { get; set; }
//}