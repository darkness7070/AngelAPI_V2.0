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
        public Entities.Application Application { get; set; }
        public List<Visitor> Visitors { get; set; }
    }
}