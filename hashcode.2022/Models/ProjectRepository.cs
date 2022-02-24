using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode._2022.Models
{
    public class ProjectRepository
    {
        public ProjectRepository(List<Project> projects)
        {
            Projects = projects;
        }

        public List<Project> Projects { get; }

        public Project GetNext()
        {
            var res = Projects.FirstOrDefault();
            if (res != null)
                Projects.Remove(res);
            return res;
        }
    }
}
