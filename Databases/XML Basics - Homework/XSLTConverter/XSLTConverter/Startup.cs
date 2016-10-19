using System.Xml.Xsl;

namespace XSLTConverter
{
    public class Startup
    {
        private static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../Files/students.xsl");
            xslt.Transform("../../Files/students.xml", "../../Files/students.html");
        }
    }
}
