using AngelAPI.Entities;

namespace AngelAPI.Models;

public class ResponseGeneral
{
    public class InfoApplication
    {
        public InfoApplication(Application application, List<Visitor> visitors)
        {
            Application = application;
            Visitors = visitors;
        }
        public Application Application { get; set; }
        public List<Visitor> Visitors { get; set; }
    }
    public class InfoApplications
    {
        public InfoApplications(Application applications, List<Worker> workers, List<Subdivision> subdivisions)
        {
            Application = applications;
            Workers = workers;
            Subdivisions = subdivisions;
        }
        public Application Application { get; set; }
        public List<Worker> Workers {get;set;}
        public List<Subdivision> Subdivisions {get;set;}
    }
}