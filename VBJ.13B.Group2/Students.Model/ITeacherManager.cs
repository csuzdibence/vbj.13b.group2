namespace Students.Model
{
    public interface ITeacherManager
    {
        void Add(Teacher teacher);
        IQueryable<Teacher> GetAll();
    }
}
