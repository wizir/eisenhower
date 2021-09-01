using eisenhower.Model;

namespace eisenhower.DataLayer
{
    public interface IToDoMatrixDal
    {
        void SaveMatrix(TodoMatrix matrix);
        TodoMatrix LoadMatrix();
    }
}
