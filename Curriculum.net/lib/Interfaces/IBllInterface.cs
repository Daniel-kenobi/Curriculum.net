using Models;

namespace lib.Interfaces
{
    public interface IBllInterface<T> where T : class
    {
        void bll_vld(CurriculumModel adt);
        bool bll_criaCurriculum(CurriculumModel adt);
        string bll_retornaHTMLCurricullum(CurriculumModel adt);
    }
}
