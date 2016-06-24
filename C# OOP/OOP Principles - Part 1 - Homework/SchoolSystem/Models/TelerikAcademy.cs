namespace SchoolSystem.Models
{
    using SchoolSystem.Models.Contracts;

    internal class TelerikAcademy : School, ISchool
    {
        private const string AcademyName = "Telerik Academy by Progress";

        public TelerikAcademy()
        {
            this.Name = AcademyName;
        }
    }
}
