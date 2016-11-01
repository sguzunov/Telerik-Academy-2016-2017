using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Material> materials;
        private ICollection<Student> students;
        private ICollection<Homework> homewroks;

        public Course()
        {
            this.materials = new HashSet<Material>();
            this.students = new HashSet<Student>();
            this.homewroks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<Material> Materials
        {
            get { return this.materials; }
            set { this.materials = value; }
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homewroks; }
            set { this.homewroks = value; }
        }
    }
}
